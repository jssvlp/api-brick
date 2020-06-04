using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace api_brick.Services
{
    public class EmailService
    {

        IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(Email email)
        {
            var apiKey = _configuration["SENDGRID_API_KEY"];//"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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration["NOTIFICATION_MAIL"], "Constructora Mejia Polanco");
            var to = new EmailAddress(email.Correo, email.Nombre);
            var plainTextContent = "Saludos";
            var subject = email.Subject;
            var htmlContent = email.Htmlcontent;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }

        public  async Task SendResetToken(Email email,string token)
        {
            SendGridClient sendGridClient = new SendGridClient(_configuration["SENDGRID_API_KEY"]);

            Dictionary<string, string> tkn = new Dictionary<string, string>();
            tkn.Add("token", token);
            
           

            var from = new EmailAddress(_configuration["NOTIFICATION_MAIL"], "Constructora Mejia Polanco");
            var to = new EmailAddress(email.Correo, email.Nombre);

            SendGridMessage sendGridMessage = MailHelper.CreateSingleTemplateEmail(
                from,
                to,
                _configuration["RESET_PASSWORD_TEMPLATE"],
                tkn
                );
            
            sendGridMessage.Subject = email.Subject;
            Response sendGridResponse = await sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}
