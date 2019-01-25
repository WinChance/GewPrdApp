using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using StackExchange.Profiling.EntityFramework6;

namespace GMS.Web.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
#if DEBUG
            MiniProfilerEF6.Initialize();
            
#endif
            AreaRegistration.RegisterAllAreas();
            // 注册webapi
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //在这里调用
            //ReportJobScheduler.Start();
            //Yd2PrShouSongZhouPushJobScheduler.Start();

            //RouteTable.Routes.MapHubs();
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(50);

        }
        /// <summary>
        /// IIS应用池回收造成Application_Start中定时执行程序停止的问题的解决方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {
            // 在应用程序关闭时运行的代码 
            //解决应用池回收问题 
            System.Threading.Thread.Sleep(5000);
            string strUrl = "192.168.7.38/GEWProductivityApp";
            //string strUrl = "192.168.22.125:8888";
            System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strUrl);
            System.Net.HttpWebResponse _HttpWebResponse = (System.Net.HttpWebResponse)_HttpWebRequest.GetResponse();
            System.IO.Stream _Stream = _HttpWebResponse.GetResponseStream();//得到回写的字节流 
        } 

        protected void Application_BeginRequest(Object source, EventArgs e)
        {
#if DEBUG
            //MiniProfiler.Start();
#endif
        }
        protected void Application_EndRequest()
        {
#if DEBUG
            //MiniProfiler.Stop();
#endif
        }
    }
}
