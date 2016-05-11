/// <reference path="../../../data/controler/payment.js" />

function loadProcess() {
    alert("load");
    renderLocalData();
};


var Process = {


    saveLocalData: function () {
        var input = { data: document.getElementById("testinput").value };

        if (input.data != undefined && input.data != "") {
            saveLocalPayment(input);
            this.renderLocalData();
        }
    },

    renderLocalData: function () {
        var show = document.getElementById("dataArea");
        //console.dir(loadPaymentData());
        var renderData = loadLocalPayment();
        var list = "<ul>";
        console.dir(renderData);
        $.each(renderData, function (key, value) { list = list + '<li>' + value.data + '</li>' });
        list = list + '</ul>;'
        show.innerHTML = list;
    }
};