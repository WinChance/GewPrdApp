namespace GMS.Web.Admin.Areas.WvSys.Models.UserMenuRight
{
    /// <summary>
    /// 提交保存的员工号和他将拥有的菜单权限ID
    /// </summary>
    public class PostedUserMenus
    {
        public string UserCode { get; set; }
        public string[] MenuIds { get; set; }
    }
}