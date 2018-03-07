using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMS.Web.Admin.Models.Yd
{
    /// <summary>
    /// RtCheckYarn传输模型
    /// </summary>
    public class SsCheckYarnBindingModel
    {
        /// <summary>
        /// 输入时间
        /// </summary>
        public DateTime InputDate { get; set; }
        /// <summary>
        ///  机台号
        /// </summary>
        public int MachineNo { get; set; }
        /// <summary>
        /// 缸号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 检查个数
        /// </summary>
        public int CheckNum { get; set; }
        /// <summary>
        /// 操作类
        /// </summary>
        public string OperateType { get; set; }
        /// <summary>
        /// 松紧个数
        /// </summary>
        public int SongjinNum { get; set; }
        /// <summary>
        /// 大小差异个数
        /// </summary>
        public int DaxiaoDiffNum { get; set; }
        /// <summary>
        /// 成型不良
        /// </summary>
        public int ChengxingBadNum { get; set; }
        /// <summary>
        /// 班别
        /// </summary>
        public string WorkerClass { get; set; }
        /// <summary>
        /// 检查人
        /// </summary>
        public string CheckerName { get; set; }
    }
}