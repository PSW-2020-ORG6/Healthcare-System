using HealthClinicBackend.Backend.Model.Schedule;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IProcedureTypeRepository
    {
        ProcedureType GetProcedureTypeBySerialNumber(string serialNumber);
    }
}
