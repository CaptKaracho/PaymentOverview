using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using PO.BL.BLEntties;

namespace PO.Application.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: Default
        public string Index()
        {
            return "Webapi OK";
        }

        public UserData Login(string Username, string Password)
        {
            using (BL.BLUser _Proxy = new BL.BLUser())
            {
                return _Proxy.Login(Username, Password);
            }
        }

        //public JsonResult GetPayment()
        //{
        //    using (PO.BL.BLPayment _Proxy = new BL.BLPayment())
        //    {
        //        return Json<(_Proxy.GetPaymentDataSingle());
        //    }
        //}
    }
}