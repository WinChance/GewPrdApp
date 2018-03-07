using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.WvWebApp
{
    public class SignalRController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }
    }
}