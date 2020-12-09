using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.Schedule
{
    public class ProcedureTypeEquipmentUsage : Entity
    {
        public ProcedureType ProcedureType { get; set; }
        public Equipment Equipment { get; set; }
        public string ProcedureTypeSerialNumber { get; set; }
        public string EquipmentSerialNumber { get; set; }
    }
}