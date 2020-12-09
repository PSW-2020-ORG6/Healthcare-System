using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IProcedureTypeEquipmentUsageRepository
    {
        List<ProcedureTypeEquipmentUsage> GetAllProcedureTypeEquipmentUsages();
        ProcedureTypeEquipmentUsage GetProcedureTypeEquipmentUsageBySerialNumber(string serialNumber);
        List<ProcedureTypeEquipmentUsage> GetProcedureTypeEquipmentUsagesByEquipmentSerialNumber(string equipmentSerialNumber);
        List<ProcedureTypeEquipmentUsage> GetProcedureTypeEquipmentUsagesByProcedureTypeSerialNumber(string procedureTypeSerialNumber);
    }
}
