using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PO.BL;

namespace PO.Debug.Console
{
    class Program
    {
        static void Main(string[] args)
        {



            

            BLUser _BlUser = new BLUser();
            var _DebugUser = _BlUser.Login("m.nagel", "1234");

            BL.BLPayment _Bl = new BL.BLPayment(_DebugUser);

            var _Data = _Bl.GetPaymentDataSingle();

            if (_Data.Count == 0)
            {
                _Bl.AddPaymentDataSingle(new BL.BLEntties.PaymentDataSingle()
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
