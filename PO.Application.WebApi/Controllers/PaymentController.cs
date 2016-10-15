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



        //TODO: applicationUser in session ausslagern
        [Route("GetAllPaymentSingle")]
        [HttpGet]
        public IHttpActionResult GetPayment()
        {
            try
            {
                using (PO.BL.BLPayment _Proxy = new BL.BLPayment(ApplicationUser))
                {
                    return Json<List<BL.BLEntties.PaymentDataSingle>>(_Proxy.GetPaymentDataSingle(), JsonOption);
                }
            }
            catch (System.Exception _Ex)
            {
                // ReturnData.Error = Json(_Ex.StackTrace.ToString(), JsonOption);
            }

            return null;
        }




        [Route("AddPaymentSingle")]
        [HttpPost]
        public IHttpActionResult AddPayment([FromBody]BL.BLEntties.PaymentDataSingle Data)
        {
            try
            {
                using (PO.BL.BLPayment _Proxy = new BL.BLPayment(ApplicationUser))
                {

                    //_Proxy.RepContext.PAYMENT_DATA_SINGLE.Add(new PO.Data.PAYMENT_DATA_SINGLE()
                    //{
                    //    DESCRIPTION = "FUKUUKCK",
                    //    PRICE = 123,
                    //    DATE = DateTime.Now
                    //});


                    //_Proxy.RepContext.SaveChanges();
                    //return Json("ok");
                    Data.PaymentDate = DateTime.Now;
                    return Json(_Proxy.AddPaymentDataSingle(Data), JsonOption);
                }
            }
            catch (System.Exception _Ex)
            {
                return Json(_Ex.StackTrace);
            }
        }
        [Route("AddPaymentSingleTest")]
        [HttpPost]
        public HttpResponseMessage AddTest([FromBody]string Description)
        {
            return Request.CreateResponse(HttpStatusCode.OK, string.Format("{0}{1}", Description, "TEST"));
        }

        [Route("AddPaymentSingleTest2")]
        [HttpPost]
        public IHttpActionResult AddTes2t()
        {
            return Json(string.Format("no Data ok"));
        }

    }
}
