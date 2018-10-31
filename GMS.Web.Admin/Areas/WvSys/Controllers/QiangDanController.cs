using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Monitor_WV.DAL;
using Z.EntityFramework.Plus;

namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class QiangDanController : Controller
    {
        private MonitorWvDb db = new MonitorWvDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QiangDanTasks_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<QiangDanTask> qiangdantasks = db.QiangDanTasks.Where(q => (q.TaskStatus.Equals(1) || q.TaskStatus.Equals(11) || q.TaskStatus.Equals(21)) && q.IsActive == true).OrderBy(q => q.BeginTime);
            DataSourceResult result = qiangdantasks.ToDataSourceResult(request, qiangDanTask => new
            {
                Id = qiangDanTask.Id,
                SLID = qiangDanTask.SLID,
                CardNo = qiangDanTask.CardNo,
                MachineName = qiangDanTask.MachineName,
                Department = qiangDanTask.Department,
                WeaverNo1 = qiangDanTask.WeaverNo1,
                WeaverName1 = qiangDanTask.WeaverName1,
                WeaverNo2 = qiangDanTask.WeaverNo2,
                WeaverName2 = qiangDanTask.WeaverName2,
                WeaverNo3 = qiangDanTask.WeaverNo3,
                WeaverName3 = qiangDanTask.WeaverName3,
                WeaverClass = qiangDanTask.WeaverClass,
                WeaverGroup = qiangDanTask.WeaverGroup,
                HitTime = qiangDanTask.HitTime,
                BeginTime = qiangDanTask.BeginTime,
                EndTime = qiangDanTask.EndTime,
                TaskStatus = qiangDanTask.TaskStatus,
                AssignType = qiangDanTask.AssignType,
                IsActive = qiangDanTask.IsActive,
                FeedBack = qiangDanTask.FeedBack,
                Remark = qiangDanTask.Remark
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QiangDanTasks_Create([DataSourceRequest]DataSourceRequest request, QiangDanTask qiangDanTask)
        {
            if (ModelState.IsValid)
            {
                var entity = new QiangDanTask
                {
                    SLID = qiangDanTask.SLID,
                    CardNo = qiangDanTask.CardNo,
                    MachineName = qiangDanTask.MachineName,
                    Department = qiangDanTask.Department,
                    WeaverNo1 = qiangDanTask.WeaverNo1,
                    WeaverName1 = qiangDanTask.WeaverName1,
                    WeaverNo2 = qiangDanTask.WeaverNo2,
                    WeaverName2 = qiangDanTask.WeaverName2,
                    WeaverNo3 = qiangDanTask.WeaverNo3,
                    WeaverName3 = qiangDanTask.WeaverName3,
                    WeaverClass = qiangDanTask.WeaverClass,
                    WeaverGroup = qiangDanTask.WeaverGroup,
                    HitTime = qiangDanTask.HitTime,
                    BeginTime = qiangDanTask.BeginTime,
                    EndTime = qiangDanTask.EndTime,
                    TaskStatus = qiangDanTask.TaskStatus,
                    AssignType = qiangDanTask.AssignType,
                    IsActive = qiangDanTask.IsActive,
                    FeedBack = qiangDanTask.FeedBack,
                    Remark = qiangDanTask.Remark
                };

                db.QiangDanTasks.Add(entity);
                db.SaveChanges();
                qiangDanTask.Id = entity.Id;
            }

            return Json(new[] { qiangDanTask }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QiangDanTasks_Update([DataSourceRequest]DataSourceRequest request, QiangDanTask qiangDanTask)
        {
            if (ModelState.IsValid)
            {
                var entity = new QiangDanTask
                {
                    Id = qiangDanTask.Id,
                    SLID = qiangDanTask.SLID,
                    CardNo = qiangDanTask.CardNo,
                    MachineName = qiangDanTask.MachineName,
                    Department = qiangDanTask.Department,
                    WeaverNo1 = qiangDanTask.WeaverNo1,
                    WeaverName1 = qiangDanTask.WeaverName1,
                    WeaverNo2 = qiangDanTask.WeaverNo2,
                    WeaverName2 = qiangDanTask.WeaverName2,
                    WeaverNo3 = qiangDanTask.WeaverNo3,
                    WeaverName3 = qiangDanTask.WeaverName3,
                    WeaverClass = qiangDanTask.WeaverClass,
                    WeaverGroup = qiangDanTask.WeaverGroup,
                    HitTime = qiangDanTask.HitTime,
                    BeginTime = qiangDanTask.BeginTime,
                    EndTime = qiangDanTask.EndTime,
                    TaskStatus = qiangDanTask.TaskStatus,
                    AssignType = qiangDanTask.AssignType,
                    IsActive = qiangDanTask.IsActive,
                    FeedBack = qiangDanTask.FeedBack,
                    Remark = qiangDanTask.Remark
                };

                db.QiangDanTasks.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { qiangDanTask }.ToDataSourceResult(request, ModelState));
        }

        // TODO:
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QiangDanTasks_Destroy([DataSourceRequest]DataSourceRequest request, QiangDanTask qiangDanTask)
        {
            if (ModelState.IsValid)
            {
                db.QiangDanTasks.Where(q => q.Id.Equals(qiangDanTask.Id)).Update(q => new QiangDanTask
                {
                    IsActive = false
                });
                db.SaveChanges();
                //                var entity = new QiangDanTask
                //                {
                //                    Id = qiangDanTask.Id,
                //                    SLID = qiangDanTask.SLID,
                //                    CardNo = qiangDanTask.CardNo,
                //                    MachineName = qiangDanTask.MachineName,
                //                    Department = qiangDanTask.Department,
                //                    WeaverNo1 = qiangDanTask.WeaverNo1,
                //                    WeaverName1 = qiangDanTask.WeaverName1,
                //                    WeaverNo2 = qiangDanTask.WeaverNo2,
                //                    WeaverName2 = qiangDanTask.WeaverName2,
                //                    WeaverNo3 = qiangDanTask.WeaverNo3,
                //                    WeaverName3 = qiangDanTask.WeaverName3,
                //                    WeaverClass = qiangDanTask.WeaverClass,
                //                    WeaverGroup = qiangDanTask.WeaverGroup,
                //                    HitTime = qiangDanTask.HitTime,
                //                    BeginTime = qiangDanTask.BeginTime,
                //                    EndTime = qiangDanTask.EndTime,
                //                    TaskStatus = qiangDanTask.TaskStatus,
                //                    AssignType = qiangDanTask.AssignType,
                //                    IsActive = qiangDanTask.IsActive,
                //                    FeedBack = qiangDanTask.FeedBack,
                //                    Remark = qiangDanTask.Remark
                //                };
                //
                //                db.QiangDanTasks.Attach(entity);
                //                db.QiangDanTasks.Remove(entity);
                //                db.SaveChanges();
            }

            return Json(new[] { qiangDanTask }.ToDataSourceResult(request, ModelState));
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
