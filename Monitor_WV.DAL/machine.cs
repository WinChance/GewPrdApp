using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor_WV.DAL
{
    [Table("machine")]
    public partial class machine
    {
        [Key]
        public int MachineID { get; set; }

        [StringLength(4)]
        public string MachineName { get; set; }

        public int? DeptID { get; set; }
    }
}
