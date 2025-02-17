document.addEventListener("DOMContentLoaded", function () {
    const webAppSection = document.getElementById("webAppSection");
    const downloadContainer = document.getElementById("downloadContainer");
    const downloadTitle = document.getElementById("downloadTitle");

    function showDownloadTitle() {
        const screenWidth = window.innerWidth;

        if (screenWidth >= 1024) {
            if (downloadTitle.parentElement !== downloadContainer) {
                downloadContainer.insertBefore(
                    downloadTitle,
                    downloadContainer.firstChild
                );
                downloadTitle.innerHTML = "Descarga la Web APP";
            }
        } else {
            if (downloadTitle.parentElement !== webAppSection) {
                webAppSection.insertBefore(
                    downloadTitle,
                    webAppSection.firstChild
                );
                downloadTitle.innerHTML =
                    "<span>Descarga la</span>&nbsp;<span>Web APP</span>";
            }
        }
    }

    showDownloadTitle();

    window.addEventListener("resize", showDownloadTitle);
});
