using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GMS.Account.Contract;
using GMS.Account.Contract.Model;
using GMS.Web.Admin.Common;
using GMS.Framework.Utility;
using GMS.Framework.Contract;

namespace GMS.Web.Admin.Areas.Account.Controllers
{
    [Permission(EnumBusinessPermission.AccountManage_User)]
    public class UserController : AdminControllerBase
    {
        //
        // GET: /Account/peAppUser/

        public ActionResult Index(UserRequest request)
        {
            var result = this.AccountService.GetUserList(request);
            return View(result);
        }

        //
        // GET: /Account/peAppUser/Create

        public ActionResult Create()
        {
            var roles = this.AccountService.GetRoleList();
            this.ViewBag.RoleIds = new SelectList(roles, "ID", "Name");
            
            var model = new peAppUser();
            model.Password = "111111";
            return View("Edit", model);
        }

        //
        // POST: /Account/peAppUser/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new peAppUser();
            this.TryUpdateModel<peAppUser>(model);
            model.Password = "111111";
            model.Password = Encrypt.MD5(model.Password);

            try
            {
                this.AccountService.SaveUser(model);
            }
            catch (BusinessException e)
            {
                this.ModelState.AddModelError(e.Name, e.Message);

                var roles = this.AccountService.GetRoleList();
                this.ViewBag.RoleIds = new SelectList(roles, "ID", "Name");

                return View("Edit", model);
            }

            return this.RefreshParent();
        }

        //
        // GET: /Account/peAppUser/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.AccountService.GetUser(id);

             var roles = this.AccountService.GetRoleList();
             this.ViewBag.RoleIds = new SelectList(roles, "ID", "Name", string.Join(",", model.Roles.Select(r => r.ID)));

            return View(model);
        }

        //
        // POST: /Account/peAppUser/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.AccountService.GetUser(id);
            this.TryUpdateModel<peAppUser>(model);
            this.AccountService.SaveUser(model);

            return this.RefreshParent();
        }

        // POST: /Account/peAppUser/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.AccountService.DeleteUser(ids);
            return RedirectToAction("Index");
        }
    }
}
