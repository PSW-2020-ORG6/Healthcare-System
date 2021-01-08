using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class ProcedureEquipment
    {
        [ForeignKey("ProcedureType")] public string ProcedureTypeSerialNumber { get; set; }
        public ProcedureType ProcedureType { get; set; }
        [ForeignKey("Equipment")] public string EquipmentSerialNumber { get; set; }
        public Equipment Equipment { get; set; }
    }
}
