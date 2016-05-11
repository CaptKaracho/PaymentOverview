/// <reference path="../Json/JBaseComponents.js" />

var ScreenOrientation = { landscape: 1, portrait: 2 };

var MobileApplication = function ( $, cmControler) {
    var cmControler = cmControler;
};

MobileApplication.prototype.toggleSlider = function () {
    var slider = $("#" + JBaseComponents.components.slider.wrapper);
    if (this.isSliderActivated === false) {
        this.isSliderActivated = true;
        document.getElementById("overlap").style.zIndex = "800";
    }
    else {
        this.isSliderActivated = false;
        document.getElementById("overlap").style.zIndex = "1";
    }

    $(slider).toggleClass("slider_visible", 300);
};

MobileApplication.prototype.isSliderActivated = false;

MobileApplication.prototype.screenOrientation = 0;

MobileApplication.prototype.resolution = { width: 0, height: 0 }

MobileApplication.prototype.getOrientation = function (window) {
    this.resolution.width = window.innerWidth;
    this.resolution.height = window.innerHeight;

    if (this.resolution.width > this.resolution.height)
        this.screenOrientation = ScreenOrientation.landscape;
    else
        this.screenOrientation = ScreenOrientation.portrait;
};

MobileApplication.prototype.test = (function () {
    $("#" + JBaseComponents.components.content.wrapper).click(function () {
        console.dir("click content component");
    });
})();

