using MicroServiceAppointment.Backend.Model.Hospital;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface IBuildingRepository : IGenericMsAppointmentRepository<Building>
    {
        List<Building> GetByName(string name);
    }
}
