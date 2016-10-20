using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using PO.Data.BL.BLEntties;

namespace PO.Application.WebApi.Controllers
{
    [RoutePrefix("api/Base")]
    public class BaseController : ApiController
    {
        public JsonSerializerSettings JsonOption = new JsonSerializerSettings();

        public DateTime GetEuropeanTime
        {
            get
            {
                DateTime _UtcTime = DateTime.Now.ToUniversalTime();

                TimeZoneInfo _TimeInfo = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");

                return TimeZoneInfo.ConvertTimeFromUtc(_UtcTime, _TimeInfo);
            }
        }

        [Route("GetResourceDataTypes")]
        [HttpGet]
        public IHttpActionResult GetResourceData_Types()
        {
            try
            {
                using (Data.BL.BLBase _Proxy = new Data.BL.BLBase())
                {
                    return Json<List<ResourceData>>(_Proxy.GetResourceData(2), JsonOption);
                }
            }
            catch (System.Exception _Ex)
            {
                return Json(_Ex.StackTrace);
            }

            return null;
        }
        [Route("GetResourceDataGroups")]
        [HttpGet]
        public IHttpActionResult GetResourceData_Groups()
        {
            try
            {
                using (Data.BL.BLBase _Proxy = new Data.BL.BLBase())
                {
                    return Json<List<ResourceData>>(_Proxy.GetResourceData(1), JsonOption);
                }
            }
            catch (System.Exception _Ex)
            {
                return Json(_Ex.StackTrace);
            }

            return null;
        }

        public BaseController()
        {

            JsonOption.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            JsonOption.PreserveReferencesHandling = PreserveReferencesHandling.None;

        }
    }
}