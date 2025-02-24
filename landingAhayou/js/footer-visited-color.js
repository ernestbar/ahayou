document.addEventListener("DOMContentLoaded", function () {
    const currentUrl = window.location.href;
    const links = document.querySelectorAll(".footer__list-item a");

    links.forEach((link) => {
        if (currentUrl.includes(link.href)) {
            link.classList.add("active");
        }
    });
});
