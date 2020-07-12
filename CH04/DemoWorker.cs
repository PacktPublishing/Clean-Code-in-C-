using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CH4
{
    public class DemoWorker
    {
        TextFileData _textFileData;

        public void DoWork()
        {
            SaveTextFile();
            SendEmail();
        }
        
        public void SendEmail()
        {
            Smtp smtp = new Smtp(new Credential("fakegmail@gmail.com", "fakeP@55w0rd"));
            smtp.SendMessage(GetMailMessage());
        }
        
        private MailMessage GetMailMessage()
        {
            var msg = new MailMessage();
            msg.From = new MailAddress("fakegmail@gmail.com");
            msg.To.Add(new MailAddress("fakehotmail@hotmail.com"));
            msg.Subject = "Some subject";
            msg.IsBodyHtml = true;
            msg.Body = "Hello World!";
            msg.Attachments.Add(GetAttachment());
            return msg;
        }

        private Attachment GetAttachment()
        {
            var attachment = new Attachment(_textFileData.FileName);
            attachment.ContentDisposition.Inline = false;
            attachment.ContentDisposition.DispositionType = DispositionTypeNames.Attachment;
            attachment.ContentType.MediaType = MimeType.TextPlain.Description();
            attachment.ContentType.Name =
            Path.GetFileName(_textFileData.FileName);
            return attachment;
        }
        
        private void SaveTextFile()
        {
            _textFileData = new TextFileData($"{Environment.SpecialFolder.MyDocuments}attachment", "Here is some demo text!");
            _textFileData.SaveTextFile();
        }
    }
}
