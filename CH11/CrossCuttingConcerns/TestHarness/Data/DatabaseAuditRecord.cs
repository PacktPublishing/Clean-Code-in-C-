using System;
using TestHarness.Models;

namespace TestHarness.Data
{
    public class DatabaseAuditRecord
    {
        public DatabaseAuditRecord(string user, BusinessObject businessObject, string method, string description)
        {
            User = user;
            BusinessObject = businessObject;
            Method = method;
            Description = description;
        }

        public BusinessObject BusinessObject { get; }
        public string Method { get; }
        public string User { get; }
        public string Description { get; }
        public DateTimeOffset Time { get; } = DateTimeOffset.Now;

        public void AppendToDatabase()
        {
            Console.WriteLine(
                $"TODO - Write to the database: {{BusinessObjectId={BusinessObject.Id}, Operation={Method}, Description=\"{Description}\", User={User}}}.");
        }
    }
}