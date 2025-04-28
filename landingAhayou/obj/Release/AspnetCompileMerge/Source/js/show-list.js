document.addEventListener("DOMContentLoaded", function () {
    const lists = document.querySelectorAll(".show__list");
    const itemsPerPage = 3;

    lists.forEach((list) => {
        const elements = list.querySelectorAll(".show__element");
        const showMoreButton =
            list.nextElementSibling?.querySelector(".show-more__button");
        const showMoreButtonContainer = list.nextElementSibling;
        const displayValue = elements[0].style.display;
        let isExpanded = false;

        if (!showMoreButton || !showMoreButtonContainer) return;

        if (elements.length === itemsPerPage) {
            showMoreButtonContainer.style.display = "none";
            return;
        }

        elements.forEach((element, index) => {
            if (index === itemsPerPage - 1) {
                element.classList.add("show__more--last");
            }

            if (index >= itemsPerPage) {
                element.style.display = "none";
            }
        });

        showMoreButton.addEventListener("click", function (event) {
            event.preventDefault();

            isExpanded = !isExpanded;

            elements.forEach((e, i) => {
                if (i >= itemsPerPage) {
                    if (isExpanded) {
                        e.style.display = displayValue;
                        e.classList.add("show__visible");
                        setTimeout(
                            () => e.classList.remove("show__visible"),
                            500
                        );
                    } else {
                        e.style.display = "none";
                    }
                    e.style.display = isExpanded ? displayValue : "none";
                }

                e.classList.remove("show__more--last");
            });

            if (!isExpanded) {
                elements[itemsPerPage - 1]?.classList.add("show__more--last");
                elements[itemsPerPage - 1]?.scrollIntoView({
                    behavior: "smooth",
                    block: "end",
                });
            } else {
                elements[elements.length - 1]?.classList.add(
                    "show__more--last"
                );
            }

            showMoreButton.classList.toggle("show-more__button--rotate");
        });
    });
});
