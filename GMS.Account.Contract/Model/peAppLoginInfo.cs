using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using GMS.Framework.Contract;
using GMS.Framework.Utility;

namespace GMS.Account.Contract.Model
{
    [Serializable]
    [Table("peAppLoginInfo")]
    public class peAppLoginInfo : ModelBase
    {
        public peAppLoginInfo()
        {
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid();
        }

        public peAppLoginInfo(int userID, string loginName)
        {
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid();

            UserID = userID;
            LoginName = loginName;
        }

        public Guid LoginToken { get; set; }
        public DateTime LastAccessTime { get; set; }
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string ClientIP { get; set; }

        public EnumLoginAccountType EnumLoginAccountType { get; set; }

        public string BusinessPermissionString { get; set; }

        [NotMapped]
        public List<EnumBusinessPermission> BusinessPermissionList
        {
            get
            {
                if (string.IsNullOrEmpty(BusinessPermissionString))
                    return new List<EnumBusinessPermission>();
                else
                    return BusinessPermissionString.Split(",".ToCharArray()).Select(p => int.Parse(p)).Cast<EnumBusinessPermission>().ToList();
            }
            set
            {
                BusinessPermissionString = string.Join(",", value.Select(p => (int)p));
            }
        }
    }

    [Flags]
    public enum EnumLoginAccountType
    {
        [EnumTitle("[无]", IsDisplay = false)]
        Guest = 0,
        /// <summary>
        /// 管理员
        /// </summary>
        [EnumTitle("管理员")]
        Administrator = 1,
    }


}



