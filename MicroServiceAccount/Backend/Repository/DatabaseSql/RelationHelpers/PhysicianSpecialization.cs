using MicroServiceAccount.Backend.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceAccount.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class PhysicianSpecialization
    {
        [Key] public string Id { get; set; }
        [ForeignKey("Physician")] public string PhysicianSerialNumber { get; set; }
        public Physician Physician { get; set; }
        [ForeignKey("Specialization")] public string SpecializationSerialNumber { get; set; }
        public Specialization Specialization { get; set; }
    }
}