function clone(obj) {
    if (null == obj || "object" != typeof obj)
        return obj;
    var copy = obj.constructor();
    for (var attr in obj) {
        if (obj.hasOwnProperty(attr))
            copy[attr] = obj[attr];
    }
    return copy;
}

var DataManager = (function (document) {


    if (typeof jQuery === 'undefined') {
        console.dir("Lib Error: jQuery is not implemented.");
    }

    var dataManager = {};
    dataManager.events = {
        ajaxLoadReady: {
            name: "ajaxLoadReady",
            event: new Event("ajaxLoadReady")
        },
        ajaxLoadStart: {
            name: "ajaxLoadStart",
            event: new Event("ajaxLoadStart")
        }

    };
    dataManager.settings = {
        type: "",
        route: "",
        controller: "",
        action: "",
        id: ""
    };

    dataManager.reset = function () {
        this.callback = undefined;
    }
    dataManager.callback = null;
    dataManager.dataParameter = null;
    dataManager.queue = [];
    dataManager.uniqueRequestId = 0;

    dataManager.callData = function () {
        var that = this;
        document.dispatchEvent(that.events.ajaxLoadStart.event);

        that.uniqueRequestId = generateGuid();

        var _NewId = clone(that.uniqueRequestId);

        var _NewData = {
            callback: clone(that.callback),
            settings: clone(that.settings),
            parameter: clone(that.dataParameter)
        };

        this.queue.push({ id: _NewId, data: _NewData });

        if (jQuery === undefined) {
            console.dir("JQUERY ist nicht geladen oder ist nicht eingebunden");
        }

        var url = this.settings.route;

        if (this.settings.controller != undefined && this.settings.controller != "")
            url += "/" + this.settings.controller;
        if (this.settings.action != undefined && this.settings.action != "")
            url += "/" + this.settings.action;
        if (this.settings.id != undefined && this.settings.id != "")
            url += "/" + this.settings.id;

        $.ajax({
            type: this.settings.type,
            url: url,
            contentType: "application/json; charset=utf-8",
            data: function () {
                if (dataManager.dataParameter != undefined && dataManager.dataParameter != "" && dataManager.dataParameter != {})
                    return JSON.stringify(dataManager.dataParameter);
                else
                    return null;
            }(),
            dataType: "json",
            success: function (e) {

                var curReqData = getElementInArrayWithObjectId(that.queue, _NewId)[0];
                console.dir(curReqData);

                if (curReqData.data !== undefined) {

                    if (curReqData.data.callback !== undefined) {

                        curReqData.data.callback(e);
                    }
                }
                that.queue = removeElementInArrayWithObjectId(that.queue, _NewId);
                document.dispatchEvent(that.events.ajaxLoadReady.event);
            },
            error: function (data) {
                console.dir({
                    "Status": "error",
                    "data": data,
                    "requestData": getElementInArrayWithObjectId(that.queue, _NewId)[0]
                });

                that.queue = removeElementInArrayWithObjectId(that.queue, _NewId);
                document.dispatchEvent(that.events.ajaxLoadReady.event);
            }
        });
    };


    function queueRound(callback, intervall) {
        if (dataManager.queue !== undefined && dataManager.queue.length > 0) {
            setTimeout(function () {
                console.dir("Wait for all Ajax Ready..");
                queueRound(callback, intervall);
            }, intervall);
        }
        else {
            //event alll Ready
            callback();

        }
    }
    dataManager.onDataLoadReady = function (callback) {

        queueRound(callback, 500);
        
    }

    dataManager.isDataLoadReady = function () {
        if (dataManager.queue !== undefined && dataManager.queue.length > 0)
            return false;
        else
            return true;
    }

    return dataManager;
})(document);