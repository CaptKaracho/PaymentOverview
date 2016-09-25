using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PO.Application.WebApi.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : BaseController
    {
        public BL.BLEntties.UserData ApplicationUser
        {
            get
            {
                return new BL.BLEntties.UserData();
            }
        }

        public BL.BLEntties.ReturnObject ReturnData { get; set; }

        [Route("GetAllPaymentSingleTest")]
        [HttpPost]
        public IHttpActionResult GetTest()
        {
            return Json("PaymentSIngle OK");
        }

        //TODO: applicationUser in session ausslagern
        [Route("GetAllPaymentSingle")]
        [HttpGet]
        public IHttpActionResult GetPayment()
        {
            try
            {
                using (PO.BL.BLPayment _Proxy = new BL.BLPayment(ApplicationUser))
                {
                    ReturnData.Data= Json(_Proxy.GetPaymentDataSingle(), JsonOption);
                }
            }
            catch (System.Exception _Ex)
            {
                ReturnData.Error= Json(_Ex.StackTrace.ToString(), JsonOption);
            }

            return ReturnData;
        }

        [Route("AddPaymentSingle")]
        [HttpPost]
        public IHttpActionResult AddPayment(string Description, decimal Price, int PaymentType, string AddonText, int PaymentGroup)
        {
            using (PO.BL.BLPayment _Proxy = new BL.BLPayment(ApplicationUser))
            {
                return Json(_Proxy.AddPaymentDataSingle(Description, Price, PaymentType, DateTime.Now, AddonText, PaymentGroup), JsonOption);
            }
        }

    }
}
