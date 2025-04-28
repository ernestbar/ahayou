document.addEventListener("DOMContentLoaded", function () {
    const activeClass = "movie__container--active";
    const maxWidth = 768;

    document.querySelectorAll(".header__item").forEach((item) => {
        const movies = item.querySelectorAll(".movie__container");

        function changeContent() {
            const screenWidth = window.innerWidth;

            if (screenWidth > maxWidth) {
                if (movies[1].classList.contains(activeClass)) {
                    movies[1].classList.remove(activeClass);
                    movies[0].classList.add(activeClass);
                }
            } else {
                if (movies[0].classList.contains(activeClass)) {
                    movies[0].classList.remove(activeClass);
                    movies[1].classList.add(activeClass);
                }
            }
        }

        window.addEventListener("resize", () => {
            if (movies.length > 0) {
                changeContent();
            }
        });

        if (movies.length > 0) {
            changeContent();
        }
    });
});
