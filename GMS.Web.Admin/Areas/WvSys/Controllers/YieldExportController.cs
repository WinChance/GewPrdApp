﻿using System;
using System.Linq;
using System.Web.Mvc;
 using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
 using StackExchange.Profiling;
 using WMIS.DAL.WVMDB;

namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class YieldExportController : Controller
    {
        private WvmDbContext wvmDb = new WvmDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult peAppWvYields_Read([DataSourceRequest]DataSourceRequest request)
        {
            var profiler = MiniProfiler.Current;
            DataSourceResult result = new DataSourceResult();
            // 使用MiniProfiler工具优化自动生成的SQL
            using (profiler.Step("查询产量数据"))
            {
                var peappwvyields =
                    wvmDb.peAppWvYields.Join(wvmDb.peAppWvWorkers, y => y.name, w => w.cardno, (y, w) => new { y, w })
                        .Select(@t => new
                        {
                            Id = @t.y.Id,
                            inputdate = @t.y.inputdate,
                            inputclass = @t.y.inputclass,
                            name = @t.w.name,
                            machineno = @t.y.machineno,
                            gfno = @t.y.gfno,
                            itemname = @t.y.itemname,
                            value1 = @t.y.value1,
                            value2 = @t.y.value2,
                            Reviewer = @t.y.Reviewer,
                            remark = t.y.remark,
                            input_time = t.y.input_time,
                            WorkerType = @t.y.WorkerType
                        }).Distinct();

                result = peappwvyields.ToDataSourceResult(request, peAppWvYield => new
                {
                    Id = peAppWvYield.Id,
                    inputdate = peAppWvYield.inputdate,
                    inputclass = peAppWvYield.inputclass,
                    name = peAppWvYield.name,
                    machineno = peAppWvYield.machineno,
                    gfno = peAppWvYield.gfno,
                    itemname = peAppWvYield.itemname,
                    value1 = peAppWvYield.value1,
                    value2 = peAppWvYield.value2,
                    Reviewer = peAppWvYield.Reviewer,
                    remark = peAppWvYield.remark,
                    input_time = peAppWvYield.input_time,
                    WorkerType = peAppWvYield.WorkerType
                });
                return Json(result);
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
            base.Dispose(disposing);
        }
    }
}
