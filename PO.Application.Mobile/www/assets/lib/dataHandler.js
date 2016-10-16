var DataHandler = (function ($, dataManager) {

    if (typeof dataManager === 'undefined') {
        console.dir("Lib Error: DataManger is not implemented.");
    }

    var dataHandler = {};


    dataHandler.getPayment = function (callback) {
        DataManager.settings.route = "http://paymentoverview.azurewebsites.net/api";
        DataManager.settings.action = "GetAllPaymentSingle";
        DataManager.settings.controller = "Payment";
        DataManager.settings.type = "GET";
        DataManager.callback = callback;
        DataManager.callData();


        console.dir("fired BItch");
    };


    dataHandler.addPayment = function (data, callback) {
        console.dir("ok");
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

    return dataHandler;
})(jQuery, DataManager);