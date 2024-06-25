using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using TestApplication.Models;
using MimeKit;


namespace TestApplication.Service
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfig;

        public void SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolders("Hello {{UserName}}, Confirm your email id.", userEmailOptions.PlaceHolders);

            userEmailOptions.Body = UpdatePlaceHolders(GetEmailBody("EmailConfirm"), userEmailOptions.PlaceHolders);

            SendEmail(userEmailOptions);
        }

        public void SendEmailForForgotPassword(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolders("Hello {{UserName}}, reset your password.", userEmailOptions.PlaceHolders);

            userEmailOptions.Body = UpdatePlaceHolders(GetEmailBody("ForgotPassword"), userEmailOptions.PlaceHolders);

            SendEmail(userEmailOptions);
        }

        public EmailService(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        private void SendEmail(UserEmailOptions userEmailOptions)
        {

            List<MailboxAddress> list = new List<MailboxAddress>();
            foreach (var item in userEmailOptions.ToEmails)
            {
                list.Add(new MailboxAddress("email", item));
            }
            
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _smtpConfig.From));
            emailMessage.To.AddRange(list);
            emailMessage.Subject = userEmailOptions.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = userEmailOptions.Body };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                client.Connect(_smtpConfig.SmtpServer, _smtpConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XQAUTH2");
                client.Authenticate(_smtpConfig.UserName, _smtpConfig.Password);

                client.Send(emailMessage);
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }

        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }

        private string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach (var placeholder in keyValuePairs)
                {
                    if (text.Contains(placeholder.Key))
                    {
                        text = text.Replace(placeholder.Key, placeholder.Value);
                    }
                }
            }

            return text;
        }
    }
}
