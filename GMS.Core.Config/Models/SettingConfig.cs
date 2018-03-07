using System;

namespace GMS.Core.Config
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    [Serializable]
    public class SettingConfig : ConfigFileBase
    {
        public SettingConfig()
        {
        }

        #region 序列化属性
        public String WebSiteTitle { get; set; }
        public String WebSiteDescription { get; set; }
        public String WebSiteKeywords { get; set; }
        #endregion
    }
}
