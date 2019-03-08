using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace api_brick.Tools
{
    public class EmailSender
    {
        public void SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Jossias","jossias.vel@gmail.com"));

            message.To.Add(new MailboxAddress("Jossias","jossias.vel@gmail.com"));

            message.Subject = "Testing emails .net Core";
            message.Body = new TextPart("plain") { Text = "testing mail send form .net core" };


            using (SmtpClient client  = new SmtpClient())
            {
         
            }
           
        }
    }
}
