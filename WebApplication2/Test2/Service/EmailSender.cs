using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;

namespace test3.Services
{
    public class EmailSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        [HttpPost]
        public  Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var sendGridKey = @"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";
            
            return  Execute(sendGridKey, subject, htmlMessage, email);
        }
        public async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("SalimEgamov12@mail.com", "Confirm email address"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            //return   client.SendEmailAsync(msg);
            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != HttpStatusCode.OK
                && response.StatusCode != HttpStatusCode.Accepted)
            {
                var errorMessage = response.Body.ReadAsStringAsync().Result;
                throw new Exception($"Failed to send mail to , status code {response.StatusCode}, {errorMessage}");
            }
        }
    }
}
