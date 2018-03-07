namespace PrdDb.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("peAppWvUserMenu")]
    public partial class peAppWvUserMenu
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string usercode { get; set; }

        [Required]
        [StringLength(10)]
        public string menucode { get; set; }
    }
}
