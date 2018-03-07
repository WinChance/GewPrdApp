using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using GMS.Web.Admin.Areas.WvSys.Models.UserMaintain;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PrdDb.DAL;
using Z.EntityFramework.Plus;

namespace GMS.Web.Admin.Areas.WvSys.Controllers
{
    public class UserMaintainController : Controller
    {
        private PrdAppContext db = new PrdAppContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult peAppWvUsers_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<peAppWvUser> peappwvusers = db.peAppWvUsers;
            DataSourceResult result = peappwvusers.ToDataSourceResult(request, peAppWvUser => new
            {
                Id = peAppWvUser.Id,
                code = peAppWvUser.code,
                name = peAppWvUser.name,
                dept = peAppWvUser.dept,
                SubDept = peAppWvUser.SubDept,
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvUsers_Create([DataSourceRequest]DataSourceRequest request, UserVm vm)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvUser
                {
                    code = vm.code,
                    name = vm.name,
                    // 6个1
                    password = "111111",
                    dept = vm.dept,
                    SubDept = vm.SubDept,
                };

                db.peAppWvUsers.Add(entity);
                db.SaveChanges();
                vm.Id = entity.Id;
            }

            return Json(new[] { vm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvUsers_Update([DataSourceRequest]DataSourceRequest request, UserVm vm)
        {
            if (ModelState.IsValid)
            {

                db.peAppWvUsers.Where(u => u.Id == vm.Id).Update(u=>new peAppWvUser
                {
                    code = vm.code,
                    name = vm.name,
                    dept = vm.dept,
                    SubDept = vm.SubDept,
                });
                db.SaveChanges();

            }

            return Json(new[] { vm }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult peAppWvUsers_Destroy([DataSourceRequest]DataSourceRequest request, UserVm vm)
        {
            if (ModelState.IsValid)
            {
                var entity = new peAppWvUser
                {
                    Id = vm.Id,
                    code = vm.code,
                    name = vm.name,
                    dept = vm.dept,
                    SubDept = vm.SubDept,
                };

                db.peAppWvUsers.Attach(entity);
                db.peAppWvUsers.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { vm }.ToDataSourceResult(request, ModelState));
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
