using System;
using System.Net;
using System.Net.Mail;
using Uark_Exam.Interface;

namespace Uark_Exam.Service
{
    public class MailService : IMailService
    {
        public void SendMail(string email, string subject, string body)
        {
            // Sender's email address and password (you should use app-specific password for security)
            string senderEmail = "your_email@gmail.com";
            string senderPassword = "your_password";

            // Recipient's email address
            string recipientEmail = email;

            // Create a new MailMessage
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);
            mail.Subject = subject;
            mail.Body = body;

            // Create a SmtpClient instance
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; // Gmail SMTP port
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true; // Enable SSL for secure email sending


            // Send the email
            smtpClient.Send(mail);
        }
        
    }
}