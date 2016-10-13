var Application = function () {
    var ContainerView = Backbone.View.extend({
        el: '#contentView',
        childView: null,

        render: function () {
            console.dir("render container");
            //console.dir(this.$el);
            this.$el.append(this.childView.$el);
            return this;
        }
    });

    var myRouter = Backbone.Router.extend({

        container: null,
        view: null,
        routes: {
            '': 'paymentList',
            'paymentList': 'paymentList',
            'temp':'paymentList'
        },

        initialize: function () {
            this.container = new ContainerView();
        },

        paymentList: function () {

            this.view = new PaymentListView();
            this.container.childView = this.view;
            this.container.render();
        }
    });

    var route = new myRouter();
    Backbone.history.start();
};