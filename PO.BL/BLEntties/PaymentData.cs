using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.BL.BLEntties
{
    public class PaymentData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PaymentGroupId { get; set; }
        public string PaymentGroup { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
    }


    public class PaymentDataSingle : PaymentData
    {
        public System.DateTime PaymentDate { get; set; }
        public string AddonText { get; set; }

        public PaymentDataSingle() { }
        public PaymentDataSingle(Data.PAYMENT_DATA_SINGLE Data)
        {
            this.Id = Data.ID;
            this.Description = Data.DESCRIPTION;
            this.Price = Data.PRICE;
            this.PaymentDate = Data.DATE;
            this.AddonText = Data.ADDON_TEXT;

            this.PaymentGroupId = Data.PAYMENT_GROUP_ID.GetValueOrDefault(0);
            if (Data.PAYMENT_GROUP != null)
                this.PaymentGroup = Data.PAYMENT_GROUP.DESCRIPTION;

            this.PaymentTypeId = Data.PAYMENT_TYPE_ID.GetValueOrDefault(0);
            if (Data.PAYMENT_TYPE != null)
                this.PaymentType = Data.PAYMENT_TYPE.DESCRIPTION;
        }

    }

    public class PaymentDataRecurrent : PaymentData
    {
        public string DueCode { get; set; }

        public PaymentDataRecurrent() { }
        public PaymentDataRecurrent(Data.PAYMENT_DATA_RECURRENT Data)
        {
            this.Id = Data.ID;
            this.Description = Data.DESCRIPTION;
            this.Price = Data.PRICE;
            this.DueCode = Data.DUE_CODE;

            this.PaymentGroupId = Data.PAYMENT_GROUP_ID.GetValueOrDefault(0);
            if (Data.PAYMENT_GROUP != null)
                this.PaymentGroup = Data.PAYMENT_GROUP.DESCRIPTION;

            this.PaymentTypeId = Data.PAYMENT_TYPE_ID.GetValueOrDefault(0);
            if (Data.PAYMENT_TYPE != null)
                this.PaymentType = Data.PAYMENT_GROUP.DESCRIPTION;

        }

    }
}
