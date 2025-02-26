document.addEventListener("DOMContentLoaded", function () {
    const maxWidth = 768;

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
            const screenWidth = window.innerWidth;

            if (bgImage) {
                if (index !== 0 && screenWidth > maxWidth) {
                    header.style.background = `radial-gradient(circle at right, rgba(0, 0, 0, 0) 20%, #000 80%), linear-gradient(to bottom, transparent 0%, #000000a0 85%,#000 95%), url(${bgImage}) center/cover no-repeat`;
                    header.style.backgroundPosition = "top";
                    header.style.objectFit = "fill";
                } else {
                    header.style.background = `linear-gradient(to bottom, transparent 0%, #000000a0 75%,#000 95%), url('${
                        index !== 0 && screenWidth < maxWidth
                            ? "/imgs/backgrounds/fondo_header_movil.jpg"
                            : bgImage
                    }')`;
                    header.style.backgroundPosition = "center";
                    header.style.backgroundSize = "cover";
                }
            }

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
