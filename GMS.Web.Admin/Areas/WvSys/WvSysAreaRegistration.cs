using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.WvSys
{
    public class WvSysAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WvSys";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WvSys_default",
                "WvSys/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}