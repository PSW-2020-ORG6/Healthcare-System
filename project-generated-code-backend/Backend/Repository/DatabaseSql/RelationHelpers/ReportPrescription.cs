using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class ReportPrescription
    {
        [Key] public string Id { get; set; }
        [ForeignKey("Report")] public string ReportSerialNumber { get; set; }
        public Report Report { get; set; }
        [ForeignKey("Prescription")] public string PrescriptionSerialNumber { get; set; }
        public Prescription Prescription { get; set; }
    }
}