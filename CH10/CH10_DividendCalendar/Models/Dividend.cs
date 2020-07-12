using System;

namespace CH10_DividendCalendar.Models
{
    public class Dividend
    {
        public string Mic { get; set; }
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public float DividendYield { get; set; }
        public float Amount { get; set; }
        public DateTime? ExDividendDate { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string DividendType { get; set; }
        public string CurrencyCode { get; set; }
    }
}
