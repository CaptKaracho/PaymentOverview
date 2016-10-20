var LoadView = Backbone.View.extend({
    tagName: 'div',
    myTemplate: null,
    initialize: function () {
        this.myTemplate = _.template($("#preLoad").html());
        this.render();
    },
    render: function () {
        this.$el.html(this.myTemplate());
        return this;
    }
});