using Backend.Model.Util;
using Model.Hospital;
using Model.Schedule;

namespace health_clinic_class_diagram.Backend.Model.Schedule
{
    public class ProcedureTypeEquipmentUsage : Entity
    {

        private ProcedureType procedureType;
        private Equipment equipment;
        private string procedureTypeSerialNumber;
        private string equipmentSerialNumber;

        public ProcedureType ProcedureType { get => procedureType; set => procedureType = value; }
        public Equipment Equipment { get => equipment; set => equipment = value; }
        public string ProcedureTypeSerialNumber { get => procedureTypeSerialNumber; set => procedureTypeSerialNumber = value; }
        public string EquipmentSerialNumber { get => equipmentSerialNumber; set => equipmentSerialNumber = value; }
    }
}
