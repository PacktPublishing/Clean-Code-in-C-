using System.Collections.Generic;

namespace CH10_DividendCalendar.Models
{
    public class Companies
    {
        public int Total { get; set; }
        public int Offset { get; set; }
        public List<Company> Results { get; set; }
        public string ResponseStatus { get; set; }
    }
}
