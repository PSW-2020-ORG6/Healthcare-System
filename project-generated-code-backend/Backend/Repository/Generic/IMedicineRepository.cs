using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        public new List<Medicine> GetAll();
        public List<Medicine> GetApproved();
        public List<Medicine> GetWaiting();
    }
}