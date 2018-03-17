using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GMS.Web.Admin.Service.SignalR;
using Quartz;

namespace GMS.Web.Admin.Service.Quartz
{
    public class Yd2PrShouSongZhouPushJob : IJob
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)//必须实现IJob接口下的Execute方法
        {
            // 定时推送消息
            PushHub.Instance.PushYdDaiSongZhouInfo();
        }
    }
}