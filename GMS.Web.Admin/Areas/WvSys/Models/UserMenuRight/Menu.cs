namespace GMS.Web.Admin.Areas.WvSys.Models.UserMenuRight
{
    public class Menu
    {
        // Checkbox的标识
        public string Id { get; set; }

        // Checkbox的名字
        public string Name { get; set; }

        // Checkbox是否被选中，布尔类型
        public bool IsSelected { get; set; }

        //Object of html tags to be applied
        //to checkbox, e.g.:'new{tagName = "tagValue"}'
        // 
        public object Tags { get; set; }
    }
}