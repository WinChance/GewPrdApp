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

        /// <summary>
        /// 查询待抢单/新增任务单
        /// </summary>
        /// <returns></returns>
        public ActionResult TasksManage()
        {
            return View();
        }
        /// <summary>
        /// 查询已抢单，并删除无效单
        /// </summary>
        /// <returns></returns>
        public ActionResult YiQiangDan()
        {
            return View();
        }
        /// <summary>
        /// 查询已删除的单
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryDeledTasks()
        {
            return View();
        }

        /// <summary>
        /// 1.1 待抢单列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult DaiQiangTasks_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<QiangDanTask> qiangdantasks = db.QiangDanTasks.Where(q => (q.TaskStatus.Equals(0) || q.TaskStatus.Equals(10) || q.TaskStatus.Equals(20)) && q.IsActive == true).OrderBy(q => q.BeginTime);
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
        
        /// <summary>
        /// 1.2 新建任务单
        /// </summary>
        /// <param name="request"></param>
        /// <param name="qiangDanTask"></param>
        /// <returns></returns>
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
                    BeginTime = DateTime.Now,
                    EndTime = qiangDanTask.EndTime,
                    TaskStatus = qiangDanTask.TaskStatus,
                    AssignType = qiangDanTask.AssignType,
                    IsActive = true,
                    FeedBack = qiangDanTask.FeedBack,
                    Remark = qiangDanTask.Remark
                };

                db.QiangDanTasks.Add(entity);
                db.SaveChanges();
                qiangDanTask.Id = entity.Id;
            }

            return Json(new[] { qiangDanTask }.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// 2.1 已抢单列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult YiQiangTasks_Read([DataSourceRequest]DataSourceRequest request)
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


        /// <summary>
        /// 3.1 已删除任务单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult DeledTasks_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<QiangDanTask> qiangdantasks = db.QiangDanTasks.Where(q => q.IsActive == false && q.Remark != null).OrderBy(q => q.BeginTime);
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

        /// <summary>
        /// 更新任务单状态
        /// </summary>
        /// <param name="request"></param>
        /// <param name="qiangDanTask"></param>
        /// <returns></returns>
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
                    IsActive = true,
                    FeedBack = qiangDanTask.FeedBack,
                    Remark = qiangDanTask.Remark
                };

                db.QiangDanTasks.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { qiangDanTask }.ToDataSourceResult(request, ModelState));
        }
        /// <summary>
        /// 删除任务单
        /// </summary>
        /// <param name="request"></param>
        /// <param name="qiangDanTask"></param>
        /// <returns></returns>
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
