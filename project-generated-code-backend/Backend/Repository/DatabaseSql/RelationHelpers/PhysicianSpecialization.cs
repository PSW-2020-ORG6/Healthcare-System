using HealthClinicBackend.Backend.Model.Accounts;
using Model.Accounts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class PhysicianSpecialization
    {
        [ForeignKey("Physician")] public string PhysicianSerialNumber { get; set; }
        public Physician Physician { get; set; }
        [ForeignKey("Specialization")] public string SpecializationSerialNumber { get; set; }
        public Specialization Specialization { get; set; }
    }
}