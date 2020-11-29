﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using WebApplication.Backend.Model;
using Model.Accounts;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This class performs email sending
    /// </summary>
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///email sending
        ///</summary>
        ///<param name="patient"> Patient type object
        ///</param>>
        public void SendEmailAsync(Patient patient)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(patient.Email));
            email.Subject = $"Welcome {patient.Name}";
            var builder = new BodyBuilder();

            string id1 = ParseId(patient.Id);

            builder.HtmlBody = "Please click on this link to confirm registration <a href=\"http://localhost:49900/#/emailConfirmation?id=" + id1 + "\">link</a>";
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            /*await*/ smtp.Send(email);
            smtp.Disconnect(true);
        }

        ///Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///id encryption 
        ///</summary>
        ///<returns>
        ///patient id
        ///</returns>
        ///<param name="patientId"> String type object
        ///</param>>
        private string ParseId(string patientId)
        {
            int id = int.Parse(patientId) - 6789 + 23 * 33;
            return id.ToString();
        }

    }
}
