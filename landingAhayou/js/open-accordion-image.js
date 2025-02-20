document.addEventListener("DOMContentLoaded", function () {
    const details = document.querySelectorAll(".frequent-questions__detail");
    const img = document.getElementById("frequentQuestionsImg");

    function checkDetailsState() {
        const screenWidth = window.innerWidth;

        for (let i = 0; i < details.length; i++) {
            if (details[i].open && screenWidth < 1280) {
                img.style.display = "none";
                break;
            } else {
                img.style.display = "block";
            }
        }
    }

    details.forEach((d) => {
        d.addEventListener("toggle", checkDetailsState);
    });

    window.addEventListener("resize", checkDetailsState);
});
