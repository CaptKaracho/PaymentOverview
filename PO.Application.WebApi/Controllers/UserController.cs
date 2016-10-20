using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PO.Data.BL;
using PO.Data.BL.BLEntties;


namespace PO.Application.WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : BaseController
    {
        /// <summary>

        /// </summary>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(string Username, string Password)
        {

            using (BLUser _Proxy = new BLUser())
            {
                return Json(_Proxy.Login(Username, Password), JsonOption);
            }
        }
    }
}