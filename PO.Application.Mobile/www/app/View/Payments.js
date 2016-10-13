var PaymentView = Backbone.View.extend({
    tagName: 'li',
    myTemplate: null,
    initialize: function () {
        this.myTemplate = _.template("<%=Description%>");
 this.render();
    },
    render: function () {

        this.$el.html(this.myTemplate(this.model.toJSON()));
        return this;
    }
});

var PaymentListView = Backbone.View.extend({
    tagName: 'ul',
    collection: null,
    initialize: function () {
        
        this.myTemplate = _.template($("#details").html());
        var that = this;
        that.prepareDataManager(function (t) {
            that.collection = new PaymentList(t);
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

    render: function () {
        console.dir(this.collection);
        this.$el.html(this.myTemplate({ collection: this.collection.toJSON()}));

       
        return this;
    }
});
