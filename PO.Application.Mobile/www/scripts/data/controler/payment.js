/// <reference path="../appData.js" />
/// <reference path="../json/jsonData.js" />

function loadLocalPayment() {
    var data = LocalDataManager.loadData("paymentData");
    
    console.dir(data);


    return data;
};

function saveLocalPayment(data) {
    LocalDataManager.saveData('paymentData', data);
};

