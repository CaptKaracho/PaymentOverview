using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PO.BL.BLEntties;
using PO.Data;
namespace PO.BL
{
    public class BLPayment : BLBase
    {
        public UserData ApplicationUser { get; set; }

        public BLPayment() : base()
        {
            this._InstantSave = true;
        }

        public BLPayment(UserData ApplicationUser) : base(ApplicationUser.User.USERNAME)
        {
            this.ApplicationUser = ApplicationUser;
            this._InstantSave = true;
        }
        public BLPayment(UserData ApplicationUser, bool InstantDataSave) : base(ApplicationUser.User.USERNAME)
        {
            this._InstantSave = InstantDataSave;
            this.ApplicationUser = ApplicationUser;
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
                INSERT_BY = Username
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
                INSERT_BY = Username
            };

            RepContext.PAYMENT_DATA_RECURRENT.Add(_Return);
            if (_InstantSave)
                RepContext.SaveChanges();

            return _Return;
        }

        public List<PAYMENT_DATA_SINGLE> GetPaymentDataSingle()
        {
            List<PAYMENT_DATA_SINGLE> _Return = new List<PAYMENT_DATA_SINGLE>();
            _Return = RepContext
                        .PAYMENT_DATA_SINGLE
                        //.Where(w => ApplicationUser
                        //                .Groups
                        //                .Select(s => s.PAYMENT_GROUP_ID).ToList()
                        //                .Contains(w.PAYMENT_GROUP_ID.GetValueOrDefault(0)))
                        .ToList();

            return _Return;
        }

        public List<PAYMENT_DATA_RECURRENT> GetPaymentDataRecurrent()
        {
            List<PAYMENT_DATA_RECURRENT> _Return = new List<PAYMENT_DATA_RECURRENT>();
            _Return = RepContext
                        .PAYMENT_DATA_RECURRENT
                        .Where(w => ApplicationUser
                                        .Groups
                                        .Select(s => s.PAYMENT_GROUP_ID).ToList()
                                        .Contains(w.PAYMENT_GROUP_ID.GetValueOrDefault(0)))
                        .ToList();
            return _Return;
        }

        public void DeletePaymentDataSingle(int Id)
        {
            var _Item = RepContext.PAYMENT_DATA_SINGLE.FirstOrDefault(f => f.ID == Id);
            RepContext.PAYMENT_DATA_SINGLE.Remove(_Item);
        }

        public void DeletePaymentDataSingle(PAYMENT_DATA_SINGLE RemoveData)
        {
            RepContext.PAYMENT_DATA_SINGLE.Remove(RemoveData);
        }

        public void DeletePaymentDataRecurrent(int Id)
        {
            var _Item = RepContext.PAYMENT_DATA_RECURRENT.FirstOrDefault(f => f.ID == Id);
            RepContext.PAYMENT_DATA_RECURRENT.Remove(_Item);
        }

        public void DeletePaymentDataRecurrent(PAYMENT_DATA_RECURRENT RemoveData)
        {
            RepContext.PAYMENT_DATA_RECURRENT.Remove(RemoveData);
        }
    }
}