using System.ComponentModel.DataAnnotations;

namespace GMS.Web.Admin.Areas.WvWebApp.Models
{
    public class ManageViewModels
    {
        public class ChangePasswordViewModel
        {

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "工号")]
            public string Code { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "当前密码")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "新密码")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "确认新密码")]
            [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
            public string ConfirmPassword { get; set; }
        }
    }
}