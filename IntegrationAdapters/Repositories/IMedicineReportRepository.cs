using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Repository.Generic;

namespace IntegrationAdapters.Repositories
{
    public interface IMedicineReportRepository : IGenericRepository<MedicineReport>
    {
        public List<MedicineReport> GetAll();
        void AddPrescription();
    }
}