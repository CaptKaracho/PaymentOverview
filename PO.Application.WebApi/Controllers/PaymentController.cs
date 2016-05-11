using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PO.Application.WebApi.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
         [Route("GetAllPaymentSingleTest")]
        [HttpPost]
        public string GetPayment()
        {
             return "PaymentSIngle OK";
        }

        //TODO: applicationUser in session ausslagern
        [Route("GetAllPaymentSingle")]
        [HttpPost]
        public string GetPayment(BL.BLEntties.UserData ApplicationUser)
        {
            using (PO.BL.BLPayment _Proxy = new BL.BLPayment(ApplicationUser))
            {
                return Json<List<PO.Data.PAYMENT_DATA_SINGLE>>(_Proxy.GetPaymentDataSingle()).SerializerSettings.ToString();
            }
        }

        [Route("AddPaymentSingle")]
        [HttpPost]
        public string AddPayment(BL.BLEntties.UserData ApplicationUser)
        {
            using (PO.BL.BLPayment _Proxy = new BL.BLPayment(ApplicationUser))
            {
                return Json<List<PO.Data.PAYMENT_DATA_SINGLE>>(_Proxy.GetPaymentDataSingle()).SerializerSettings.ToString();
            }
        }

    }
}
