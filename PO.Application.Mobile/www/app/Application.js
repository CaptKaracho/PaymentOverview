var Application = function () {
    var ContainerView = Backbone.View.extend({
        el: '#contentView',
        childView: null,

        render: function () {
            console.dir("render container");
            
            //console.dir(this.$el);
            this.$el.html(this.childView.$el);
            return this;
        }
    });

    var myRouter = Backbone.Router.extend({

        container: null,
        view: null,
        routes: {
            '':'paymentNew',
            'paymentList': 'paymentList',
            'paymentAdd': 'paymentNew'
        },

        initialize: function () {
            this.container = new ContainerView();
        },

        paymentList: function () {

            this.view = new PaymentListView();
            this.container.childView = this.view;
            this.container.render();
        },
        paymentNew: function () {

            
            this.view = new PaymentNew();
            this.container.childView = this.view;
            this.container.render();
        }
    });

    var route = new myRouter();
    Backbone.history.start();
};