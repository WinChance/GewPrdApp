using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMS.Web.Admin.Models.Wv.QiangDan
{
    public class HitedTaskInfoVm
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 机台号
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// 姓名1
        /// </summary>
        public string WeaverName1 { get; set; }
        /// <summary>
        /// 姓名2
        /// </summary>
        public string WeaverName2 { get; set; }
        /// <summary>
        /// 姓名3
        /// </summary>
        public string WeaverName3 { get; set; }
        /// <summary>
        /// 抢单时间
        /// </summary>
        public DateTime HitTime { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public int TaskStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}