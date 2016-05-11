/// <reference path="../../common/jquery-1.11.0.min.js" />
/// <reference path="../Json/JBaseComponents.js" />
/// <reference path="../Json/JModules.js" />
/// <reference path="../Json/JControls.js" />



var CMControler = (function (document) {

    function contentElement(pIsLoading, pDestination, pElement) {
        this.isLoading = pIsLoading;
        this.destination = pDestination;
        this.element = pElement;
        this.id = 0;
        this.idName = "";
    };

    var contentStack = {
        isLoading: false,
        contentElements: [],
        addElement: function (element) {
            element.id = this.contentElements.length;
            element.idName = element.element.name + element.id;
            this.contentElements.push(element);
        },
        checkElementsLoaded: function () {
            var isLoadingFinish = $.each(this.contentElements, function (key, value) {

                if (value.isLoading == true) {
                    return false;
                }

            });
            if (isLoadingFinish == false) {
                contentStack.isLoading = true;
            }
            else {
                contentStack.isLoading = false;
            }
        }
    };




    function rotator(rotatingElemenet) {
        this.element = rotatingElemenet;
        this.degree = 0;
        this.minRotationSteps = 10;
        this.curRotationStep = 0;
        this.isRotation = false;

        function rotate(that) {
            if (that.isRotation === true) {
                that.curRotationStep += 1;
                setTimeout(function () {
                    if (that.degree > 360)
                        that.degree = 0;

                    $(that.element).css({
                        '-webkit-transform': 'rotate(' + that.degree + 'deg)',
                        '-moz-transform': 'rotate(' + that.degree + 'deg)',
                        '-ms-transform': 'rotate(' + that.degree + 'deg)',
                        'transform': 'rotate(' + that.degree + 'deg)'
                    });
                    that.degree += 15;

                    rotate(that);
                }, 50);
            }

        };

        this.startRotation = function () {
            var that = this;

            this.isRotation = true;

            rotate(that);

        };
        this.stopRotation = function () {
            this.isRotation = false;
        };


    };

    var loadingElement;

    function activateLoading(loader) {
        loadingElement = new rotator(loader);
        loadingElement.startRotation();

        $(loader).removeClass("hidden");

    }

    function disableLoading(loader) {
        if (loadingElement.curRotationStep <= loadingElement.minRotationSteps) {

            setTimeout(function () {
                disableLoading(loader)
            }, 50);
        }
        else {
            loadingElement.stopRotation();
            $(loader).addClass("hidden");
        }
    }


    function navigateBaseComponent(pComponent, pModul) {
        loadModule(pModul, pComponent.id, false, true);

    };

    function loadModule(pModule, pDestinatin, pIsLoading, pIsComponentNav) {
        var newElement;
        // console.dir(pModule);
        if (pIsComponentNav != true) {
            newElement = new contentElement(true, pDestinatin, pModule);
            contentStack.addElement(newElement);
        }


        if (pIsLoading === true) {
            //console.dir("loading");
            ////activateLoading(newElement);
        }
       
            
        $.getScript(pModule.fileJs.path, function (data, textStatus, jqxhr) {
            $('body').append($('<link rel="stylesheet" type="text/css" />').attr('href', pModule.filesCss.path));
            $("#" + pDestinatin).load(pModule.fileHtml.path);
        });
        
        if (pIsLoading === true) {
            //disableLoading(newElement);
        }


    };

    function loadControl(pControl, pDestination) {
        $.getScript(pModule.fileJs.path, function (data, textStatus, jqxhr) {
            $('body').append($('<link rel="stylesheet" type="text/css" />').attr('href', pModule.filesCss.path));
            $("#" + pDestinatin).load(pModule.fileHtml.path);
        });
    }

    return {
        navigateBaseComponent: function (pComponent, pModul) { navigateBaseComponent(pComponent, pModul); },
        loadModule: function (pModule, pDestinatin, pIsLoading) {
            loadModule(pModule, pDestinatin, pIsLoading);
        },
        loadControl: function (pControl, pDestination) { loadModule(pControl, pDestination); },
        activateLoading: function (pContainer) { activateLoading(pContainer); },
        disableLoading: function (pContainer) { disableLoading(pContainer); },
        getElementStack: function () { return contentStack; }


    };
})();