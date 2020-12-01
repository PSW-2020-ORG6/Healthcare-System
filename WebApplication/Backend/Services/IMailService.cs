using Model.Accounts;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This interface for class MailService
    /// </summary>
    public interface IMailService
    {
        void SendEmail(Patient patient);
    }
}
