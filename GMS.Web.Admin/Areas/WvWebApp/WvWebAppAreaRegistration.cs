using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.WvWebApp
{
    public class WvWebAppAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WvWebApp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WvWebApp_default",
                "WvWebApp/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}