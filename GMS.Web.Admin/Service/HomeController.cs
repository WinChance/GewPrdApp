using System.Web.Mvc;

namespace GMS.Web.Admin.Service
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Auth", new { Area = "Account" });
        }
    }
}
