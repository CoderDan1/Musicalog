(function () {

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function randomizeHeaderColour() {
        var element = document.querySelector(".disco-line");

        //generate random red, green and blue intensity
        var r = getRandomInt(0, 255);
        var g = getRandomInt(0, 255);
        var b = getRandomInt(0, 255);

        element.style.backgroundColor = "rgb(" + r + "," + g + "," + b + ")";
    }

    document.addEventListener("DOMContentLoaded", function () {
        randomizeHeaderColour();
        setInterval(randomizeHeaderColour, 1500);
    })

})();