using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class PrescriptionMedicineDosage
    {
        [Key] public string Id { get; set; }
        [ForeignKey("Prescription")] public string PrescriptionSerialNumber { get; set; }
        public Prescription Prescription { get; set; }
        [ForeignKey("MedicineDosage")] public string MedicineDosageSerialNumber { get; set; }
        public MedicineDosage MedicineDosage { get; set; }
    }
}