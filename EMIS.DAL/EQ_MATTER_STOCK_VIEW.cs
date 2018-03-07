namespace EMIS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EQ_MATTER_STOCK_VIEW
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string s_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string s_name { get; set; }

        [StringLength(100)]
        public string s_type { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? c_cstock { get; set; }

        [StringLength(30)]
        public string d_name { get; set; }
    }
}
