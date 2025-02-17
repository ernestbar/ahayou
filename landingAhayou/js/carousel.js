document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".carousel").forEach((carousel) => {
        const slides = carousel.querySelectorAll(".carousel__item");
        const buttons = carousel.querySelectorAll(".carousel__button");
        const prevArrow = carousel.querySelector(".carousel__arrow--prev");
        const nextArrow = carousel.querySelector(".carousel__arrow--next");

        let currentIndex = 0;

        function showSlide(index) {
            slides.forEach((slide, i) => {
                slide.classList.toggle("active", i === index);
            });

            buttons.forEach((button, i) => {
                button.classList.toggle("selected", i === index);
            });

            currentIndex = index;
        }

        buttons.forEach((button, i) => {
            button.addEventListener("click", () => {
                showSlide(i);
            });
        });

        prevArrow.addEventListener("click", () => {
            let newIndex = (currentIndex - 1 + slides.length) % slides.length;
            showSlide(newIndex);
        });

        nextArrow.addEventListener("click", () => {
            let newIndex = (currentIndex + 1) % slides.length;
            showSlide(newIndex);
        });

        showSlide(0);
    });
});
