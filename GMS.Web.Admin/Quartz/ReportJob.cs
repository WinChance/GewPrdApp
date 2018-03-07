using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using GMS.Web.Admin.Hub;
using Quartz;

namespace GMS.Web.Admin.Quartz
{
    public class ReportJob : IJob
    {
        public void Execute(IJobExecutionContext context)//必须实现IJob接口下的Execute方法
        {
            var reportDirectory = string.Format("~/reports/{0}/", DateTime.Now.ToString("yyyy-MM"));
            reportDirectory = System.Web.Hosting.HostingEnvironment.MapPath(reportDirectory);
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }
            var dailyReportFullPath = string.Format("{0}report_{1}.log", reportDirectory, DateTime.Now.Day);
            var logContent = string.Format("{0}==>>{1}{2}", DateTime.Now, "create new log.", Environment.NewLine);
            File.AppendAllText(dailyReportFullPath, logContent);
            // 定时推送消息
            PushHub.Instance.SendNewTaskInfo();
        }
    }
}