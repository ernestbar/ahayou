document.addEventListener("DOMContentLoaded", function () {
    const containers = document.querySelectorAll(".submenu__container");

    containers.forEach((container) => {
        const button = container.querySelector(".submenu__button");
        const menu = container.querySelector(".submenu");

        if (!button || !menu) return;

        button.addEventListener("click", function (event) {
            event.preventDefault();
            event.stopPropagation();

            menu.classList.toggle("options__menu--active");
        });
    });

    document.addEventListener("click", function (event) {
        const activeMenus = document.querySelectorAll(
            ".submenu__container.options__menu--active"
        );

        activeMenus.forEach((menu) => {
            if (!menu.closest(".submenu__container").contains(event.target)) {
                menu.classList.remove("options__menu--active");
            }
        });
    });
});
