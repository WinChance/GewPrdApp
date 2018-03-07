namespace GewPeApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("peAppWvMenu")]
    public partial class peAppWvMenu
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string code { get; set; }

        [Required]
        [StringLength(30)]
        public string text { get; set; }

        [Required]
        [StringLength(50)]
        public string activityname { get; set; }

        [Required]
        [StringLength(30)]
        public string dept { get; set; }
    }
}
