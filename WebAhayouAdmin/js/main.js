var installPromptEvent, count = 0, btnInstall = document.querySelector("#install"),
    easter_egg = new Konami(function () {
        window.location.href = "https://ahayou.bo"
    });

document.body.addEventListener("click", function () {
    ++count > 6 && (count = 0, document.querySelector(".tooltip").classList.toggle("show"), setTimeout(function () {
        document.querySelector(".tooltip").classList.toggle("show")
    }, 2e3))
}), window.addEventListener("beforeinstallprompt", function (t) {
    t.preventDefault(), installPromptEvent = t, btnInstall.removeAttribute("disabled")
}), btnInstall.addEventListener("click", function () {
    btnInstall.setAttribute("disabled", ""), installPromptEvent.prompt(), installPromptEvent.userChoice.then(function (t) {
        "accepted" === t.outcome ? console.log("User accepted the A2HS prompt") : console.log("User dismissed the A2HS prompt"), installPromptEvent = null
    })
});