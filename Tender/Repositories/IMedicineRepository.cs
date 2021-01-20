using TenderProcurement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderProcurement.Repositories
{
    public interface IMedicineRepository
    {
        public List<Medicine> GetAll();
	    public void SaveChanges();
        public Medicine GetByName(String Name);
        public bool DoesMedicineExist(Medicine medicine);
	    public void AddMedicine(Medicine medicine);    
}
}
