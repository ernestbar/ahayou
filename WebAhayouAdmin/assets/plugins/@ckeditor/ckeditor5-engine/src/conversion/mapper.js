/**
 * @license Copyright (c) 2003-2024, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-licensing-options
 */
/**
 * @module engine/conversion/mapper
 */
import ModelPosition from '../model/position.js';
import ModelRange from '../model/range.js';
import ViewPosition from '../view/position.js';
import ViewRange from '../view/range.js';
import { CKEditorError, EmitterMixin } from '@ckeditor/ckeditor5-utils';
/**
 * Maps elements, positions and markers between the {@link module:engine/view/document~Document view} and
 * the {@link module:engine/model/model model}.
 *
 * The instance of the Mapper used for the editing pipeline is available in
 * {@link module:engine/controller/editingcontroller~EditingController#mapper `editor.editing.mapper`}.
 *
 * Mapper uses bound elements to find corresponding elements and positions, so, to get proper results,
 * all model elements should be {@link module:engine/conversion/mapper~Mapper#bindElements bound}.
 *
 * To map the complex model to/from view relations, you may provide custom callbacks for the
 * {@link module:engine/conversion/mapper~Mapper#event:modelToViewPosition modelToViewPosition event} and
 * {@link module:engine/conversion/mapper~Mapper#event:viewToModelPosition viewToModelPosition event} that are fired whenever
 * a position mapping request occurs.
 * Those events are fired by the {@link module:engine/conversion/mapper~Mapper#toViewPosition toViewPosition}
 * and {@link module:engine/conversion/mapper~Mapper#toModelPosition toModelPosition} methods. `Mapper` adds its own default callbacks
 * with `'lowest'` priority. To override default `Mapper` mapping, add custom callback with higher priority and
 * stop the event.
 */
