using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace PO.Application.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        public JsonSerializerSettings JsonOption = new JsonSerializerSettings();

        public BaseController()
        {
            
            JsonOption.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            JsonOption.PreserveReferencesHandling = PreserveReferencesHandling.None;

        }
    }
}