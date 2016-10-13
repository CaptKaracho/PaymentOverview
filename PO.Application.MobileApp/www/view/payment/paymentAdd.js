var PaymentAdd = Backbone.View.extend({
    el: "#content",
    template: "#paymentAdd",
    initialize: function () {
        this.render();
    },
    loading: function () { },

    button: "#button",
    list: "#paymentAdd_list",

    showDataList: function () {
        
    },
    hideDataList: function () { },

    render: function () {
        HtmlManager.template = $(this.template)[0].innerHTML;
        HtmlManager.data = undefined;

        this.$el.append(HtmlManager.draw());
    }
});
