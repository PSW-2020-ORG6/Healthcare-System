using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Model;

namespace WebApplication.Backend.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(Patient patient/*MailRequest mailRequest*/);
        //Task SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
