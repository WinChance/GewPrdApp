﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
 using System.Data.Entity.Core.Common.CommandTrees;
 using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMS.Framework.Utility;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PrdDb.DAL;

namespace GMS.Web.Admin.Areas.GmoSys.Controllers
{
    public class CapexController : Controller
    {
        private PrdAppDbContext db = new PrdAppDbContext();
        /// <summary>
        /// 查询所有Capex信息
        /// </summary>
        /// <returns></returns>
        public ActionResult CapexAll()
        {
            return View();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult CapexEdit()
        {
            return View();
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        public ActionResult CapexCreate()
        {
            return View();
        }
        /// <summary>
        /// 查询所有Capex
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GmoCapexes_ReadAll([DataSourceRequest]DataSourceRequest request, bool showAll)
        {
            IQueryable<GmoCapex> gmocapexes;
            if (showAll)
            {
                gmocapexes = db.GmoCapexes; 
            }
            else
            {
                gmocapexes = db.GmoCapexes.Where(p => !p.Status.Contains("项目回顾完成") && !p.Status.Contains("取消"));
            }
            DataSourceResult result = gmocapexes.ToDataSourceResult(request, gmoCapex => new
            {
                Id = gmoCapex.Id,
                AnnualBudgetId = gmoCapex.AnnualBudgetId,
                DeptName = gmoCapex.DeptName,
                PrjLeader = gmoCapex.PrjLeader,
                PrjName = gmoCapex.PrjName,
                YusuanMoney = gmoCapex.YusuanMoney,
                BudgetQuarter = gmoCapex.BudgetQuarter,
                Status = gmoCapex.Status,
                JinduMiaoshu = gmoCapex.JinduMiaoshu,
                CapexId = gmoCapex.CapexId,
                ShenqingMoney = gmoCapex.ShenqingMoney,
                HuiguJieguo = gmoCapex.HuiguJieguo,
                Inputer = gmoCapex.Inputer,
                InputDatetime = gmoCapex.InputDatetime,
                Modifier = gmoCapex.Modifier,
                ModifyDatetime = gmoCapex.ModifyDatetime
            });

            return Json(result);
        }
        /// <summary>
        /// 读取本部门的Capex
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult GmoCapexes_Read([DataSourceRequest]DataSourceRequest request, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            IQueryable<GmoCapex> gmocapexes = db.GmoCapexes.Where(c => c.DeptName.Equals(_userInfo.Dept, StringComparison.CurrentCultureIgnoreCase));
            DataSourceResult result = gmocapexes.ToDataSourceResult(request, gmoCapex => new
            {
                Id = gmoCapex.Id,
                AnnualBudgetId = gmoCapex.AnnualBudgetId,
                DeptName = gmoCapex.DeptName,
                PrjLeader = gmoCapex.PrjLeader,
                PrjName = gmoCapex.PrjName,
                YusuanMoney = gmoCapex.YusuanMoney,
                BudgetQuarter = gmoCapex.BudgetQuarter,
                Status = gmoCapex.Status,
                JinduMiaoshu = gmoCapex.JinduMiaoshu,
                CapexId = gmoCapex.CapexId,
                ShenqingMoney = gmoCapex.ShenqingMoney,
                HuiguJieguo = gmoCapex.HuiguJieguo,
                Inputer = gmoCapex.Inputer,
                InputDatetime = gmoCapex.InputDatetime,
                Modifier = gmoCapex.Modifier,
                ModifyDatetime = gmoCapex.ModifyDatetime
            });

            return Json(result);
        }
        /// <summary>
        /// 最近新增的记录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult GmoCapexes_ReadLatest([DataSourceRequest]DataSourceRequest request, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            IQueryable<GmoCapex> gmocapexes = db.GmoCapexes.Where(c => c.DeptName.Equals(_userInfo.Dept, StringComparison.CurrentCultureIgnoreCase)&&c.InputDatetime>DateTime.Today);
            DataSourceResult result = gmocapexes.ToDataSourceResult(request, gmoCapex => new
            {
                Id = gmoCapex.Id,
                AnnualBudgetId = gmoCapex.AnnualBudgetId,
                DeptName = gmoCapex.DeptName,
                PrjLeader = gmoCapex.PrjLeader,
                PrjName = gmoCapex.PrjName,
                YusuanMoney = gmoCapex.YusuanMoney,
                BudgetQuarter = gmoCapex.BudgetQuarter,
                Status = gmoCapex.Status,
                JinduMiaoshu = gmoCapex.JinduMiaoshu,
                CapexId = gmoCapex.CapexId,
                ShenqingMoney = gmoCapex.ShenqingMoney,
                HuiguJieguo = gmoCapex.HuiguJieguo,
                Inputer = gmoCapex.Inputer,
                InputDatetime = gmoCapex.InputDatetime,
                Modifier = gmoCapex.Modifier,
                ModifyDatetime = gmoCapex.ModifyDatetime
            });

            return Json(result);
        }
        /// <summary>
        /// 新建Capex
        /// </summary>
        /// <param name="request"></param>
        /// <param name="gmoCapex"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GmoCapexes_Create([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<GmoCapex> gmoCapexs, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            var gmoCapexes = gmoCapexs as IList<GmoCapex> ?? gmoCapexs.ToList();
            if (ModelState.IsValid)
            {
                foreach (var gmoCapex in gmoCapexes)
                {
                    var entity = new GmoCapex
                    {
                        AnnualBudgetId = gmoCapex.AnnualBudgetId,
                        DeptName = gmoCapex.DeptName,
                        PrjLeader = gmoCapex.PrjLeader,
                        PrjName = gmoCapex.PrjName,
                        YusuanMoney = gmoCapex.YusuanMoney,
                        BudgetQuarter = gmoCapex.BudgetQuarter,
                        Status = gmoCapex.Status,
                        JinduMiaoshu = gmoCapex.JinduMiaoshu,
                        CapexId = gmoCapex.CapexId,
                        ShenqingMoney = gmoCapex.ShenqingMoney,
                        HuiguJieguo = gmoCapex.HuiguJieguo,
                        Inputer = _userInfo.LoginName ?? "",
                        //InputDatetime = gmoCapex.InputDatetime,
                        Modifier = "",
                        ModifyDatetime = gmoCapex.ModifyDatetime
                    };

                    db.GmoCapexes.Add(entity);
                    gmoCapex.Id = entity.Id;
                }
                db.SaveChanges();

            }

            return Json(gmoCapexes.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GmoCapexes_Update([DataSourceRequest]DataSourceRequest request, GmoCapex gmoCapex, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var entity = new GmoCapex
                {
                    Id = gmoCapex.Id,
                    AnnualBudgetId = gmoCapex.AnnualBudgetId,
                    DeptName = gmoCapex.DeptName,
                    PrjLeader = gmoCapex.PrjLeader,
                    PrjName = gmoCapex.PrjName,
                    YusuanMoney = gmoCapex.YusuanMoney,
                    BudgetQuarter = gmoCapex.BudgetQuarter,
                    Status = gmoCapex.Status,
                    JinduMiaoshu = gmoCapex.JinduMiaoshu,
                    CapexId = gmoCapex.CapexId,
                    ShenqingMoney = gmoCapex.ShenqingMoney,
                    HuiguJieguo = gmoCapex.HuiguJieguo,
                    Inputer = gmoCapex.Inputer,
                    //InputDatetime = gmoCapex.InputDatetime,
                    Modifier = _userInfo.LoginName ?? "",
                    ModifyDatetime = DateTime.Now
                };

                db.GmoCapexes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { gmoCapex }.ToDataSourceResult(request, ModelState));
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="request"></param>
        /// <param name="gmoCapexs"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GmoCapexes_BatchUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<GmoCapex> gmoCapexs, string userID)
        {
            int _userID = userID.ToInt();
            var _userInfo = db.peAppUsers.Where(u => u.ID.Equals(_userID)).Select(u => new { u.Dept, u.LoginName }).FirstOrDefault();
            var entities = new List<GmoCapex>();
            if (ModelState.IsValid)
            {
                foreach (var gmoCapex in gmoCapexs)
                {
                    var entity = new GmoCapex
                    {
                        Id = gmoCapex.Id,
                        AnnualBudgetId = gmoCapex.AnnualBudgetId,
                        DeptName = gmoCapex.DeptName,
                        PrjLeader = gmoCapex.PrjLeader,
                        PrjName = gmoCapex.PrjName,
                        YusuanMoney = gmoCapex.YusuanMoney,
                        BudgetQuarter = gmoCapex.BudgetQuarter,
                        Status = gmoCapex.Status,
                        JinduMiaoshu = gmoCapex.JinduMiaoshu,
                        CapexId = gmoCapex.CapexId,
                        ShenqingMoney = gmoCapex.ShenqingMoney,
                        HuiguJieguo = gmoCapex.HuiguJieguo,
                        Inputer = gmoCapex.Inputer,
                        //InputDatetime = gmoCapex.InputDatetime,
                        Modifier = _userInfo.LoginName ?? "",
                        ModifyDatetime = DateTime.Now
                    };
                    entities.Add(entity);
                    db.GmoCapexes.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                }
                db.SaveChanges();
            }

            return Json(entities.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GmoCapexes_Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<GmoCapex> gmoCapexs)
        {
            var entities = new List<GmoCapex>();
            if (ModelState.IsValid)
            {
                foreach (var gmoCapex in gmoCapexs)
                {
                    var entity = new GmoCapex
                    {
                        Id = gmoCapex.Id,
                        AnnualBudgetId = gmoCapex.AnnualBudgetId,
                        DeptName = gmoCapex.DeptName,
                        PrjLeader = gmoCapex.PrjLeader,
                        PrjName = gmoCapex.PrjName,
                        YusuanMoney = gmoCapex.YusuanMoney,
                        BudgetQuarter = gmoCapex.BudgetQuarter,
                        Status = gmoCapex.Status,
                        JinduMiaoshu = gmoCapex.JinduMiaoshu,
                        CapexId = gmoCapex.CapexId,
                        ShenqingMoney = gmoCapex.ShenqingMoney,
                        HuiguJieguo = gmoCapex.HuiguJieguo,
                        Inputer = gmoCapex.Inputer,
                        InputDatetime = gmoCapex.InputDatetime,
                        Modifier = gmoCapex.Modifier,
                        ModifyDatetime = gmoCapex.ModifyDatetime
                    };
                    entities.Add(entity);
                    db.GmoCapexes.Attach(entity);
                    db.GmoCapexes.Remove(entity);
                    //db.Entry(entity).State = EntityState.Modified;
                }
                //var entity = new GmoCapex
                //{
                //    Id = gmoCapex.Id,
                //    AnnualBudgetId = gmoCapex.AnnualBudgetId,
                //    DeptName = gmoCapex.DeptName,
                //    PrjLeader = gmoCapex.PrjLeader,
                //    PrjName = gmoCapex.PrjName,
                //    YusuanMoney = gmoCapex.YusuanMoney,
                //    BudgetQuarter = gmoCapex.BudgetQuarter,
                //    Status = gmoCapex.Status,
                //    JinduMiaoshu = gmoCapex.JinduMiaoshu,
                //    CapexId = gmoCapex.CapexId,
                //    ShenqingMoney = gmoCapex.ShenqingMoney,
                //    HuiguJieguo = gmoCapex.HuiguJieguo,
                //    Inputer = gmoCapex.Inputer,
                //    InputDatetime = gmoCapex.InputDatetime,
                //    Modifier = gmoCapex.Modifier,
                //    ModifyDatetime = gmoCapex.ModifyDatetime
                //};

                
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
