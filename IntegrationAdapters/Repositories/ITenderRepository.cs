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
        public List<Offer> GetAllOffers();
        public bool AddOffer(Offer offer);
        public bool AddMedicine(MedicineDTO medicineDTO);
        public List<MedicineDTO> GetAllMedicines();
    }
}
