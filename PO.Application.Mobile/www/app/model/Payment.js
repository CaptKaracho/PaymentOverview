var Payment = Backbone.Model.extend({
    defaults: {
        Id: 0,
        Description: '',
        PaymentGroupId: 0,
        PaymentGroupDescription: '',
        PaymentTypeId:0,
        PaymentType: '',
        PaymentDate: '',
        Price: 0,
        AddonText:''
    }
});

var PaymentList = Backbone.Collection.extend({
    model: Payment
});