using System.Collections;

namespace GMS.Web.Admin.Models
{
    public class QueryResult
    {
        public IEnumerable Data { get; set; }

        public int Total { get; set; }

        //public IEnumerable<AggregateResult> AggregateResults { get; set; }

        public object Errors { get; set; }
    }
}