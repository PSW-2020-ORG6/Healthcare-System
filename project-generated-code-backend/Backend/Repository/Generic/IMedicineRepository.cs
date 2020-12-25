using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        public List<Medicine> GetApproved();
        public List<Medicine> GetWaiting();
        List<Medicine> GetByName(string name);
        List<Medicine> GetByRoomSerialNumber(string roomSerialNumber);
    }
}