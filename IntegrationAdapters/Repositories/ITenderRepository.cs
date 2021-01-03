using IntegrationAdapters.Models;
using IntegrationAdapters.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    interface ITenderRepository
    {
        public bool AddTender(Tender tender);
        public List<Tender> GetAllTenders();
        public List<TenderOffer> GetAllOffers();
        public bool AddOffer(TenderOffer offer);
        public bool AddMedicine(MedicineDTO medicineDTO);
        public List<MedicineDTO> GetAllMedicines();
        public List<TenderOffer> GetAllOffersByEmailAndTender(String emailAndTender);
    }
}
