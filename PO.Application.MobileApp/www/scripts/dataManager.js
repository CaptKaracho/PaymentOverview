var dataManager = (function () {

    var dataManager = {};
    dataManager.settings = {
        httpMethod: "POST",
        route: "",
        controller: "",
        action: "",
        id: ""
    };
    dataManager.dataParameter = {};
    dataManager.callback = undefined;

    dataManager.callData = function () {

        if (jQuery === undefined) {
            console.dir("JQUERY ist nicht geladen oder ist nicht eingebunden");
        }

        var url = this.settings.route + "/" + this.settings.controller;
        if (this.settings.action != "")
            url += "/" + this.settings.action;
        if (this.settings.id != undefined && this.settings.id != "")
            url += "/" + this.settings.id;
        
        $.ajax({
            type: this.settings.type,
            url: url,
            method:this.settings.httpMethod,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(this.dataParameter),
            dataType: "json",
            crossDomain: true,
            beforSend: function (xhr) {
                xhr.overrideMimeType("test/playin");
            }

        })
            .error(function (e) { console.dir(e);})
        .success(function (e) {

            if (dataManager.callback !== undefined)
                dataManager.callback(e);
        });


    };

    return dataManager;

})();