using TenderProcurement.Models;
using TenderProcurement.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderProcure = TenderProcurement.Models.Tender;

namespace TenderProcurement.Repositories
{
    public interface ITenderRepository
    {
        public bool AddTender(TenderProcure tender);
        public List<TenderProcure> GetAllTenders();
        public List<TenderOffer> GetAllOffers();
        public bool AddOffer(TenderOffer offer);
        public bool AddMedicine(MedicineDTO medicineDTO);
        public List<MedicineDTO> GetAllMedicines();
        public List<TenderOffer> GetAllOffersByEmailAndTender(string emailAndTender);
        public void SaveChanges();
      
        public void ClearAll(string tenderName);
    }
}
