﻿using System;
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
        private bool _InstantSave { get; set; }

        #region Constructor

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

        #endregion

        #region Add

        public List<PaymentDataSingle> AddPaymentDataSingle(List<PaymentDataSingle> DataList)
        {
            List<PaymentDataSingle> _ReturnList = new List<PaymentDataSingle>();
            _InstantSave = false;
            DataList.ForEach(f =>
            {
                _ReturnList.Add(AddPaymentDataSingle(f));
            });
            RepContext.SaveChanges();
            return _ReturnList;
        }

        public PaymentDataSingle AddPaymentDataSingle(PaymentDataSingle Data)
        {
            return AddPaymentDataSingle(Data.Description, Data.Price, Data.PaymentTypeId, Data.PaymentDate, Data.AddonText, (int)Data.PaymentGroupId);
        }

        public PaymentDataSingle AddPaymentDataSingle(string Description, decimal Price, int PaymentType, DateTime Date, string AddonText, int PaymentGroup)
        {
            PAYMENT_DATA_SINGLE _NewData;

            _NewData = new PAYMENT_DATA_SINGLE()
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

            RepContext.PAYMENT_DATA_SINGLE.Add(_NewData);
            if (_InstantSave)
                RepContext.SaveChanges();

            return new PaymentDataSingle(_NewData);
        }

        public PaymentDataRecurrent AddPaymentDataRecurrent(string Description, decimal Price, int PaymentType, string PaymentDueCode, int PaymentGroup)
        {
            PAYMENT_DATA_RECURRENT _NewReturn;

            _NewReturn = new PAYMENT_DATA_RECURRENT()
            {
                DESCRIPTION = Description,
                PRICE = Price,
                PAYMENT_TYPE_ID = PaymentType,
                PAYMENT_GROUP_ID = PaymentGroup,
                DUE_CODE = PaymentDueCode,
                INSERT_AT = DateTime.Now,
                INSERT_BY = Username
            };

            RepContext.PAYMENT_DATA_RECURRENT.Add(_NewReturn);
            if (_InstantSave)
                RepContext.SaveChanges();

            return new PaymentDataRecurrent(_NewReturn);
        }

        #endregion

        #region Get

        public List<PaymentDataSingle> GetPaymentDataSingle()
        {
            List<PaymentDataSingle> _Return = new List<PaymentDataSingle>();
            _Return = RepContext
                        .PAYMENT_DATA_SINGLE
                        .Include(i => i.PAYMENT_TYPE)
                        .Include(i => i.PAYMENT_GROUP)
                        .OrderByDescending(o => o.DATE)
                        .ToList()
                        .Select(s => new BL.BLEntties.PaymentDataSingle(s)).ToList();

            return _Return;
        }

        public List<PaymentDataRecurrent> GetPaymentDataRecurrent()
        {
            List<PaymentDataRecurrent> _Return = new List<PaymentDataRecurrent>();
            _Return = RepContext
                        .PAYMENT_DATA_RECURRENT
                        .Include(i => i.PAYMENT_TYPE)
                        .Include(i => i.PAYMENT_GROUP)
                        //.Where(w => ApplicationUser
                        //                .Groups
                        //                .Select(s => s.PAYMENT_GROUP_ID).ToList()
                        //                .Contains(w.PAYMENT_GROUP_ID.GetValueOrDefault(0)))
                        .Select(s => new BL.BLEntties.PaymentDataRecurrent(s))
                        .ToList();
            return _Return;
        }

        #endregion

        #region Delete

        public void DeletePaymentDataSingle(int Id)
        {
            var _Item = RepContext
                        .PAYMENT_DATA_SINGLE
                        .FirstOrDefault(f => f.ID == Id);
            RepContext.PAYMENT_DATA_SINGLE.Remove(_Item);
        }

        public void DeletePaymentDataSingle(PaymentDataSingle RemoveData)
        {
            DeletePaymentDataRecurrent(RemoveData.Id);
        }

        public void DeletePaymentDataRecurrent(int Id)
        {
            var _Item = RepContext.PAYMENT_DATA_RECURRENT.FirstOrDefault(f => f.ID == Id);
            RepContext.PAYMENT_DATA_RECURRENT.Remove(_Item);
        }

        public void DeletePaymentDataRecurrent(PaymentDataSingle RemoveData)
        {
            DeletePaymentDataRecurrent(RemoveData.Id);
        }

        #endregion
    }
}