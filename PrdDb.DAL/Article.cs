using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("Article")]
    public partial class Article
    {
        public int id { get; set; }

        public DateTime? timestamp { get; set; }

        [StringLength(20)]
        public string author { get; set; }

        [StringLength(20)]
        public string reviewer { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        public int? importance { get; set; }

        [StringLength(2)]
        public string type { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        public int? pageviews { get; set; }
    }
}
