﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WMIS.DAL.WVMDB;

namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class GridController : Controller
    {
        private WvmDbContext db = new WvmDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult peAppWvYields_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<peAppWvYield> peappwvyields = db.peAppWvYields;
            DataSourceResult result = peappwvyields.ToDataSourceResult(request, peAppWvYield => new {
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvYields_Create([DataSourceRequest]DataSourceRequest request, peAppWvYield peAppWvYield)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvYield
                {
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
                };

                db.peAppWvYields.Add(entity);
                db.SaveChanges();
                peAppWvYield.Id = entity.Id;
            }

            return Json(new[] { peAppWvYield }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvYields_Update([DataSourceRequest]DataSourceRequest request, peAppWvYield peAppWvYield)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvYield
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
                };

                db.peAppWvYields.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { peAppWvYield }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvYields_Destroy([DataSourceRequest]DataSourceRequest request, peAppWvYield peAppWvYield)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvYield
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
                };

                db.peAppWvYields.Attach(entity);
                db.peAppWvYields.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { peAppWvYield }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
