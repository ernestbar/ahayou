document.addEventListener("DOMContentLoaded", function () {
    const button = document.getElementById("menuButton");
    const menu = document.getElementById("optionsMenu");

    button.addEventListener("click", function (event) {
        event.preventDefault();
        menu.classList.toggle("options__menu--active");
        event.stopPropagation();
    });

    document.addEventListener("click", function (event) {
        if (!menu.contains(event.target) && !button.contains(event.target)) {
            menu.classList.remove("options__menu--active");
        }
    });
});
