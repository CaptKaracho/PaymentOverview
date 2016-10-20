using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PO.Data.BL;
using PO.Data.BL.BLEntties;

namespace PO.Application.WebApi.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : BaseController
    {
        public UserData ApplicationUser
        {
            get
            {
                return new UserData();
            }
        }

        public ReturnObject ReturnData { get; set; }



        //TODO: applicationUser in session ausslagern
        [Route("GetPaymentSingleGranularity/{Granularity}")]
        [HttpGet]
        public IHttpActionResult GetPayment([FromUri]int Granularity)
        {
            try
            {
                using (BLPayment _Proxy = new BLPayment(ApplicationUser))
                {
                    return Json<List<PaymentDataSingle>>(_Proxy.GetPaymentDataSingle(Granularity), JsonOption);
                }
            }
            catch (System.Exception _Ex)
            {
                return Json(_Ex.StackTrace);
            }

            return null;
        }

        [Route("AddPaymentSingle")]
        [HttpPost]
        public IHttpActionResult AddPayment(PaymentDataSingle Data)
        {
            try
            {
                using (BLPayment _Proxy = new BLPayment(ApplicationUser))
                {
                    Data.PaymentDate = GetEuropeanTime;
                    return Json(_Proxy.AddPaymentDataSingle(Data), JsonOption);
                }
            }
            catch (System.Exception _Ex)
            {
                return Json(_Ex.StackTrace);
            }
        }
       

    }
}
