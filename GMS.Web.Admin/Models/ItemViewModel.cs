using System;

namespace GMS.Web.Admin.Models
{
    /// <summary>
    /// 通用对象，用于菜单表和下拉列表
    /// </summary>
    public class ItemViewModel
    {
        private int _id;
        private string _renderflat;
        public int id
        {
            get
            {
                if (_id == null)
                {
                    return 0;
                }
                else
                {
                    return _id;
                }
            }
            set { _id = value; }
        }
        public String picurl { get; set; }
        public String code { get; set; }
        public String text { get; set; }
        public String dest1 { get; set; }
        public String dest2 { get; set; }
        public String dest3 { get; set; }
        // 样式
        public string renderflat
        {
            get
            {
                if (_renderflat==null)
                {
                    return "TYPE_content";
                }
                return _renderflat;
            }

            set { _renderflat = value; }
        }
    }
}