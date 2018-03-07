using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace GMS.Web.Admin.Quartz
{
    public class ReportJobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler(); //从工厂中获取一个调度器实例化
            scheduler.Start();   //开始调度器
            IJobDetail job = JobBuilder.Create<ReportJob>().Build();//创建一个作业
            ITrigger trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(t =>
                    t.WithIntervalInSeconds(10) //触发执行，60s一次
                        .RepeatForever())          //重复执行
                .Build();
            scheduler.ScheduleJob(job, trigger);       //把作业，触发器加入调度器。 
        }
    }
}