using Backend.Model.Util;
using Model.Hospital;
using Model.Schedule;

namespace health_clinic_class_diagram.Backend.Model.Schedule
{
    public class ProcedureTypeEquipmentUsage : Entity
    {
        public ProcedureType ProcedureType { get; set; }
        public Equipment Equipment { get; set; }
        public string ProcedureTypeSerialNumber { get; set; }
        public string EquipmentSerialNumber { get; set; }
    }
}