using MicroServiceAccount.Backend.Model;

namespace MicroServiceAccount.Backend.Services.Interfaces
{
    /// <summary>
    /// This interface for class MailService
    /// </summary>
    public interface IMailService
    {
        void SendEmail(Patient patient);
    }
}
