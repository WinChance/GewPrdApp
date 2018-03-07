using System.Collections.Generic;

namespace GMS.Web.Admin.Models
{
    public class UserMenuViewModel
    {
        public string code { get; set; }
        public string name { get; set; }
        // 具体的部门，如织一，织二
        public string dept { get; set; }

        public string SubDept { get; set; }

        public IEnumerable<ItemViewModel> menu { get; set; }
    }


}