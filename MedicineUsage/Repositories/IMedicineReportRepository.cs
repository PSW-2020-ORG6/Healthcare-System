using MedicineUsage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineUsage.Repositories
{
    public interface IMedicineReportRepository
    {
        public List<MedicineReport> GetAll();
        void AddPrescription();
    }
}
