document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("form");
    const submitButton = form.querySelector('input[type="submit"]');
    const alert = document.querySelector(".alert");


    submitButton.addEventListener("click", function (e) {
        e.preventDefault();
        
        if (alert && !alert.classList.contains("alert--show")) {
            alert.classList.add("alert--show");
        }
    });
});
