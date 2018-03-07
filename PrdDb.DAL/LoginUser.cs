using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("LoginUser")]
    public partial class LoginUser
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Passward { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        [StringLength(10)]
        public string Name { get; set; }
    }
}
