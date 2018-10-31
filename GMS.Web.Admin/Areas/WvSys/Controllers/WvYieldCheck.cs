using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using GMS.Web.Admin.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PrdDb.DAL;
using WMIS.DAL.WVMDB;

namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class WvYieldCheckController : Controller
    {
        private WvmDbContext wvmDb = new WvmDbContext();
        private PrdAppDbContext prdAppDb = new PrdAppDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult peAppWvYieldChecks_Read([DataSourceRequest]DataSourceRequest request)
        {
            var query =
                @"
SELECT DISTINCT c.Id ,
                       c.inputdate ,
                       c.inputclass ,
                       d.name as name1,
                       e.name as name2,
                       f.name as name3,
                       c.machineno ,
                       c.gfno ,
                       c.itemname ,
                       c.value1 ,
                       c.value2 ,
                       c.Audit ,
                       c.remark ,
                       c.input_time ,
                       c.WorkerType FROM dbo.peAppWvYieldCheck c 
left join peAppWvWorker d on c.name1=d.cardno
left join peAppWvWorker e on c.name2=e.cardno
left join peAppWvWorker f on c.name3=f.cardno
where  c.name1 like 'GET%'order by c.inputdate
";
            List<peAppWvYieldCheck> yieldCheckQuery =
                wvmDb.Database.SqlQuery<peAppWvYieldCheck>(query).ToList();

            return Json(yieldCheckQuery.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvYieldChecks_Update([DataSourceRequest]DataSourceRequest request, peAppWvYieldCheck peAppWvYieldCheck)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvYieldCheck
                {
                    Id = peAppWvYieldCheck.Id,
                    inputdate = peAppWvYieldCheck.inputdate,
                    inputclass = peAppWvYieldCheck.inputclass,
                    name1 = peAppWvYieldCheck.name1,
                    name2 = peAppWvYieldCheck.name2,
                    name3 = peAppWvYieldCheck.name3,
                    machineno = peAppWvYieldCheck.machineno,
                    gfno = peAppWvYieldCheck.gfno,
                    itemname = peAppWvYieldCheck.itemname,
                    value1 = peAppWvYieldCheck.value1,
                    value2 = peAppWvYieldCheck.value2,
                    Audit = peAppWvYieldCheck.Audit,
                    //                    remark = peAppWvYieldCheck.remark,
                    //                    input_time = peAppWvYieldCheck.input_time,
                    WorkerType = peAppWvYieldCheck.WorkerType
                };

                wvmDb.peAppWvYieldChecks.Attach(entity);
                wvmDb.Entry(entity).State = EntityState.Modified;
                wvmDb.SaveChanges();
            }

            return Json(new[] { peAppWvYieldCheck }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvYieldChecks_Destroy([DataSourceRequest]DataSourceRequest request, peAppWvYieldCheck peAppWvYieldCheck)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvYieldCheck
                {
                    Id = peAppWvYieldCheck.Id,
                    inputdate = peAppWvYieldCheck.inputdate,
                    inputclass = peAppWvYieldCheck.inputclass,
                    name1 = peAppWvYieldCheck.name1,
                    name2 = peAppWvYieldCheck.name2,
                    name3 = peAppWvYieldCheck.name3,
                    machineno = peAppWvYieldCheck.machineno,
                    gfno = peAppWvYieldCheck.gfno,
                    itemname = peAppWvYieldCheck.itemname,
                    value1 = peAppWvYieldCheck.value1,
                    value2 = peAppWvYieldCheck.value2,
                    Audit = peAppWvYieldCheck.Audit,
                    remark = peAppWvYieldCheck.remark,
                    input_time = peAppWvYieldCheck.input_time,
                    WorkerType = peAppWvYieldCheck.WorkerType
                };

                wvmDb.peAppWvYieldChecks.Attach(entity);
                wvmDb.peAppWvYieldChecks.Remove(entity);
                wvmDb.SaveChanges();
            }

            return Json(new[] { peAppWvYieldCheck }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult ExecYieldAudit(int Id, int reviewer)
        {
            var _userInfo = prdAppDb.peAppUsers.Where(u => u.ID.Equals(reviewer)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            List<SqlParameter> paramArray = new List<SqlParameter>();
            paramArray.Add(new SqlParameter("@Id", Id));
            paramArray.Add(new SqlParameter("@reviewer", _userInfo.LoginName ?? ""));
            SqlParameter param = new SqlParameter("@rtn", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            paramArray.Add(param);

            try
            {
                wvmDb.Database.ExecuteSqlCommand("EXEC dbo.usp_peAppWvYieldAudit @Id,@reviewer,@rtn out",
                    paramArray.ToArray());
            }
            catch (Exception)
            {

                throw;
            }
            int result = (int)paramArray[2].Value;
            if (result > 0)
            {
                return Json(200);
            }
            else
            {
                return Json(HttpNotFound());
            }

        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            wvmDb.Dispose();
            prdAppDb.Dispose();
            base.Dispose(disposing);
        }
    }
}
