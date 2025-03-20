document.addEventListener("DOMContentLoaded", function () {
    const button = document.getElementById("sidebarButton");
    const aside = document.getElementById("aside");

    button.addEventListener("click", function () {
        aside.classList.toggle("aside--open");
    });
});
