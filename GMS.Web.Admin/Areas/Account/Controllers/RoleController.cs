using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GMS.Account.Contract;
using GMS.Account.Contract.Model;
using GMS.Framework.Contract;
using GMS.Web.Admin.Common;
using GMS.Framework.Utility;

namespace GMS.Web.Admin.Areas.Account.Controllers
{
    [Permission(EnumBusinessPermission.AccountManage_Role)]
    public class RoleController : AdminControllerBase
    {
        //
        // GET: /Account/peAppRole/

        public ActionResult Index(RoleRequest request)
        {
            var result = this.AccountService.GetRoleList(request);
            return View(result);
        }

        //
        // GET: /Account/peAppRole/Create

        public ActionResult Create()
        {
            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value");
            
            var model = new peAppRole();
            return View("Edit", model);
        }

        //
        // POST: /Account/peAppRole/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new peAppRole();
            this.TryUpdateModel<peAppRole>(model);

            this.AccountService.SaveRole(model);

            return this.RefreshParent();
        }

        //
        // GET: /Account/peAppRole/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.AccountService.GetRole(id);

            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value", string.Join(",", model.BusinessPermissionList.Select(p => (int)p)));

            return View(model);
        }

        //
        // POST: /Account/peAppRole/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.AccountService.GetRole(id);
            this.TryUpdateModel<peAppRole>(model);
            model.BusinessPermissionString = collection["BusinessPermissionList"];
            this.AccountService.SaveRole(model);

            return this.RefreshParent();
        }

        // POST: /Account/peAppRole/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.AccountService.DeleteRole(ids);
            return RedirectToAction("Index");
        }
    }
}
