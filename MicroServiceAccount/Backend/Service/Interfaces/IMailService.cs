using MicroServiceAccount.Backend.Model;
//using HealthClinicBackend.Backend.Model.Accounts

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
