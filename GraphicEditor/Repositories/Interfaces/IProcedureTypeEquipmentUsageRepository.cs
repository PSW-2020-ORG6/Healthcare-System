using health_clinic_class_diagram.Backend.Model.Schedule;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IProcedureTypeEquipmentUsageRepository
    {
        List<ProcedureTypeEquipmentUsage> GetAllProcedureTypeEquipmentUsages();
        ProcedureTypeEquipmentUsage GetProcedureTypeEquipmentUsageBySerialNumber(string serialNumber);
        List<ProcedureTypeEquipmentUsage> GetProcedureTypeEquipmentUsagesByEquipmentSerialNumber(string equipmentSerialNumber);
        List<ProcedureTypeEquipmentUsage> GetProcedureTypeEquipmentUsagesByProcedureTypeSerialNumber(string procedureTypeSerialNumber);
    }
}
