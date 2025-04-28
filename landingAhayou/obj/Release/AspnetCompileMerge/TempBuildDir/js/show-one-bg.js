document.addEventListener("DOMContentLoaded", function () {
    const header = document.getElementById("header__movies");
    const item = document.getElementById("itemWithBackground");
    const bgImage = item.getAttribute("data-bg");
    header.style.background = `url(${bgImage}) center/cover no-repeat`;
});
