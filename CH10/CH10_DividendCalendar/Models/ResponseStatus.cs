using System.Collections.Generic;

namespace CH10_DividendCalendar.Models
{
    public class ResponseStatus
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public List<Dictionary<string, string>> Errors { get; set; }
        public List<Dictionary<string, string>> Meta { get; set; }
    }
}
