

var SliderManager = (function () {
    var manager = {
        slider: "",
        visible: false,
        showSlider: function () {
            if (this.slider == "")
                console.dir("slider not set");
            if (this.visible == false) {
                this.visible = true;
                $(this.slider).addClass("show");
                $(this.slider).removeClass("hide");
            }
        },

        hideSlider: function () {
            if (this.slider == "")
                console.dir("slider not set");
            if (this.visible == true) {
                this.visible = false;
                $(this.slider).removeClass("show");
                $(this.slider).addClass("hide");
            }
        }
    };
    return manager;

})();

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
            '': 'preLoad',
            'paymentList': 'paymentToday',
            'paymentToday': 'paymentToday',
            'paymentWeek': 'paymentWeek',
            'paymentMonth': 'paymentMonth',
            'paymentAdd': 'paymentNew'
        },

        initialize: function () {
            this.container = new ContainerView();
        },

        preLoad: function () {
            var that = this;
            this.view = new LoadView();
            this.container.childView = this.view;
            this.container.render();

            DataHandler.getResourceDataGroups(function (t) {
                DataStorage.groups = t;
            });
            DataHandler.getResourceDataTypes(function (t) {
                DataStorage.types = t;
            });

            DataHandler.onReady(function () {
                that.view = new PaymentNew();

                that.container.childView = that.view;
                setTimeout(function () {
                    that.container.render();
                }, 3000);
            });



        },
        paymentToday: function () {
            var that = this;
            DataHandler.getPayment(1, function (t) {
                console.dir(t);
                that.view = new PaymentListView({ collection: new PaymentList(t) });
                that.container.childView = that.view;
                that.container.render();
            });
        },
        paymentWeek: function () {
            var that = this;
            DataHandler.getPayment(2, function (t) {
                console.dir(t);
                that.view = new PaymentListView({ collection: new PaymentList(t) });
                that.container.childView = that.view;
                that.container.render();
            });
        },
        paymentMonth: function () {
            var that = this;
            DataHandler.getPayment(3, function (t) {
                console.dir(t);
                that.view = new PaymentListView({ collection: new PaymentList(t) });
                that.container.childView = that.view;
                that.container.render();
            });
        },
        paymentNew: function () {
            this.view = new PaymentNew({ groups: DataStorage.Groups });
            this.container.childView = this.view;
            this.container.render();
        }
    });

    var route = new myRouter();
    Backbone.history.start();


};
Application.prototype.sliderManager = SliderManager;