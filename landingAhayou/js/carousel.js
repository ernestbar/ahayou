document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".carousel").forEach((carousel) => {
        const slides = carousel.querySelectorAll(".carousel__item");
        const buttons = carousel.querySelectorAll(".carousel__button");
        const prevArrow = carousel.querySelector(".carousel__arrow--prev");
        const nextArrow = carousel.querySelector(".carousel__arrow--next");
        const header = document.getElementById("header__movies");

        let currentIndex = 0;

        function showSlide(index) {
            if (!slides[index]) return;

            slides.forEach((slide, i) => {
                slide.classList.toggle("active", i === index);
            });

            buttons.forEach((button, i) => {
                button.classList.toggle("selected", i === index);
            });

            const bgImage = slides[index].getAttribute("data-bg");

            if (bgImage) {
                if (index !== 0) {
                    header.style.background = `radial-gradient(circle at right, rgba(0, 0, 0, 0) 20%, #000 80%), url(${bgImage}) center/cover no-repeat`;
                    header.style.backgroundSize = "cover";
                    header.style.backgroundPosition = "top";
                } else {
                    header.style.backgroundImage = `linear-gradient(to bottom, transparent 0%, #000000a0 75%,#000000f6 95%), url('${bgImage}')`;
                    header.style.backgroundSize = "100% 100%";
                    header.style.backgroundPosition = "center";
                }
            }

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
