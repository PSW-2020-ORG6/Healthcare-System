using IntegrationAdapters.Models;
using IntegrationAdapters.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        public DbContextOptions<IAHealthCareSystemDbContext> options = new DbContextOptionsBuilder<IAHealthCareSystemDbContext>()
               .UseNpgsql(connectionString: "server=localhost;port=5432;database=newmydb;User ID=postgres;password=super").UseLazyLoadingProxies()
               .Options;
        public readonly IAHealthCareSystemDbContext dbContext;

        public TenderRepository()
        {
            this.dbContext = new IAHealthCareSystemDbContext(options);
        }

        public bool AddTender(Tender tender)
        {
            dbContext.Add<Tender>(tender);
            dbContext.SaveChanges();
            return true;

        }

        public List<Tender> GetAllTenders()
        {
            return dbContext.Tender.ToList();
        }
      
        public bool AddMedicine(MedicineDTO medicineDTO)
        {
            dbContext.Add<MedicineDTO>(medicineDTO);
            dbContext.SaveChanges();
            return true;
        }
        public List<MedicineDTO> GetAllMedicines()
        {
            return dbContext.MedicineDTOs.ToList();
        }

        public bool AddOffer(TenderOffer offer)
        {
            dbContext.Add<TenderOffer>(offer);
            dbContext.SaveChanges();
            return true;
        }

        public List<TenderOffer> GetAllOffers()
        {
            return dbContext.TenderOffer.ToList();
        }

        public List<TenderOffer> GetAllOffersByEmailAndTender(string emailAndTender)
        {
            string[] emailAndTenderId = emailAndTender.Split(';');
            string Email = emailAndTenderId[0];
            string TenderName = emailAndTenderId[1];
            List<TenderOffer> foundOffers = new List<TenderOffer>();
            List<TenderOffer> allTenderOffers = GetAllOffers();
            foreach (TenderOffer offer in allTenderOffers)
            {
                if (offer.CompanyEmail.Equals(Email) && offer.TenderName.Equals(TenderName))
                    foundOffers.Add(offer);
            }
            return foundOffers;
        }

        public void ClearAll(string tenderName)
        {
            foreach (TenderOffer t in GetAllOffers())
            {
                if (t.TenderName.Equals(tenderName))
                {
                    dbContext.Remove(t);
                    dbContext.SaveChanges();
                }
            }
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

    }
}
