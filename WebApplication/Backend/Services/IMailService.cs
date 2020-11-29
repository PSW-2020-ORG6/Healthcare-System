using Model.Accounts;
using System.Threading.Tasks;

namespace WebApplication.Backend.Services
{
    /// <summary>
    /// This interface for class MailService
    /// </summary>
    public interface IMailService
    {
        Task SendEmailAsync(Patient patient);
    }
}
