using MicroServiceAppointment.Backend.Model;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface IMedicineRepository : IGenericMsAppointmentRepository<Medicine>
    {
        public new List<Medicine> GetAll();
        public List<Medicine> GetApproved();
        public List<Medicine> GetWaiting();
        List<Medicine> GetByName(string name);
    }
}