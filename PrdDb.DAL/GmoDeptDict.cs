using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("GmoDeptDict")]
    public partial class GmoDeptDict
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string DeptName { get; set; }

        [StringLength(20)]
        public string Remark { get; set; }
    }
}
