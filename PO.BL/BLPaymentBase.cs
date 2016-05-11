using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PO.BL.BLEntties;
using PO.BL;
using PO.Data;
namespace PO.BL
{
    public class BLPaymentBase : BLBase
    {
        public BLPaymentBase() : base() { }

        public BLPaymentBase(string User) : base(User) { }
        public BLPaymentBase(string User, bool InstantDataSave) : base(User)
        {
            this._InstantSave = InstantDataSave;
        }

        private bool _InstantSave { get; set; }

        public List<PAYMENT_DATA_SINGLE> AddPaymentDataSingle(List<PAYMENT_DATA_SINGLE> DataList)
        {
            List<PAYMENT_DATA_SINGLE> _ReturnList = new List<PAYMENT_DATA_SINGLE>();
            _InstantSave = false;
            DataList.ForEach(f =>
            {
                _ReturnList.Add(AddPaymentDataSingle(f.DESCRIPTION, f.PRICE, f.PAYMENT_TYPE_ID, f.DATE, f.ADDON_TEXT, (int)f.PAYMENT_GROUP_ID));
            });
            RepContext.SaveChanges();
            return _ReturnList;
        }

        public PAYMENT_DATA_SINGLE AddPaymentDataSingle(PAYMENT_DATA_SINGLE Data)
        {
            return AddPaymentDataSingle(Data.DESCRIPTION, Data.PRICE, Data.PAYMENT_TYPE_ID, Data.DATE, Data.ADDON_TEXT, (int)Data.PAYMENT_GROUP_ID);
        }

        public PAYMENT_DATA_SINGLE AddPaymentDataSingle(string Description, decimal Price, int PaymentType, DateTime Date, string AddonText, int PaymentGroup)
        {
            PAYMENT_DATA_SINGLE _Return;

            _Return = new PAYMENT_DATA_SINGLE()
            {
                DESCRIPTION = Description,
                PRICE = Price,
                PAYMENT_TYPE_ID = PaymentType,
                DATE = Date,
                ADDON_TEXT = AddonText,
                PAYMENT_GROUP_ID = PaymentGroup,
                INSERT_AT = DateTime.Now,
                INSERT_BY = User
            };

            RepContext.PAYMENT_DATA_SINGLE.Add(_Return);
            if (_InstantSave)
                RepContext.SaveChanges();

            return _Return;
        }

        public PAYMENT_DATA_RECURRENT AddPaymentDataRecurrent(string Description, decimal Price, int PaymentType, string PaymentDueCode, int PaymentGroup)
        {
            PAYMENT_DATA_RECURRENT _Return;

            _Return = new PAYMENT_DATA_RECURRENT()
            {
                DESCRIPTION = Description,
                PRICE = Price,
                PAYMENT_TYPE_ID = PaymentType,
                PAYMENT_GROUP_ID = PaymentGroup,
                DUE_CODE = PaymentDueCode,
                INSERT_AT = DateTime.Now,
                INSERT_BY = User
            };



            RepContext.PAYMENT_DATA_RECURRENT.Add(_Return);
            if (_InstantSave)
                RepContext.SaveChanges();

            return _Return;
        }
    }
}
