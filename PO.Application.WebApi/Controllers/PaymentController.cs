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
        public BL.BLEntties.UserData ApplicationUser
        {
            get
            {
                return new BL.BLEntties.UserData();
            }
        }

        [Route("GetAllPaymentSingleTest")]
        [HttpPost]
        public IHttpActionResult GetTest()
        {
            return Json("PaymentSIngle OK");
        }

        //TODO: applicationUser in session ausslagern
        [Route("GetAllPaymentSingle")]
        [HttpPost]
        public IHttpActionResult GetPayment()
        {
            using (PO.BL.BLPayment _Proxy = new BL.BLPayment(ApplicationUser))
            {
                return Json(_Proxy.GetPaymentDataSingle());
            }
        }

        [Route("AddPaymentSingle")]
        [HttpPost]
        public IHttpActionResult AddPayment(string Description, decimal Price, int PaymentType, string AddonText, int PaymentGroup)
        {
            using (PO.BL.BLPayment _Proxy = new BL.BLPayment(ApplicationUser))
            {
                return Json(_Proxy.AddPaymentDataSingle(Description, Price, PaymentType, DateTime.Now, AddonText, PaymentGroup));
            }
        }

    }
}
