using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace PO.Application.WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        /// <summary>
        
        /// </summary>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public object Login(string Username, string Password)
        {
            using (BL.BLUser _Proxy = new BL.BLUser())
            {
                return _Proxy.Login(Username, Password);
            }
        }
    }
}