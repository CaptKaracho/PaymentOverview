var ListView = Backbone.View.extend({
    el: "#content",
    template: "#paymentList",
    initialize: function () {
        var that = this;
        that.prepareDataManager(function (t) {
            console.dir(t);
            that.data = t;
            that.render();
        });
        DataManager.callData();
    },
    prepareDataManager: function (callback) {
        DataManager.settings.route = "http://paymentoverview.azurewebsites.net/api";
        DataManager.settings.action = "GetAllPaymentSingle";
        DataManager.settings.controller = "Payment";
        DataManager.settings.type = "GET";
        DataManager.callback = callback;
    },
    data: undefined,
    loading: function () { },
    render: function () {
        HtmlManager.template = $(this.template)[0].innerHTML;
        HtmlManager.data = this.data;

        this.$el.append(HtmlManager.draw_array());
    }
});
