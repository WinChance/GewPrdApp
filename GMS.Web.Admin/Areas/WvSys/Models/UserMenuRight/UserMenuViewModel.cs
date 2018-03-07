using System.Collections.Generic;

namespace GMS.Web.Admin.Areas.WvSys.Models.UserMenuRight
{
    public class UserMenuViewModel
    {
        public IEnumerable<Menu> AvailableMenus { get; set; }
        public IEnumerable<Menu> SelectedMenus { get; set; }
        public PostedUserMenus PostedUserMenus { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
    }
}