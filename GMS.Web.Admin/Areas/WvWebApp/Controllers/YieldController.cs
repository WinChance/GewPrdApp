using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WMIS.DAL.WVMDB;

namespace GMS.Web.Admin.Areas.WvWebApp.Controllers
{
    public class YieldController : Controller
    {
        private WvmDbContext db = new WvmDbContext();

        /// <summary>
        /// 查询产量页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string codeno)
        {
            ViewBag.codeno = codeno;
            return View();
        }
        /// <summary>
        /// 产量查询读方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="workerName"></param>
        /// <returns></returns>
        public ActionResult peAppWvQijiYields_Read([DataSourceRequest]DataSourceRequest request, DateTime beginDate, DateTime endDate, string employeeNumber)
        {
           
                #region LINQ 知识点

                // SQL 写法
                //                var query = @"
                //SELECT a.Id ,
                //       a.inputdate ,
                //       a.inputclass ,
                //	   b.name,
                //       a.machineno ,
                //       a.gfno ,
                //       a.itemname ,
                //       a.value1 ,
                //       a.value2 ,
                //       a.Reviewer ,
                //       a.remark ,
                //       a.input_time ,
                //       a.WorkerType FROM peAppWvYield AS a LEFT JOIN dbo.peAppWvWorker AS b ON a.name=b.cardno 
                //       where a.inputdate>=@p0 and a.inputdate<=@p1
                //";
                //                IQueryable<peAppWvYield> peappwvyields = db.Database.SqlQuery<peAppWvYield>(query, beginDate, endDate).AsQueryable();

                // LINQ TO SQL写法
                //var peappwvyields = from y in db.peAppWvYields
                //                        join w in db.peAppWvWorkers on y.name equals w.cardno
                //                        where y.inputdate >= beginDate && y.inputdate <= endDate
                //                        select new
                //                        {
                //                            Id = y.Id,
                //                            inputdate = y.inputdate,
                //                            inputclass = y.inputclass,
                //                            name = w.name,
                //                            machineno = y.machineno,
                //                            gfno = y.gfno,
                //                            itemname = y.itemname,
                //                            value1 = y.value1,
                //                            value2 = y.value2,
                //                            Reviewer = y.Reviewer,
                //                            WorkerType = y.WorkerType
                //                        };

                #endregion
               
             // linq to entity 扩展方法写法
                var peappwvyields =
                    db.peAppWvYields.Join(db.peAppWvWorkers, y => y.name, w => w.cardno, (y, w) => new { y, w })
                        .Where(@t => @t.y.inputdate >= beginDate && @t.y.inputdate <= endDate && t.w.cardno.Equals(employeeNumber,StringComparison.CurrentCultureIgnoreCase))
                        .Select(@t => new
                        {
                            Id = @t.y.Id,
                            inputdate = @t.y.inputdate,
                            inputclass = @t.y.inputclass,
                            name = @t.w.name,
                            machineno = @t.y.machineno,
                            gfno = @t.y.gfno,
                            itemname = @t.y.itemname,
                            value1 = @t.y.value1 ,
                            value2=  @t.y.value2,
                            Reviewer = @t.y.Reviewer,
                        }).Distinct();
               
                DataSourceResult result = peappwvyields.ToDataSourceResult(request, _peAppWvYield => new
                {
                    inputdate = _peAppWvYield.inputdate,
                    inputclass = _peAppWvYield.inputclass,
                    name = _peAppWvYield.name,
                    machineno = _peAppWvYield.machineno,
                    gfno = _peAppWvYield.gfno,
                    itemname = _peAppWvYield.itemname,
                    value1 = _peAppWvYield.value1,
                    value2 = _peAppWvYield.value2,
                    Reviewer = _peAppWvYield.Reviewer,
                });
                return Json(result);
            

        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}