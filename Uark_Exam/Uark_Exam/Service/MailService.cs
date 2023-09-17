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
            string senderEmail = "enter your email";
            string senderPassword = "enter your password";
           
            string recipientEmail = email;

            // Create a new MailMessage
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
           
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