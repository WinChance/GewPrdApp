using System.Collections.Generic;
using System.Linq;
using GMS.Framework.Contract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GMS.Account.Contract.Model;

namespace GMS.Account.Contract
{
    [Auditable]
    [Table("peAppUser")]
    public partial class peAppUser : ModelBase
    {
        public peAppUser()
        {
            this.Roles = new List<peAppRole>();
            this.IsActive = true;
            this.RoleIds = new List<int>();
        }

        /// <summary>
        /// 登录名
        /// </summary>
        [Required(ErrorMessage = "登录名不能为空")]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码，使用MD5加密
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "电子邮件地址无效")]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public virtual List<peAppRole> Roles { get; set; }

        [NotMapped]
        public List<int> RoleIds { get; set; }

        [NotMapped]
        public string NewPassword { get; set; }

        [NotMapped]
        public List<EnumBusinessPermission> BusinessPermissionList
        {
            get
            {
                var permissions = new List<EnumBusinessPermission>();

                foreach (var role in Roles)
                {
                    permissions.AddRange(role.BusinessPermissionList);
                }

                return permissions.Distinct().ToList();
            }
        }
    }
}
