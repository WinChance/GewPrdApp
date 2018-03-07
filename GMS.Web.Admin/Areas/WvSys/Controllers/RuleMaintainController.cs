﻿using System;
 using System.Data.Entity;
 using System.Globalization;
 using System.Linq;
 using System.Web.Mvc;
 using System.Web.WebPages;
 using GMS.Framework.Utility;
 using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
 using PrdDb.DAL;

namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class RuleMaintainController : Controller
    {
        private PrdAppContext db = new PrdAppContext();

        public ActionResult Index()
        {
            return View();
        }

        #region 更新命名规则-0729

        /*
        SELECT * INTO #Tb1 FROM  [dbo].[peAppWvRule] WHERE  code NOT IN('M01','M02','M05','M06') AND WorkerType='织布'--机修,起机,上轴,织布

SELECT IDENTITY(INT,1,1) Iden,
                              a.code ,
                              a.itemname ,
                              a.value1 ,
                              a.value2 ,
                              a.type ,
                              a.WorkerType INTO #Tb2 FROM #Tb1 AS a ORDER BY a.itemname
UPDATE a SET a.code='Z'+CAST(b.Iden AS VARCHAR(5)) FROM [dbo].[peAppWvRule] AS a INNER JOIN #Tb2 AS b ON b.code = a.code
--SELECT * FROM #Tb2 
SELECT Id ,
       code ,
       itemname ,
       value1 ,
       value2 ,
       type ,
       WorkerType  FROM  [dbo].[peAppWvRule] WHERE  code NOT IN('M01','M02','M05','M06') AND WorkerType='织布' ORDER BY CAST(SUBSTRING(code,2,10) AS int)
DROP TABLE #Tb1,#Tb2
         */

        #endregion
        public ActionResult peAppWvRules_Read([DataSourceRequest]DataSourceRequest request)
        {
//            string sqlText = @"SELECT Id ,
//       code ,
//       itemname ,
//       value1 ,
//       value2 ,
//       type ,
//       WorkerType  FROM  [dbo].[peAppWvRule]  ORDER BY CAST(SUBSTRING(code,2,10) AS int)";
//            IQueryable<peAppWvRule> peappwvrules = db.Database.SqlQuery<peAppWvRule>(sqlText).AsQueryable();
            IQueryable<peAppWvRule> peappwvrules = db.peAppWvRules.ToList().OrderBy(r => int.Parse(r.code.Substring(1))).AsQueryable();
            DataSourceResult result = peappwvrules.ToDataSourceResult(request, peAppWvRule => new {
                Id = peAppWvRule.Id,
                code = peAppWvRule.code,
                itemname = peAppWvRule.itemname,
                value1 = peAppWvRule.value1,
                value2 = peAppWvRule.value2,
                type = peAppWvRule.type,
                WorkerType = peAppWvRule.WorkerType
            });

            return Json(result);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvRules_Create([DataSourceRequest]DataSourceRequest request, peAppWvRule peAppWvRule)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvRule
                {
                    code = peAppWvRule.code,
                    itemname = peAppWvRule.itemname,
                    value1 = peAppWvRule.value1,
                    value2 = peAppWvRule.value2,
                    type = peAppWvRule.type,
                    WorkerType = peAppWvRule.WorkerType
                };

                db.peAppWvRules.Add(entity);
                db.SaveChanges();
                peAppWvRule.Id = entity.Id;
            }

            return Json(new[] { peAppWvRule }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvRules_Update([DataSourceRequest]DataSourceRequest request, peAppWvRule peAppWvRule)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvRule
                {
                    Id = peAppWvRule.Id,
                    code = peAppWvRule.code,
                    itemname = peAppWvRule.itemname,
                    value1 = peAppWvRule.value1,
                    value2 = peAppWvRule.value2,
                    type = peAppWvRule.type,
                    WorkerType = peAppWvRule.WorkerType
                };

                db.peAppWvRules.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { peAppWvRule }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvRules_Destroy([DataSourceRequest]DataSourceRequest request, peAppWvRule peAppWvRule)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvRule
                {
                    Id = peAppWvRule.Id,
                    code = peAppWvRule.code,
                    itemname = peAppWvRule.itemname,
                    value1 = peAppWvRule.value1,
                    value2 = peAppWvRule.value2,
                    type = peAppWvRule.type,
                    WorkerType = peAppWvRule.WorkerType
                };

                db.peAppWvRules.Attach(entity);
                db.peAppWvRules.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { peAppWvRule }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
