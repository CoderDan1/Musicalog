(function () {

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function randomizeHeaderColour() {
        var element = document.querySelector(".disco-line");

        var r = getRandomInt(0, 255);
        var g = getRandomInt(0, 255);
        var b = getRandomInt(0, 255);

        element.style.backgroundColor = "rgb(" + r + "," + g + "," + b + ")";
    }

    document.addEventListener("DOMContentLoaded", function () {
        randomizeHeaderColour();
        setInterval(randomizeHeaderColour, 1500);

        var parameters = new URLSearchParams(window.location.search);
        var direction = parameters.get("SortDirection");
        var page = parameters.get("Page");
        var pageSize = parameters.get("PageSize");
        var sort = parameters.get("Sort");

        document.querySelectorAll("[data-sort]").forEach(function (header) {
            var newSort = header.dataset.sort;

            var sortUp = header.querySelector(".bi-sort-up");
            var sortDown = header.querySelector(".bi-sort-down");

            if (direction === "Ascending" || newSort != sort) {
                sortDown.classList.add("d-none");
            }

            if (direction === "Descending" || newSort != sort) {
                sortUp.classList.add("d-none");
            }

            header.addEventListener("click", function (e) {
                e.preventDefault();
                e.stopPropagation();
                window.location = '/?Page=' + page + '&PageSize=' + pageSize + '&SortDirection=' + (direction === "Ascending" ? "Descending" : "Ascending") + '&Sort=' + newSort;
            })
        });

        document.querySelectorAll("[data-navigate]").forEach(function (navButton) {
            navButton.addEventListener("click", function (e) {
                e.preventDefault();
                e.stopPropagation();

                window.location = e.currentTarget.dataset.navigate;
            });
        })
    })

})();