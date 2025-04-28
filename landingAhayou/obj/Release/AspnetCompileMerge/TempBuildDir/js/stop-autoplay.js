document.addEventListener("DOMContentLoaded", function () {
    const iframes = document.querySelectorAll(".iframe__video");

    iframes.forEach((iframe) => {
        iframe.src = iframe.src + "?autoplay=false";
    });
});
