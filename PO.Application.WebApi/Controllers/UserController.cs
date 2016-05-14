using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


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

            using (BL.BLUser _Proxy = new BL.BLUser())
            {
                return Json( _Proxy.Login(Username, Password),JsonOption);
            }
        }
    }
}