export default class Mapper extends /* #__PURE__ */ EmitterMixin() {
    /**
     * Creates an instance of the mapper.
     */
    constructor() {
        super();
        /**
         * Model element to view element mapping.
         */
        this._modelToViewMapping = new WeakMap();
        /**
         * View element to model element mapping.
         */
        this._viewToModelMapping = new WeakMap();
        /**
         * A map containing callbacks between view element names and functions evaluating length of view elements
         * in model.
         */
        this._viewToModelLengthCallbacks = new Map();
        /**
         * Model marker name to view elements mapping.
         *
         * Keys are `String`s while values are `Set`s with {@link module:engine/view/element~Element view elements}.
         * One marker (name) can be mapped to multiple elements.
         */
        this._markerNameToElements = new Map();
        /**
         * View element to model marker names mapping.
         *
         * This is reverse to {@link ~Mapper#_markerNameToElements} map.
         */
        this._elementToMarkerNames = new Map();
        /**
         * The map of removed view elements with their current root (used for deferred unbinding).
         */
        this._deferredBindingRemovals = new Map();
        /**
         * Stores marker names of markers which have changed due to unbinding a view element (so it is assumed that the view element
         * has been removed, moved or renamed).
         */
        this._unboundMarkerNames = new Set();
        // Default mapper algorithm for mapping model position to view position.
        this.on('modelToViewPosition', (evt, data) => {
            if (data.viewPosition) {
                return;
            }
            const viewContainer = this._modelToViewMapping.get(data.modelPosition.parent);
            if (!viewContainer) {
                /**
                 * A model position could not be mapped to the view because the parent of the model position
                 * does not have a mapped view element (might have not been converted yet or it has no converter).
                 *
                 * Make sure that the model element is correctly converted to the view.
                 *
                 * @error mapping-model-position-view-parent-not-found
                 */
                throw new CKEditorError('mapping-model-position-view-parent-not-found', this, { modelPosition: data.modelPosition });
            }
            data.viewPosition = this.findPositionIn(viewContainer, data.modelPosition.offset);
        }, { priority: 'low' });
        // Default mapper algorithm for mapping view position to model position.
        this.on('viewToModelPosition', (evt, data) => {
            if (data.modelPosition) {
                return;
            }
            const viewBlock = this.findMappedViewAncestor(data.viewPosition);
            const modelParent = this._viewToModelMapping.get(viewBlock);
            const modelOffset = this._toModelOffset(data.viewPosition.parent, data.viewPosition.offset, viewBlock);
            data.modelPosition = ModelPosition._createAt(modelParent, modelOffset);
        }, { priority: 'low' });
    }
    /**
     * Marks model and view elements as corresponding. Corresponding elements can be retrieved by using
     * the {@link module:engine/conversion/mapper~Mapper#toModelElement toModelElement} and
     * {@link module:engine/conversion/mapper~Mapper#toViewElement toViewElement} methods.
     * The information that elements are bound is also used to translate positions.
     *
     * @param modelElement Model element.
     * @param viewElement View element.
     */
    bindElements(modelElement, viewElement) {
        this._modelToViewMapping.set(modelElement, viewElement);
        this._viewToModelMapping.set(viewElement, modelElement);
    }
    /**
     * Unbinds the given {@link module:engine/view/element~Element view element} from the map.
     *
     * **Note:** view-to-model binding will be removed, if it existed. However, corresponding model-to-view binding
     * will be removed only if model element is still bound to the passed `viewElement`.
     *
     * This behavior allows for re-binding model element to another view element without fear of losing the new binding
     * when the previously bound view element is unbound.
     *
     * @param viewElement View element to unbind.
     * @param options The options object.
     * @param options.defer Controls whether the binding should be removed immediately or deferred until a
     * {@link #flushDeferredBindings `flushDeferredBindings()`} call.
     */
    unbindViewElement(viewElement, options = {}) {
        const modelElement = this.toModelElement(viewElement);
        if (this._elementToMarkerNames.has(viewElement)) {
            for (const markerName of this._elementToMarkerNames.get(viewElement)) {
                this._unboundMarkerNames.add(markerName);
            }
        }
        if (options.defer) {
            this._deferredBindingRemovals.set(viewElement, viewElement.root);
        }
        else {
            this._viewToModelMapping.delete(viewElement);
            if (this._modelToViewMapping.get(modelElement) == viewElement) {
                this._modelToViewMapping.delete(modelElement);
            }
        }
    }
    /**
     * Unbinds the given {@link module:engine/model/element~Element model element} from the map.
     *
     * **Note:** the model-to-view binding will be removed, if it existed. However, the corresponding view-to-model binding
     * will be removed only if the view element is still bound to the passed `modelElement`.
     *
     * This behavior lets for re-binding view element to another model element without fear of losing the new binding
     * when the previously bound model element is unbound.
     *
     * @param modelElement Model element to unbind.
     */
    unbindModelElement(modelElement) {
        const viewElement = this.toViewElement(modelElement);
        this._modelToViewMapping.delete(modelElement);
        if (this._viewToModelMapping.get(viewElement) == modelElement) {
            this._viewToModelMapping.delete(viewElement);
        }
    }
    /**
     * Binds the given marker name with the given {@link module:engine/view/element~Element view element}. The element
     * will be added to the current set of elements bound with the given marker name.
     *
     * @param element Element to bind.
     * @param name Marker name.
     */
    bindElementToMarker(element, name) {
        const elements = this._markerNameToElements.get(name) || new Set();
        elements.add(element);
        const names = this._elementToMarkerNames.get(element) || new Set();
        names.add(name);
        this._markerNameToElements.set(name, elements);
        this._elementToMarkerNames.set(element, names);
    }
    /**
     * Unbinds an element from given marker name.
     *
     * @param element Element to unbind.
     * @param name Marker name.
     */
    unbindElementFromMarkerName(element, name) {
        const nameToElements = this._markerNameToElements.get(name);
        if (nameToElements) {
            nameToElements.delete(element);
            if (nameToElements.size == 0) {
                this._markerNameToElements.delete(name);
            }
        }
        const elementToNames = this._elementToMarkerNames.get(element);
        if (elementToNames) {
            elementToNames.delete(name);
            if (elementToNames.size == 0) {
                this._elementToMarkerNames.delete(element);
            }
        }
    }
    /**
     * Returns all marker names of markers which have changed due to unbinding a view element (so it is assumed that the view element
     * has been removed, moved or renamed) since the last flush. After returning, the marker names list is cleared.
     */
    flushUnboundMarkerNames() {
        const markerNames = Array.from(this._unboundMarkerNames);
        this._unboundMarkerNames.clear();
        return markerNames;
    }
    /**
     * Unbinds all deferred binding removals of view elements that in the meantime were not re-attached to some root or document fragment.
     *
     * See: {@link #unbindViewElement `unbindViewElement()`}.
     */
    flushDeferredBindings() {
        for (const [viewElement, root] of this._deferredBindingRemovals) {
            // Unbind it only if it wasn't re-attached to some root or document fragment.
            if (viewElement.root == root) {
                this.unbindViewElement(viewElement);
            }
        }
        this._deferredBindingRemovals = new Map();
    }
    /**
     * Removes all model to view and view to model bindings.
     */
    clearBindings() {
        this._modelToViewMapping = new WeakMap();
        this._viewToModelMapping = new WeakMap();
        this._markerNameToElements = new Map();
        this._elementToMarkerNames = new Map();
        this._unboundMarkerNames = new Set();
        this._deferredBindingRemovals = new Map();
    }
    toModelElement(viewElement) {
        return this._viewToModelMapping.get(viewElement);
    }
    toViewElement(modelElement) {
        return this._modelToViewMapping.get(modelElement);
    }
    /**
     * Gets the corresponding model range.
     *
     * @param viewRange View range.
     * @returns Corresponding model range.
     */
    toModelRange(viewRange) {
        return new ModelRange(this.toModelPosition(viewRange.start), this.toModelPosition(viewRange.end));
    }
    /**
     * Gets the corresponding view range.
     *
     * @param modelRange Model range.
     * @returns Corresponding view range.
     */
    toViewRange(modelRange) {
        return new ViewRange(this.toViewPosition(modelRange.start), this.toViewPosition(modelRange.end));
    }
    /**
     * Gets the corresponding model position.
     *
     * @fires viewToModelPosition
     * @param viewPosition View position.
     * @returns Corresponding model position.
     */
    toModelPosition(viewPosition) {
        const data = {
            viewPosition,
            mapper: this
        };
        this.fire('viewToModelPosition', data);
        return data.modelPosition;
    }
    /**
     * Gets the corresponding view position.
     *
     * @fires modelToViewPosition
     * @param modelPosition Model position.
     * @param options Additional options for position mapping process.
     * @param options.isPhantom Should be set to `true` if the model position to map is pointing to a place
     * in model tree which no longer exists. For example, it could be an end of a removed model range.
     * @returns Corresponding view position.
     */
    toViewPosition(modelPosition, options = {}) {
        const data = {
            modelPosition,
            mapper: this,
            isPhantom: options.isPhantom
        };
        this.fire('modelToViewPosition', data);
        return data.viewPosition;
    }
    /**
     * Gets all view elements bound to the given marker name.
     *
     * @param name Marker name.
     * @returns View elements bound with the given marker name or `null`
     * if no elements are bound to the given marker name.
     */
    markerNameToElements(name) {
        const boundElements = this._markerNameToElements.get(name);
        if (!boundElements) {
            return null;
        }
        const elements = new Set();
        for (const element of boundElements) {
            if (element.is('attributeElement')) {
                for (const clone of element.getElementsWithSameId()) {
                    elements.add(clone);
                }
            }
            else {
                elements.add(element);
            }
        }
        return elements;
    }
    /**
     * Registers a callback that evaluates the length in the model of a view element with the given name.
     *
     * The callback is fired with one argument, which is a view element instance. The callback is expected to return
     * a number representing the length of the view element in the model.
     *
     * ```ts
     * // List item in view may contain nested list, which have other list items. In model though,
     * // the lists are represented by flat structure. Because of those differences, length of list view element
     * // may be greater than one. In the callback it's checked how many nested list items are in evaluated list item.
     *
     * function getViewListItemLength( element ) {
     * 	let length = 1;
     *
     * 	for ( let child of element.getChildren() ) {
     * 		if ( child.name == 'ul' || child.name == 'ol' ) {
     * 			for ( let item of child.getChildren() ) {
     * 				length += getViewListItemLength( item );
     * 			}
     * 		}
     * 	}
     *
     * 	return length;
     * }
     *
     * mapper.registerViewToModelLength( 'li', getViewListItemLength );
     * ```
     *
     * @param viewElementName Name of view element for which callback is registered.
     * @param lengthCallback Function return a length of view element instance in model.
     */
    registerViewToModelLength(viewElementName, lengthCallback) {
        this._viewToModelLengthCallbacks.set(viewElementName, lengthCallback);
    }
    /**
     * For the given `viewPosition`, finds and returns the closest ancestor of this position that has a mapping to
     * the model.
     *
     * @param viewPosition Position for which a mapped ancestor should be found.
     */
    findMappedViewAncestor(viewPosition) {
        let parent = viewPosition.parent;
        while (!this._viewToModelMapping.has(parent)) {
            parent = parent.parent;
        }
        return parent;
    }
    /**
     * Calculates model offset based on the view position and the block element.
     *
     * Example:
     *
     * ```html
     * <p>foo<b>ba|r</b></p> // _toModelOffset( b, 2, p ) -> 5
     * ```
     *
     * Is a sum of:
     *
     * ```html
     * <p>foo|<b>bar</b></p> // _toModelOffset( p, 3, p ) -> 3
     * <p>foo<b>ba|r</b></p> // _toModelOffset( b, 2, b ) -> 2
     * ```
     *
     * @param viewParent Position parent.
     * @param viewOffset Position offset.
     * @param viewBlock Block used as a base to calculate offset.
     * @returns Offset in the model.
     */
    _toModelOffset(viewParent, viewOffset, viewBlock) {
        if (viewBlock != viewParent) {
            // See example.
            const offsetToParentStart = this._toModelOffset(viewParent.parent, viewParent.index, viewBlock);
            const offsetInParent = this._toModelOffset(viewParent, viewOffset, viewParent);
            return offsetToParentStart + offsetInParent;
        }
        // viewBlock == viewParent, so we need to calculate the offset in the parent element.
        // If the position is a text it is simple ("ba|r" -> 2).
        if (viewParent.is('$text')) {
            return viewOffset;
        }
        // If the position is in an element we need to sum lengths of siblings ( <b> bar </b> foo | -> 3 + 3 = 6 ).
        let modelOffset = 0;
        for (let i = 0; i < viewOffset; i++) {
            modelOffset += this.getModelLength(viewParent.getChild(i));
        }
        return modelOffset;
    }
    /**
     * Gets the length of the view element in the model.
     *
     * The length is calculated as follows:
     * * if a {@link #registerViewToModelLength length mapping callback} is provided for the given `viewNode`, it is used to
     * evaluate the model length (`viewNode` is used as first and only parameter passed to the callback),
     * * length of a {@link module:engine/view/text~Text text node} is equal to the length of its
     * {@link module:engine/view/text~Text#data data},
     * * length of a {@link module:engine/view/uielement~UIElement ui element} is equal to 0,
     * * length of a mapped {@link module:engine/view/element~Element element} is equal to 1,
     * * length of a non-mapped {@link module:engine/view/element~Element element} is equal to the length of its children.
     *
     * Examples:
     *
     * ```
     * foo                          -> 3 // Text length is equal to its data length.
     * <p>foo</p>                   -> 1 // Length of an element which is mapped is by default equal to 1.
     * <b>foo</b>                   -> 3 // Length of an element which is not mapped is a length of its children.
     * <div><p>x</p><p>y</p></div>  -> 2 // Assuming that <div> is not mapped and <p> are mapped.
     * ```
     *
     * @param viewNode View node.
     * @returns Length of the node in the tree model.
     */
    getModelLength(viewNode) {
        const stack = [viewNode];
        let len = 0;
        while (stack.length > 0) {
            const node = stack.pop();
            const callback = node.name &&
                this._viewToModelLengthCallbacks.size > 0 &&
                this._viewToModelLengthCallbacks.get(node.name);
            if (callback) {
                len += callback(node);
            }
            else if (this._viewToModelMapping.has(node)) {
                len += 1;
            }
            else if (node.is('$text')) {
                len += node.data.length;
            }
            else if (node.is('uiElement')) {
                continue;
            }
            else {
                for (const child of node.getChildren()) {
                    stack.push(child);
                }
            }
        }
        return len;
    }
    /**
     * Finds the position in the view node (or in its children) with the expected model offset.
     *
     * Example:
     *
     * ```
     * <p>fo<b>bar</b>bom</p> -> expected offset: 4
     *
     * findPositionIn( p, 4 ):
     * <p>|fo<b>bar</b>bom</p> -> expected offset: 4, actual offset: 0
     * <p>fo|<b>bar</b>bom</p> -> expected offset: 4, actual offset: 2
     * <p>fo<b>bar</b>|bom</p> -> expected offset: 4, actual offset: 5 -> we are too far
     *
     * findPositionIn( b, 4 - ( 5 - 3 ) ):
     * <p>fo<b>|bar</b>bom</p> -> expected offset: 2, actual offset: 0
     * <p>fo<b>bar|</b>bom</p> -> expected offset: 2, actual offset: 3 -> we are too far
     *
     * findPositionIn( bar, 2 - ( 3 - 3 ) ):
     * We are in the text node so we can simple find the offset.
     * <p>fo<b>ba|r</b>bom</p> -> expected offset: 2, actual offset: 2 -> position found
     * ```
     *
     * @param viewParent Tree view element in which we are looking for the position.
     * @param expectedOffset Expected offset.
     * @returns Found position.
     */
    findPositionIn(viewParent, expectedOffset) {
        // Last scanned view node.
        let viewNode;
        // Length of the last scanned view node.
        let lastLength = 0;
        let modelOffset = 0;
        let viewOffset = 0;
        // In the text node it is simple: the offset in the model equals the offset in the text.
        if (viewParent.is('$text')) {
            return new ViewPosition(viewParent, expectedOffset);
        }
        // In other cases we add lengths of child nodes to find the proper offset.
        // If it is smaller we add the length.
        while (modelOffset < expectedOffset) {
            viewNode = viewParent.getChild(viewOffset);
            lastLength = this.getModelLength(viewNode);
            modelOffset += lastLength;
            viewOffset++;
        }
        // If it equals we found the position.
        if (modelOffset == expectedOffset) {
            return this._moveViewPositionToTextNode(new ViewPosition(viewParent, viewOffset));
        }
        // If it is higher we need to enter last child.
        else {
            // ( modelOffset - lastLength ) is the offset to the child we enter,
            // so we subtract it from the expected offset to fine the offset in the child.
            return this.findPositionIn(viewNode, expectedOffset - (modelOffset - lastLength));
        }
    }
    /**
     * Because we prefer positions in the text nodes over positions next to text nodes, if the view position was next to a text node,
     * it moves it into the text node instead.
     *
     * ```
     * <p>[]<b>foo</b></p> -> <p>[]<b>foo</b></p> // do not touch if position is not directly next to text
     * <p>foo[]<b>foo</b></p> -> <p>foo{}<b>foo</b></p> // move to text node
     * <p><b>[]foo</b></p> -> <p><b>{}foo</b></p> // move to text node
     * ```
     *
     * @param viewPosition Position potentially next to the text node.
     * @returns Position in the text node if possible.
     */
    _moveViewPositionToTextNode(viewPosition) {
        // If the position is just after a text node, put it at the end of that text node.
        // If the position is just before a text node, put it at the beginning of that text node.
        const nodeBefore = viewPosition.nodeBefore;
        const nodeAfter = viewPosition.nodeAfter;
        if (nodeBefore && nodeBefore.is('view:$text')) {
            return new ViewPosition(nodeBefore, nodeBefore.data.length);
        }
        else if (nodeAfter && nodeAfter.is('view:$text')) {
            return new ViewPosition(nodeAfter, 0);
        }
        // Otherwise, just return the given position.
        return viewPosition;
    }
}
