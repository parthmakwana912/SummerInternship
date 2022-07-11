using System.Collections.Generic;

namespace BookStre.Models.Models
{
    public class ListResponse<T> where T : class
    {
        public IEnumerable<T> Results { get; set; }

        public int TotalRecords { get; set; }
    }
}
