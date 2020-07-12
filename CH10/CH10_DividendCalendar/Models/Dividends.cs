using System.Collections.Generic;

namespace CH10_DividendCalendar.Models
{
    public class Dividends
    {
        public int Total { get; set; }
        public int Offset { get; set; }
        public List<Dictionary<string, string>> Results { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
