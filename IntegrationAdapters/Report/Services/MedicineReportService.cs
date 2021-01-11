using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.Util;

namespace IntegrationAdapters.Services
{
    public class MedicineReportService
    {
        private IMedicineReportRepository medicineReportRepository;

        public MedicineReportService()
        {
            this.medicineReportRepository = new MedicineReportRepository();
        }

        public MedicineReportService(IMedicineReportRepository imedicineReportRepository)
        {
            this.medicineReportRepository = imedicineReportRepository;
        }

        public void AddPrescription()
        {
            medicineReportRepository.AddPrescription();
        }

        public List<MedicineReport> GetAll()
        {
            return medicineReportRepository.GetAll();
        }

        public List<MedicineReport> GetByDateInterval(TimeInterval timeInterval)
        {
            List<MedicineReport> result = new List<MedicineReport>();

            foreach (MedicineReport m in GetAll())
            {
                if (m.Date >= timeInterval.Start && m.Date <= timeInterval.End)
                {
                    result.Add(m);
                }
            }
            return result;
        }

        public void SendNotificationAboutReport(String myFile)
        {
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress mailAddressFrom = new MailAddress("hospitallhospital@gmail.com");
                MailAddress mailAddressTo = new MailAddress("ppharmacy98@gmail.com");
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = mailAddressFrom;
                mail.To.Add(mailAddressTo);
                mail.Subject = "Notification about sent file";
                mail.Body = "You can take file " + myFile;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hospitallhospital@gmail.com", "Hh123456789");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
