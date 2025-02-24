/**
 * @license Copyright (c) 2003-2024, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-oss-license
 */
/**
 * @license Copyright (c) 2003-2024, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/legal/ckeditor-licensing-options
 */
/**
 * @module paste-from-office/filters/bookmark
 */
import { type UpcastWriter, type ViewDocumentFragment } from 'ckeditor5/src/engine.js';
/**
 * Transforms `<a>` elements which are bookmarks by moving their children after the element.
 */
export default function transformBookmarks(documentFragment: ViewDocumentFragment, writer: UpcastWriter): void;
