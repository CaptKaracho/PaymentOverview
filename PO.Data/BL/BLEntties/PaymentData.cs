using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.Data.BL.BLEntties
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
        public PaymentDataSingle(Data.EF.PAYMENT_DATA_SINGLE Data)
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

        public PaymentDataSingle(System.Data.IDataReader Reader)
        {
            if (Reader.FieldCount >= 1 && Reader[0] != null)
                this.Id = Reader.GetInt32(0);
            if (Reader.FieldCount >= 2 && Reader[1] != null)
                this.Description = Reader.GetString(1);
            if (Reader.FieldCount >= 3 && Reader[2] != null)
                this.Price = Reader.GetDecimal(2);
            if (Reader.FieldCount >= 4 && Reader[3] != null)
                this.PaymentGroupId = Reader.GetInt32(0);
            if (Reader.FieldCount >= 5 && Reader[4] != null)
                this.PaymentGroup = Reader.GetString(4);
            if (Reader.FieldCount >= 6 && Reader[5] != null)
                this.PaymentTypeId = Reader.GetInt32(5);
            if (Reader.FieldCount >= 7 && Reader[6] != null)
                this.PaymentType = Reader.GetString(6);

            if (Reader.FieldCount >= 8 && Reader[7] != null)
                this.PaymentDate = Reader.GetDateTime(7);
            if (Reader.FieldCount >= 9 && Reader[8] != null)
                this.AddonText = Reader.GetString(8);
        }
    }

    public class PaymentDataRecurrent : PaymentData
    {
        public string DueCode { get; set; }

        public PaymentDataRecurrent() { }
        public PaymentDataRecurrent(Data.EF.PAYMENT_DATA_RECURRENT Data)
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
