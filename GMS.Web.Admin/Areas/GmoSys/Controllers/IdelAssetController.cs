﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using GMS.Framework.Utility;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PrdDb.DAL;

namespace GMS.Web.Admin.Areas.GmoSys.Controllers
{
    /// <summary>
    /// GMO:闲置资产状态维护
    /// </summary>
    public class IdelAssetController : Controller
    {
        private PrdAppDbContext db = new PrdAppDbContext();
        /// <summary>
        /// 公共查看页面
        /// </summary>
        /// <returns></returns>
        public ActionResult IdelAssetAll()
        {
            return View();
        }
        /// <summary>
        /// 维护界面
        /// </summary>
        /// <returns></returns>
        public ActionResult IdelAssetEdit()
        {
            return View();
        }
        /// <summary>
        /// 新增记录界面
        /// </summary>
        /// <returns></returns>
        public ActionResult IdelAssetCreate()
        {
            return View();
        }
        /// <summary>
        /// 查询所有闲置资产记录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GmoIdelAssets_ReadAll([DataSourceRequest]DataSourceRequest request, bool showAll)
        {
            IQueryable<GmoIdelAsset> gmoidelassets;
            if (showAll)
            {
                gmoidelassets = db.GmoIdelAssets;
            }
            else
            {
                gmoidelassets = db.GmoIdelAssets.Where(p => !p.Status.Contains("已报废") && !p.Status.Contains("已启用"));
            }
            DataSourceResult result = gmoidelassets.ToDataSourceResult(request, gmoIdelAsset => new
            {
                Id = gmoIdelAsset.Id,
                DeptName = gmoIdelAsset.DeptName,
                ZicanId = gmoIdelAsset.ZicanId,
                ZicanName = gmoIdelAsset.ZicanName,
                Pinpai = gmoIdelAsset.Pinpai,
                Xinghao = gmoIdelAsset.Xinghao,
                CunfangDidian = gmoIdelAsset.CunfangDidian,
                QidongDate = gmoIdelAsset.QidongDate,
                BeginDate = gmoIdelAsset.BeginDate,
                Reason = gmoIdelAsset.Reason,
                Status = gmoIdelAsset.Status,
                Fuzeren = gmoIdelAsset.Fuzeren,
                Yuanzhi = gmoIdelAsset.Yuanzhi,
                LeijiZhejiu = gmoIdelAsset.LeijiZhejiu,
                JingZhi = gmoIdelAsset.JingZhi,
                Inputer = gmoIdelAsset.Inputer,
                InputDatetime = gmoIdelAsset.InputDatetime,
                Modifier = gmoIdelAsset.Modifier,
                ModifyDatetime = gmoIdelAsset.ModifyDatetime
            });

            return Json(result);
        }
        /// <summary>
        /// 本部门所有闲置资产
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult GmoIdelAssets_Read([DataSourceRequest]DataSourceRequest request, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            IQueryable<GmoIdelAsset> gmoidelassets = db.GmoIdelAssets.Where(i => i.DeptName.Contains(_userInfo.Dept));
            DataSourceResult result = gmoidelassets.ToDataSourceResult(request, gmoIdelAsset => new
            {
                Id = gmoIdelAsset.Id,
                DeptName = gmoIdelAsset.DeptName,
                ZicanId = gmoIdelAsset.ZicanId,
                ZicanName = gmoIdelAsset.ZicanName,
                Pinpai = gmoIdelAsset.Pinpai,
                Xinghao = gmoIdelAsset.Xinghao,
                CunfangDidian = gmoIdelAsset.CunfangDidian,
                QidongDate = gmoIdelAsset.QidongDate,
                BeginDate = gmoIdelAsset.BeginDate,
                Reason = gmoIdelAsset.Reason,
                Status = gmoIdelAsset.Status,
                Fuzeren = gmoIdelAsset.Fuzeren,
                Yuanzhi = gmoIdelAsset.Yuanzhi,
                LeijiZhejiu = gmoIdelAsset.LeijiZhejiu,
                JingZhi = gmoIdelAsset.JingZhi,
                Inputer = gmoIdelAsset.Inputer,
                InputDatetime = gmoIdelAsset.InputDatetime,
                Modifier = gmoIdelAsset.Modifier,
                ModifyDatetime = gmoIdelAsset.ModifyDatetime
            });

            return Json(result);

        }
        /// <summary>
        /// 最近新增的记录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult GmoIdelAssets_ReadLatest([DataSourceRequest]DataSourceRequest request, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            IQueryable<GmoIdelAsset> gmoidelassets = db.GmoIdelAssets.Where(i => i.DeptName.Contains(_userInfo.Dept) && i.InputDatetime > DateTime.Today);
            DataSourceResult result = gmoidelassets.ToDataSourceResult(request, gmoIdelAsset => new
            {
                Id = gmoIdelAsset.Id,
                DeptName = gmoIdelAsset.DeptName,
                ZicanId = gmoIdelAsset.ZicanId,
                ZicanName = gmoIdelAsset.ZicanName,
                Pinpai = gmoIdelAsset.Pinpai,
                Xinghao = gmoIdelAsset.Xinghao,
                CunfangDidian = gmoIdelAsset.CunfangDidian,
                QidongDate = gmoIdelAsset.QidongDate,
                BeginDate = gmoIdelAsset.BeginDate,
                Reason = gmoIdelAsset.Reason,
                Status = gmoIdelAsset.Status,
                Fuzeren = gmoIdelAsset.Fuzeren,
                Yuanzhi = gmoIdelAsset.Yuanzhi,
                LeijiZhejiu = gmoIdelAsset.LeijiZhejiu,
                JingZhi = gmoIdelAsset.JingZhi,
                Inputer = gmoIdelAsset.Inputer,
                InputDatetime = gmoIdelAsset.InputDatetime,
                Modifier = gmoIdelAsset.Modifier,
                ModifyDatetime = gmoIdelAsset.ModifyDatetime
            });

