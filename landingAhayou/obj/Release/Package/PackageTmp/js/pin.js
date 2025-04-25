document.addEventListener("DOMContentLoaded", function () {
    const inputContainers = document.querySelectorAll(".pin__inputs");
    const regex = /^[0-9]{1}$/;

    inputContainers.forEach((ic) => {
        const inputs = ic.querySelectorAll(".pin__input");

        inputs.forEach((input, i) => {
            input.addEventListener("input", (e) => {
                const value = e.target.value;

                if (!regex.test(value)) {
                    e.target.value = "";
                    return;
                }

                if (value.length === 1 && inputs[i + 1]) {
                    inputs[i + 1].focus();
                }
            });

            input.addEventListener("paste", (e) => {
                const paste = e.clipboardData.getData("text");

                if (!regex.test(paste)) {
                    e.preventDefault();
                    return;
                }

                if (paste.length === 1 && inputs[index + 1]) {
                    inputs[index].value = paste;
                    e.preventDefault();
                    inputs[index + 1].focus();
                }
            });

            input.addEventListener("keydown", (e) => {
                if (e.key === "Backspace") {
                    e.preventDefault();

                    if (input.value) {
                        input.value = "";
                    }

                    if (i > 0) {
                        inputs[i - 1].focus();
                    }
                }
            });
        });
    });
});
