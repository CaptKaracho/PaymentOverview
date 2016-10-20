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
    groups: [],
    types: [],
    myTemplate: null,
    initialize: function () {
        this.myTemplate = _.template($("#newPayment").html());
        this.groups = DataStorage.groups;
        this.types = DataStorage.types;
        this.render();
    },
    render: function () {
        console.dir(this.groups);
        this.$el.html(this.myTemplate({ groups: this.groups, types: this.types }));
    }
});