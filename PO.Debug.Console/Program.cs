using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PO.Data.BL;
using PO.Data.BL.BLEntties;
using PO.Data;


namespace PO.Debug.Console
{
    class Program
    {
        static void Main(string[] args)
        {





            //BLUser _BlUser = new BLUser();
            //var _DebugUser = _BlUser.Login("m.nagel", "1234");

            BLPayment _Bl = new BLPayment();

            //_Bl.AddPaymentDataSingle(new PaymentDataSingle()
            //{
            //    Description = "neu",
            //    PaymentTypeId = 2,
            //    PaymentGroupId = 1,
            //    PaymentDate = DateTime.Now,
            //    Price = 234
            //});
            //var _D = _Bl.GetResourceData(0);

            var _Data = _Bl.GetPaymentDataSingle(1);

            if (_Data.Count == 0)
            {
                _Bl.AddPaymentDataSingle(new PaymentDataSingle()
                {
                    PaymentDate = DateTime.Now,
                    Description = "Test Bezahlung",
                    Price = 200,
                    PaymentTypeId = 1,
                    PaymentGroupId = 1
                });
            }

        }
    }
}
