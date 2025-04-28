document.addEventListener("DOMContentLoaded", () => {
    const containers = document.querySelectorAll(
        ".movie__container:not(.movie__container--second)"
    );

    function applyEffect() {
        if (window.innerHeight <= 500) {
            containers.forEach((container) => {
                const firstChild =
                    container.querySelector("div:nth-of-type(1)");
                const secondChild =
                    container.querySelector("div:nth-of-type(2)");

                if (firstChild) {
                    firstChild.style.transform = "translateY(0)";
                    firstChild.style.transition = "transform 0.75s ease";
                }
                if (secondChild) {
                    secondChild.style.opacity = 1;
                }
            });
            return;
        }

        containers.forEach((container) => {
            const firstChild = container.querySelector("div:nth-of-type(1)");
            const secondChild = container.querySelector("div:nth-of-type(2)");

            if (firstChild && secondChild) {
                let parentHeight = secondChild.scrollHeight;

                firstChild.style.transform = `translateY(${parentHeight}px)`;

                const onMouseEnter = () => {
                    firstChild.style.transform = "translateY(0)";
                    firstChild.style.transition = "transform 0.75s ease";
                    if (secondChild) {
                        secondChild.style.opacity = 1;
                    }
                };

                const onMouseLeave = () => {
                    if (window.innerHeight <= 500) {
                        return;
                    }
                    firstChild.style.transform = `translateY(${parentHeight}px)`;
                    if (secondChild) {
                        secondChild.style.opacity = 0;
                    }
                };

                container.addEventListener("mouseenter", onMouseEnter);
                container.addEventListener("mouseleave", onMouseLeave);

                container.addEventListener("touchstart", (e) => {
                    e.preventDefault();
                    onMouseEnter();
                });

                container.addEventListener("touchend", () => {
                    onMouseLeave();
                });

                new ResizeObserver(() => {
                    const isMaxHeight = window.innerHeight > 500;
                    parentHeight = secondChild.scrollHeight;

                    if (firstChild) {
                        firstChild.style.transform = isMaxHeight
                            ? `translateY(${parentHeight}px)`
                            : `translateY(0)`;
                    }

                    if (secondChild) {
                        secondChild.style.opacity = isMaxHeight ? 0 : 1;
                    }
                }).observe(secondChild);
            }
        });
    }

    applyEffect();

    window.addEventListener("resize", applyEffect);
});
