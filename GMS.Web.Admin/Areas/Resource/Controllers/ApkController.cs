using System;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Resource.Controllers
{
    // Resource/Apk/GetUpdate
    public class ApkController : Controller
    {
        /// <summary>
        /// MVC返回文件，供下载
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUpdate()
        {
            // 文件名
            string filename = "GewPeApp.apk";
            // 拼接路径
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Resource/AppUpdate/" + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
        /// <summary>
        /// 返回Apk的版本号
        /// </summary>
        /// <returns></returns>
        public ActionResult GetApkVersion()
        {
            // 文件名
            //string filename = "Version.txt";
            string filename = "Version.xml";
            // 拼接路径
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Resource/AppUpdate/" + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}