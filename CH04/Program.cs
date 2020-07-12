using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace CH4
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintVendorsList();
        }

        private static void PrintVendorsList()
        {
            var vendors = (from p in GetProducts()
                           select p.Vendor)
            .Distinct()
            .OrderBy(x => x);
            foreach (var vendor in vendors)
                Console.WriteLine(vendor);
            Console.ReadKey();
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product("Microsoft", "Microsoft Office"),
                new Product("Oracle", "Oracle Database"),
                new Product("IBM", "IBM DB2 Express"),
                new Product("IBM", "IBM DB2 Express"),
                new Product("Microsoft", "SQL Server 2017 Express"),
                new Product("Microsoft", "Visual Studio 2019 Community Edition"),
                new Product("Oracle", "Oracle JDeveloper"),
                new Product("Microsoft", "Azure"),
                new Product("Microsoft", "Azure"),
                new Product("Microsoft", "Azure Stack"),
                new Product("Google", "Google Cloud Platform"),
                new Product("Amazon", "Amazon Web Services")
            };
        }

//        public void UpdateUserInfo(int id, string username, string firstName,
//string lastName, string addressLine1, string addressLine2, string
//addressLine3, string addressLine4, string addressLine5, string city, string
//postcode, string region, string country, string homePhone, string
//workPhone, string mobilePhone, string personalEmail, string workEmail,
//string notes)
//        {
//            // ### implementation omitted ###
//        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            // ### implementation omitted ###
        }

        public void SrpBrokenMethod(string folder, string filename, string text,
string emailFrom, string password, string emailTo, string subject, string msg, string mediaType)
        {
            var file = $"{folder}{filename}";
            File.WriteAllText(file, text);
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(emailFrom);
            message.To.Add(new MailAddress(emailTo));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = msg;
            Attachment emailAttachment = new Attachment(file);
            emailAttachment.ContentDisposition.Inline = false;
            emailAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Attachment;
            emailAttachment.ContentType.MediaType = mediaType;
            emailAttachment.ContentType.Name = Path.GetFileName(filename);
            message.Attachments.Add(emailAttachment);
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(emailFrom, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}
