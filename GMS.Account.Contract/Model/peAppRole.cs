using System.Collections.Generic;
using System.Linq;
using GMS.Framework.Contract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GMS.Account.Contract.Model;

namespace GMS.Account.Contract
{
    [Auditable]
    [Table("peAppRole")]
    public class peAppRole : ModelBase   
    {
        [Required(ErrorMessage = "角色名不能为空")]
        public string Name { get; set; }
        public string Info { get; set; }

        public virtual List<peAppUser> Users { get; set; }


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
}
