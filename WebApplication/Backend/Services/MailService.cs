using HealthClinicBackend.Backend.Model.Accounts;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using WebApplication.Backend.Model;

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

        /// <summary>
        ///email sending
        ///</summary>
        ///<param name="patient"> Patient type object
        ///</param>>
        public void SendEmail(Patient patient)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(patient.Email));
            email.Subject = $"Welcome {patient.Name}";
            var builder = new BodyBuilder();
            string id1 = IdEncryption(patient.Id);
            builder.HtmlBody = "Please click on this link to confirm registration <a href=\"http://localhost:49900/#/emailConfirmation?id=" + id1 + "\">link</a>";
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            /*await*/
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        /// <summary>
        ///id encryption to send email 
        ///</summary>
        ///<returns>
        ///patient id
        ///</returns>
        ///<param name="patientId"> String type object
        ///</param>>
        private string IdEncryption(string patientId)
        {
            long id = long.Parse(patientId) - 6789 + 23 * 33;
            return id.ToString();
        }
    }
}
