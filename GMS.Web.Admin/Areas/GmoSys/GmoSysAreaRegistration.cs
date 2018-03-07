using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.GmoSys
{
    public class GmoSysAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GmoSys";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GmoSys_default",
                "GmoSys/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}