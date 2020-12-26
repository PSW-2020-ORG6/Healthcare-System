using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
