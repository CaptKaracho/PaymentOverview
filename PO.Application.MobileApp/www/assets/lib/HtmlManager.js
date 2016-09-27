var HtmlManager = (function () {

    if (typeof Mustache === 'undefined') {

        console.dir("Lib Error: Mustache is not implemented, get Grow some.");
    }
    if (typeof jQuery === 'undefined') {

        console.dir("Lib Error: jQuery is not implemented.");
    }


    var formationHtmlType = {
        none: 0,
        li: 1,
        div: 2

    };

    var htmlManager = {};

    htmlManager.get_formationHtmlTypes = function () {
        return formationHtmlType;
    };
    htmlManager.template = undefined;
    htmlManager.data = [];

    htmlManager.elementsFormationType = formationHtmlType.none;
    htmlManager.elementClasses = [];

    htmlManager.draw_object = function () {
        return Mustache.to_html(this.template, { obj: this.data });
    };

    htmlManager.draw_array = function () {
        return Mustache.to_html(this.template, { arr: this.data });
    };

    return htmlManager;

})();