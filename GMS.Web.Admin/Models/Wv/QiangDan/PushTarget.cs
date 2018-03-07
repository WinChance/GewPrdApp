using System.Collections.Generic;

namespace GMS.Web.Admin.Models.Wv.QiangDan
{
    public class PushTarget
    {
        public IList<string> ConnectIds { get; set; }

        public int TaskCounts { get; set; } 
    }
}