            return Json(result);

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <param name="gmoIdelAsset"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GmoIdelAssets_Create([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<GmoIdelAsset> gmoIdelAssets, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            var results = new List<GmoIdelAsset>();
            var idelAssets = gmoIdelAssets as IList<GmoIdelAsset> ?? gmoIdelAssets.ToList();
            if (ModelState.IsValid)
            {
                foreach (var gmoIdelAsset in idelAssets)
                {
                    var entity = new GmoIdelAsset
                    {
                        DeptName = gmoIdelAsset.DeptName,
                        ZicanId = gmoIdelAsset.ZicanId,
                        ZicanName = gmoIdelAsset.ZicanName,
                        Pinpai = gmoIdelAsset.Pinpai,
                        Xinghao = gmoIdelAsset.Xinghao,
                        CunfangDidian = gmoIdelAsset.CunfangDidian,
                        QidongDate = gmoIdelAsset.QidongDate,
                        BeginDate = gmoIdelAsset.BeginDate,
                        Reason = gmoIdelAsset.Reason,
                        Status = gmoIdelAsset.Status,
                        Fuzeren = gmoIdelAsset.Fuzeren,
                        Yuanzhi = gmoIdelAsset.Yuanzhi,
                        LeijiZhejiu = gmoIdelAsset.LeijiZhejiu,
                        JingZhi = gmoIdelAsset.JingZhi,
                        Inputer = _userInfo.LoginName ?? "",
                        //InputDatetime = DateTime.Now,
                        Modifier = "",
                        ModifyDatetime = gmoIdelAsset.ModifyDatetime

                    };

                    db.GmoIdelAssets.Add(entity);
                    gmoIdelAsset.Id = entity.Id;
                }
                db.SaveChanges();
            }

            return Json(idelAssets.ToDataSourceResult(request, ModelState));
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="request"></param>
        /// <param name="gmoIdelAsset"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GmoIdelAssets_BatchUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<GmoIdelAsset> gmoIdelAssets, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).AsNoTracking().FirstOrDefault();
            var entities = new List<GmoIdelAsset>();
            foreach (var gmoIdelAsset in gmoIdelAssets)
            {
                var entity = new GmoIdelAsset
                {
                    Id = gmoIdelAsset.Id,
                    DeptName = gmoIdelAsset.DeptName,
                    ZicanId = gmoIdelAsset.ZicanId,
                    ZicanName = gmoIdelAsset.ZicanName,
                    Pinpai = gmoIdelAsset.Pinpai,
                    Xinghao = gmoIdelAsset.Xinghao,
                    CunfangDidian = gmoIdelAsset.CunfangDidian,
                    QidongDate = gmoIdelAsset.QidongDate,
                    BeginDate = gmoIdelAsset.BeginDate,
                    Reason = gmoIdelAsset.Reason,
                    Status = gmoIdelAsset.Status,
                    Fuzeren = gmoIdelAsset.Fuzeren,
                    Yuanzhi = gmoIdelAsset.Yuanzhi,
                    LeijiZhejiu = gmoIdelAsset.LeijiZhejiu,
                    JingZhi = gmoIdelAsset.JingZhi,
                    Inputer = _userInfo.LoginName ?? "",
                    //InputDatetime = DateTime.Now,
                    Modifier = "",
                    ModifyDatetime = gmoIdelAsset.ModifyDatetime

                };
                entities.Add(entity);
                db.GmoIdelAssets.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
            }
            db.SaveChanges();
            return Json(entities.ToDataSourceResult(request, ModelState));
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request"></param>
        /// <param name="gmoIdelAsset"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GmoIdelAssets_Update([DataSourceRequest]DataSourceRequest request, GmoIdelAsset gmoIdelAsset, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var entity = new GmoIdelAsset
                {
                    Id = gmoIdelAsset.Id,
                    DeptName = gmoIdelAsset.DeptName,
                    ZicanId = gmoIdelAsset.ZicanId,
                    ZicanName = gmoIdelAsset.ZicanName,
                    Pinpai = gmoIdelAsset.Pinpai,
                    Xinghao = gmoIdelAsset.Xinghao,
                    CunfangDidian = gmoIdelAsset.CunfangDidian,
                    QidongDate = gmoIdelAsset.QidongDate,
                    BeginDate = gmoIdelAsset.BeginDate,
                    Reason = gmoIdelAsset.Reason,
                    Status = gmoIdelAsset.Status,
                    Fuzeren = gmoIdelAsset.Fuzeren,
                    Yuanzhi = gmoIdelAsset.Yuanzhi,
                    LeijiZhejiu = gmoIdelAsset.LeijiZhejiu,
                    JingZhi = gmoIdelAsset.JingZhi,
                    Inputer = gmoIdelAsset.Inputer,
                    //InputDatetime = gmoIdelAsset.InputDatetime,
                    Modifier = _userInfo.LoginName ?? "",
                    ModifyDatetime = DateTime.Now
                };

                db.GmoIdelAssets.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { gmoIdelAsset }.ToDataSourceResult(request, ModelState));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <param name="gmoIdelAsset"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GmoIdelAssets_Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<GmoIdelAsset> gmoIdelAssets)
        {
            var entities = new List<GmoIdelAsset>();

            if (ModelState.IsValid)
            {
                foreach (var gmoIdelAsset in gmoIdelAssets)
                {
                    var entity = new GmoIdelAsset
                    {
                        Id = gmoIdelAsset.Id,
                        DeptName = gmoIdelAsset.DeptName,
                        ZicanId = gmoIdelAsset.ZicanId,
                        ZicanName = gmoIdelAsset.ZicanName,
                        Pinpai = gmoIdelAsset.Pinpai,
                        Xinghao = gmoIdelAsset.Xinghao,
                        CunfangDidian = gmoIdelAsset.CunfangDidian,
                        QidongDate = gmoIdelAsset.QidongDate,
                        BeginDate = gmoIdelAsset.BeginDate,
                        Reason = gmoIdelAsset.Reason,
                        Status = gmoIdelAsset.Status,
                        Fuzeren = gmoIdelAsset.Fuzeren,
                        Yuanzhi = gmoIdelAsset.Yuanzhi,
                        LeijiZhejiu = gmoIdelAsset.LeijiZhejiu,
                        JingZhi = gmoIdelAsset.JingZhi,
                        Inputer = gmoIdelAsset.Inputer,
                        InputDatetime = gmoIdelAsset.InputDatetime,
                        Modifier = gmoIdelAsset.Modifier,
                        ModifyDatetime = gmoIdelAsset.ModifyDatetime
                    };
                    entities.Add(entity);
                    db.GmoIdelAssets.Attach(entity);
                    db.GmoIdelAssets.Remove(entity);
                }
                db.SaveChanges();
            }

            return Json(entities.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
        /// <summary>
        /// 自动填写控件
        /// </summary>
        /// <param name="text"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAutocomplete(string text, string methodName)
        {
            var newResults = db.GmoDeptDicts.Where(p => p.DeptName.Contains(text)).Select(p => new { p.DeptName }).ToList();

            return Json(newResults, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
