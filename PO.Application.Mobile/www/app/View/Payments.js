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
    tagName: 'div',
    collection: null,
    initialize: function () {
        this.myTemplate = _.template($("#details").html());
        this.render();
    },
    render: function () {
        this.$el.html(this.myTemplate({ collection: this.collection.toJSON() }));
        return this;
    }
});
var PaymentNew = Backbone.View.extend({
    myTemplate: null,
    initialize: function () {
        this.myTemplate = _.template($("#newPayment").html());
        this.render();
    },
    render: function () {
        this.$el.html(this.myTemplate());
    }
});