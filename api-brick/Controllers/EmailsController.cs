using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Models;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace api_brick.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : Controller
    {
        [Route("SendNotification")]
        [HttpPost]
        public async Task PostMessage(Email email)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("brick.developers@gmail.com", "Constructora Mejia Polanco");
            var to = new EmailAddress(email.Correo, email.Nombre) ;
            var plainTextContent = "Saludos";
            var subject = email.Subject;
            var htmlContent = email.Htmlcontent;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}