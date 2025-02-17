document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".new-releases.carousel").forEach((carousel) => {
        let currentPage = 0;
        let itemsPerPage = 4;
        const list = carousel.querySelector(".new-releases__list");
        const items = list.querySelectorAll(".new-releases__item");
        let totalPages = Math.ceil(items.length / itemsPerPage);
        const nextButton = carousel.querySelector(".carousel__arrow--next");
        const prevButton = carousel.querySelector(".carousel__arrow--prev");

        function updateItemsPerPage() {
            const screenWidth = window.innerWidth;
            if (screenWidth >= 1600) {
                itemsPerPage = 4;
            } else if (screenWidth >= 1300) {
                itemsPerPage = 3;
            } else if (screenWidth >= 800) {
                itemsPerPage = 2;
            } else {
                itemsPerPage = 1;
            }
            
            totalPages = Math.ceil(items.length / itemsPerPage);

            if (currentPage >= totalPages) {
                currentPage = totalPages - 1;
            }

            showPage();
        }

        function showPage(direction = null) {
            if (direction) {
                list.classList.remove("show");
                list.classList.add(
                    direction === "next" ? "slide-in" : "slide-out"
                );

                setTimeout(() => {
                    updateVisibleItems();
                    list.classList.remove("slide-out", "slide-in");
                    list.classList.add("show");
                }, 300);
            } else {
                updateVisibleItems();
            }
        }

        function updateVisibleItems() {
            items.forEach((item) => (item.style.display = "none"));

            const start = currentPage * itemsPerPage;
            const end = start + itemsPerPage;

            for (let i = start; i < end && i < items.length; i++) {
                items[i].style.display = "block";
            }

            prevButton.disabled = currentPage === 0;
            nextButton.disabled = currentPage === totalPages - 1;
        }

        function nextPage() {
            if (currentPage < totalPages - 1) {
                currentPage++;
            } else {
                currentPage = 0;
            }
            showPage("next");
        }

        function prevPage() {
            if (currentPage > 0) {
                currentPage--;
            } else {
                currentPage = totalPages - 1;
            }
            showPage("prev");
        }

        function resizeHandler() {
            updateItemsPerPage();
            showPage();
        }

        updateItemsPerPage();
        showPage();

        nextButton.addEventListener("click", nextPage);
        prevButton.addEventListener("click", prevPage);
        window.addEventListener("resize", resizeHandler);
    });
});
