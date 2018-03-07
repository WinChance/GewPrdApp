using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GMS.Web.Admin.Areas.WvSys.Models.UserMenuRight;
using Microsoft.Ajax.Utilities;
using PrdDb.DAL;
using Z.EntityFramework.Plus;

namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class UserMenuRightController : Controller
    {
        PrdAppContext dbContext = new PrdAppContext();

        // GET: WvSys/UserMenuRight
        public ActionResult Index(string userCode)
        {
            
            if (userCode.IsNullOrWhiteSpace())
            {
                TempData["userCode"] = "";
            }
            else
            {
                TempData["userCode"] = userCode;
            }
            var orDefault = dbContext.peAppWvUsers.Where(u => u.code.Equals(userCode,StringComparison.CurrentCultureIgnoreCase))
                .Select(u => new { userName = u.name }).FirstOrDefault();
            if (orDefault != null)
            {
                string firstOrDefault = orDefault.userName;
                ViewBag.userName = firstOrDefault;
            }
            return View(GetMenusInitialModel());
        }
        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="postedUserMenus"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(PostedUserMenus postedUserMenus)
        {
            string _userCode = TempData["userCode"] as string;
            dbContext.peAppWvUserMenus.Where(um => um.usercode.Equals(_userCode, StringComparison.CurrentCultureIgnoreCase)).Delete();
            foreach (var menuId in postedUserMenus.MenuIds)
            {
                dbContext.peAppWvUserMenus.Add(new peAppWvUserMenu()
                {
                    menucode = menuId,
                    usercode = _userCode
                });
            }
            dbContext.SaveChanges();
            return View(GetMenusInitialModel());
        }
        /// <summary>
        /// 读取数据库的权限，返回到前台CheckBoxList
        /// </summary>
        /// <returns></returns>
        private UserMenuViewModel GetMenusInitialModel()
        {
            var model = new UserMenuViewModel();
            var selectedMenus = new List<Menu>();

            if (TempData["userCode"] != null)
            {
                string _userCode = TempData["userCode"] as string;

                // 1、查询该用户的权限列表
                var userInfos = dbContext.peAppWvUserMenus.Where(um => um.usercode.Equals(_userCode))
                    .Join(dbContext.peAppWvMenus, um => um.menucode, m => m.code, (um, m) => new
                    {
                        UserMenuId = um.Id,
                        MenuIndex = m.Id,
                        MenuId = um.menucode,
                        MenuName = m.text
                    });
                
                foreach (var userInfo in userInfos)
                {
                    Menu m = new Menu()
                    {
                        Id = userInfo.MenuId,
                        Name = userInfo.MenuName,
                        IsSelected = true,
                    };
                    selectedMenus.Add(m);
                }
            }
            model.AvailableMenus = this.GetAllMenus();
            // 2、将数据库的权限显示在CheckBoxList上
            model.SelectedMenus = selectedMenus;
            return model;
        }
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        private List<Menu> GetAllMenus()
        {
            //var appWvMenu = new List<AppWvMenu>();
            var peAppWvMenus = dbContext.peAppWvMenus.ToList();

            return peAppWvMenus.Select(m => new Menu()
            {
                Id = m.code,
                Name = m.text
            }).ToList();
        }
    }
}