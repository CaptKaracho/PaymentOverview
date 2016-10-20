var DataHandler = (function ($, dataManager) {

    if (typeof dataManager === 'undefined') {
        console.dir("Lib Error: DataManger is not implemented.");
    }

    var dataHandler = {};

    dataHandler.getResourceDataGroups = function (callback) {
        DataManager.settings.route = "http://paymentoverview.azurewebsites.net/api";
        DataManager.settings.action = "GetResourceDataGroups";
        DataManager.settings.controller = "Base";
        DataManager.settings.type = "GET";
        DataManager.settings.id = "";
        DataManager.callback = callback;
        DataManager.callData();
    };
    dataHandler.getResourceDataTypes = function (callback) {
        DataManager.settings.route = "http://paymentoverview.azurewebsites.net/api";
        DataManager.settings.action = "GetResourceDataTypes";
        DataManager.settings.controller = "Base";
        DataManager.settings.type = "GET";
        DataManager.settings.id = "";
        DataManager.callback = callback;
        DataManager.callData();
    };

    dataHandler.getPayment = function (granularity, callback) {
        DataManager.settings.route = "http://paymentoverview.azurewebsites.net/api";
        DataManager.settings.action = "GetPaymentSingleGranularity";
        DataManager.settings.controller = "Payment";
        DataManager.settings.type = "GET";
        DataManager.settings.id = granularity;

        DataManager.callback = callback;
        DataManager.callData();
    };
    dataHandler.addPayment = function (data, callback) {
        console.dir("ok");
        dataManager.settings.id = "";
        DataManager.settings.route = "http://paymentoverview.azurewebsites.net/api";
        DataManager.settings.action = "AddPaymentSingle";
        DataManager.settings.controller = "Payment";
        DataManager.settings.type = "POST";
        DataManager.dataParameter = {
            Description: data.description,
            Price: data.price,
            PaymentTypeId: data.typeId,
            AddonText: data.addonText,
            PaymentGroupId: data.groupId
        };
        DataManager.callback = callback;
        DataManager.callData();



    };


    dataHandler.onReady = function (callback) { dataManager.onDataLoadReady(callback); }
    return dataHandler;
})(jQuery, DataManager);