using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMS.Web.Admin.Areas.WvSys.Models.UserMaintain
{
    public class UserVm
    {
        public int Id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        //public string password { get; set; }

        public string dept { get; set; }

        //public string NfcCardNo { get; set; }

        public string SubDept { get; set; }

        //public string ConnectionId { get; set; }

        //public bool IsLogin { get; set; }

    }
}