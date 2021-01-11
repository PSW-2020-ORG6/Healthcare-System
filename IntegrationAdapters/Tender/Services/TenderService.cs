using IntegrationAdapters.Models;
using IntegrationAdapters.Models.DTO;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class TenderService
    {
        private ITenderRepository tenderRepository;

        public TenderService()
        {
            this.tenderRepository = new TenderRepository();
        }

        public TenderService(ITenderRepository tenderRepository)
        {
            this.tenderRepository = tenderRepository;
        }

        public bool AddTender(Tender tender)
        {
            return tenderRepository.AddTender(tender);
        }

        public List<Tender> GetAllTenders()
        {
            return tenderRepository.GetAllTenders();
        }
        public Tender GetTenderByName(string name) 
        {
            foreach(Tender t in GetAllTenders()){
                if (t.TenderName.Equals(name))
                    return t;
            }
            return null;
        }
        public bool AddOffer(TenderOffer offer)
        {
            return tenderRepository.AddOffer(offer);
        }

        public List<TenderOffer> GetAllOffers()
        {
            return tenderRepository.GetAllOffers();
        }
        public bool AddMedicine(MedicineDTO medicineDTO)
        {
            return tenderRepository.AddMedicine(medicineDTO);
        }

        public List<MedicineDTO> GetAllMedicines(string tenderName)
        {
            List<MedicineDTO> result = new List<MedicineDTO>();
            foreach(MedicineDTO m in tenderRepository.GetAllMedicines())
            {
                if (m.TenderName.Equals(tenderName))
                {
                    result.Add(m);
                }
            }
            return result;
        }
        public List<TenderOffer> GetAllOffersByEmailAndTender(String emailAndTender)
        {
            return tenderRepository.GetAllOffersByEmailAndTender(emailAndTender);
        }

        public void SendNotificationAboutTender(string mailAddressTo, string text)
        {
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress mailAddressFrom = new MailAddress("hospitallhospital@gmail.com");
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = mailAddressFrom;
                mail.To.Add(mailAddressTo);
                mail.Subject = "Notification about tender result";
                mail.Body = text;

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

        public void ClearAll(string tenderName)
        {
            tenderRepository.ClearAll(tenderName);
        }

        public List<string> GetAllEmails()
        {
            List<string> result = new List<string>();
            foreach(TenderOffer t in GetAllOffers())
            {
                result.Add(t.CompanyEmail);
            }
            return null;
        }
        public void SendNotification(TenderOffer t, string companyEmail, string tenderName)
        {
            MedicineService medicineService = new MedicineService();
            if (t.CompanyEmail.Equals(companyEmail) && t.TenderName.Equals(tenderName))
            {
                Tender finishedTender = GetTenderByName(tenderName);
                finishedTender.IsActive = false;
                tenderRepository.SaveChanges();
                SendNotificationAboutTender(companyEmail, "Your offer is accepted!");
                medicineService.AddMedicineFromTender(t.MedicineName, t.Quantity);
            }
            else
            {
                if (t.TenderName.Equals(tenderName))
                {
                    SendNotificationAboutTender(t.CompanyEmail, "Your offer is refused!");
                }
            }
        }
        

    }
}
