using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Model.Hospital;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class ProcedureEquipment
    {
        [ForeignKey("ProcedureType")] public string ProcedureTypeSerialNumber { get; set; }
        public ProcedureType ProcedureType { get; set; }
        [ForeignKey("Equipment")] public string EquipmentSerialNumber { get; set; }
        public Equipment Equipment { get; set; }
    }
}
