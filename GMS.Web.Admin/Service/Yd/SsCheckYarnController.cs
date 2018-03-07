using System.Web.Http;
using GMS.Web.Admin.Models.Yd;
using PrdDb.DAL;

namespace GMS.Web.Admin.Service.Yd
{
    /// <summary>
    /// 松纱质量员检查表录入
    /// </summary>
    [RoutePrefix("api/Yd")]
    public class SsCheckYarnController : ApiController
    {
        private PrdAppContext db = new PrdAppContext();
        [Route("AddRtCheckYarn")]
        [HttpPost]
        public IHttpActionResult AddSsCheckYarn([FromBody] SsCheckYarnBindingModel SsCheckYarn)
        {
            if (SsCheckYarn == null)
            {
                return NotFound();
            }
            var add = new SsCheckYarn()
            {
                InputDate = SsCheckYarn.InputDate,
                MachineNo = SsCheckYarn.MachineNo,
                BatchNo = SsCheckYarn.BatchNo,
                CheckNum = SsCheckYarn.CheckNum,
                OperateType = SsCheckYarn.OperateType,
                SongjinNum = SsCheckYarn.SongjinNum,
                DaxiaoDiffNum = SsCheckYarn.DaxiaoDiffNum,
                ChengxingBadNum = SsCheckYarn.ChengxingBadNum,
                WorkerClass = SsCheckYarn.WorkerClass,
                CheckerName = SsCheckYarn.CheckerName
            };

            db.SsCheckYarns.Add(add);
            db.SaveChanges();
            return Ok();

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
