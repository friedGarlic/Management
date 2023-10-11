using AutoMapper.Configuration.Annotations;
using Management.Application.Contracts.Infrastructure;
using Management.Application.Model;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace Management.Infrastructure.Mail
{
    public class EmailServices : IEmailServices
    {
        public EmailSetting _emailSetting { get; }

        public EmailServices(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSetting.APIkey);
            var to = new EmailAddress(email.To);

            var doEmail = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };

            var message = MailHelper.CreateSingleEmail(doEmail, to, email.Body, email.Body, email.Body);

            var response = await client.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}