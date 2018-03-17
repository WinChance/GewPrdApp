using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using GMS.Web.Admin.Areas.WvWebApp.Models;
using PrdDb.DAL;

namespace GMS.Web.Admin.Areas.WvWebApp.Controllers
{
    public class ManageController : Controller
    {
        private PrdAppDbContext db = new PrdAppDbContext();

        // GET: WvWebApp/Manage
        public ActionResult ChangePassword(ManageViewModels.ChangePasswordViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            //db.peAppWvUsers.Where(m => m.code.Equals(model.Code)).SingleOrDefault().password;
            //var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            //if (result.Succeeded)
            //{
            //    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            //    if (user != null)
            //    {
            //        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            //    }
            //    return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            //}
            //AddErrors(result);
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }


}