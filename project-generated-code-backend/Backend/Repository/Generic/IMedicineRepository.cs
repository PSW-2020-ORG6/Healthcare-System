using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        public new List<Medicine> GetAll();
        public List<Medicine> GetApproved();
        public List<Medicine> GetWaiting();
        List<Medicine> GetByName(string name);
    }
}