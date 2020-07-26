using System;
using System.Net;
using System.Net.Mail;

namespace MyProject.Helpers
{
    public class GoogleMailer
    {
        static string email = "aspnet1112011@gmail.com";//vui lòng sửa mail của bạn
        static string password = "2m@il2011";//vui lòng sửa password của bạn

        // Gửi mail từ hệ thống
        public static void Send(string to, string subject, string body)
        {
            var from = "Administration System <" + email + ">";
            GoogleMailer.Send(from, to, "", "", subject, body, "");
        }

        // Gửi mail đơn giản
        public static void Send(string from, string to, string subject, string body)
        {
            GoogleMailer.Send(from, to, "", "", subject, body, "");
        }

        // Gửi mail nhiều lựa chọn đầy đủ
        public static void Send(string from, string to, string cc, string bcc, string subject, string body, string attachments)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            //mail.ReplyTo = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(cc);
            }
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(bcc);
            }
            if (!string.IsNullOrEmpty(attachments))
            {
                string[] fileNames = attachments.Split(";,".ToCharArray());
                foreach (string fileName in fileNames)
                {
                    if (fileName.Trim().Length > 0)
                    {
                        mail.Attachments.Add(new Attachment(fileName.Trim()));
                    }
                }
            }

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(email, password);
            client.Send(mail);
        }
    }
}
