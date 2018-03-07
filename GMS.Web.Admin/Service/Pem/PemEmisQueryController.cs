using System.Linq;
using System.Web.Http;
using EMIS.DAL;

namespace GMS.Web.Admin.Service.Pem
{
    /// <summary>
    /// PEM物料查询系统
    /// </summary>
    [RoutePrefix("api/Pem")]
    public class PemEmisQueryController : ApiController
    {
        // SELECT * FROM [EMIS_DB].[dbo].[EQ_MATTER_STOCK_VIEW] with (nolock)  where c_cstock>0 and s_type like '%6203%'
        private  EmisDbContext emisDb = new EmisDbContext();
        /// <summary>
        /// 获取库存
        /// </summary>
        /// <returns></returns>
        [Route("GetEmisMatterStockInfo")]
        [HttpGet]
        public IHttpActionResult GetEmisMatterStockInfo([FromUri] string s_type)
        {
            var rtn=emisDb.EQ_MATTER_STOCK_VIEW.Where(s=>s.s_type!=null&&s.s_type.Contains(s_type)&&s.c_cstock>0);
            return Json(rtn);
        }
        protected override void Dispose(bool disposing)
        {
            emisDb.Dispose();
            base.Dispose(disposing);
        }
    }
}
