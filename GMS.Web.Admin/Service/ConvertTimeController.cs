using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GMS.Web.Admin.Service
{
    public class ConvertTimeController : Controller
    {
        // GET: ConvertTime
        /// <summary>
        /// 返回处理过时间的json
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        protected ContentResult ConvertDateToJson(object Data)
        {
            //  HH:mm:ss
            //string str = "yyyy'年'MM'月'dd'日'";

            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "MM-dd HH:mm" };

            return Content(JsonConvert.SerializeObject(Data, Formatting.Indented, timeConverter));
        }
    }
}