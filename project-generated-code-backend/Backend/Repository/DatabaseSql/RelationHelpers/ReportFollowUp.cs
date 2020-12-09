using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class ReportFollowUp
    {
        [Key] public string Id { get; set; }
        [ForeignKey("Report")] public string ReportSerialNumber { get; set; }
        public Report Report { get; set; }
        [ForeignKey("FollowUp")] public string FollowUpSerialNumber { get; set; }
        public FollowUp FollowUp { get; set; }
    }
}