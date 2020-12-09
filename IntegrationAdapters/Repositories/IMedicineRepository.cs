using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    interface IMedicineRepository
    {
        public List<Medicine> GetAll();
        void AddMedicineRepository();
        public Medicine GetByID(String ID);
        public Medicine GetByName(String Name);
    }
}
