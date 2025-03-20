const baseWidth = 100;
const baseHeight = 100;
const backgroundColorFinal = "#000";

function updateHeaderBackground(
    index,
    viewportWidth,
    bgImage,
    maxWidth,
    element
) {
    if (bgImage) {
        if (index !== 0 && viewportWidth > maxWidth) {
            element.style.background = `radial-gradient(ellipse at right, transparent 20%,rgba(0, 0, 0, 0.45) 40%, rgba(0, 0, 0, 0.65) 55%, ${backgroundColorFinal} 70%), url(${bgImage}) center/cover no-repeat`;
            element.style.backgroundPosition = "center";
            element.style.objectFit = "fill";
        } else {
            element.style.background = `linear-gradient(to bottom, transparent 0%, #000000a0 75%, ${backgroundColorFinal} 95%), url('${
                index !== 0 && viewportWidth <= maxWidth
                    ? "../imgs/backgrounds/fondo_header_movil.jpg"
                    : bgImage
            }')`;
            element.style.backgroundPosition = "center";
            element.style.backgroundSize = "cover";
        }
    }
}
