document.addEventListener("DOMContentLoaded", function () {
    const maxWidth = 768;
    const header = document.getElementById("header__movies");

    document.querySelectorAll(".carousel").forEach((carousel) => {
        const slides = carousel.querySelectorAll(".carousel__item");
        const buttons = carousel.querySelectorAll(".carousel__button");
        const prevArrow = carousel.querySelector(".carousel__arrow--prev");
        const nextArrow = carousel.querySelector(".carousel__arrow--next");
        let currentIndex = 0;

        function showSlide(index) {
            if (!slides[index]) return;

            slides.forEach((slide, i) => {
                slide.classList.toggle("carousel__item--active", i === index);
            });

            buttons.forEach((button, i) => {
                button.classList.toggle("header__pag-button--selected", i === index);
            });

            const bgImage = slides[index].getAttribute("data-bg");
            const viewportWidth = window.innerWidth;

            updateHeaderBackground(
                index,
                viewportWidth,
                bgImage,
                maxWidth,
                header
            );

            currentIndex = index;
        }

        prevArrow.addEventListener("click", () => {
            let newIndex = (currentIndex - 1 + slides.length) % slides.length;
            showSlide(newIndex);
        });

        nextArrow.addEventListener("click", () => {
            let newIndex = (currentIndex + 1) % slides.length;
            showSlide(newIndex);
        });

        window.addEventListener("resize", () => showSlide(currentIndex));

        showSlide(0);
    });
});
