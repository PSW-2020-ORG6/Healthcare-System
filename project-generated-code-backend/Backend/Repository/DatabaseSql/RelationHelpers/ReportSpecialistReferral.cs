using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class ReportSpecialistReferral
    {
        [Key] public string Id { get; set; }
        [ForeignKey("Report")] public string ReportSerialNumber { get; set; }
        public Report Report { get; set; }
        [ForeignKey("SpecialistReferral")] public string SpecialistReferralSerialNumber { get; set; }
        public SpecialistReferral SpecialistReferral { get; set; }
    }
}