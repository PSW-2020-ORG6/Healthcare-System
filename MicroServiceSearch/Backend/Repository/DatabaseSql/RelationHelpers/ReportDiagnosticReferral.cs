using MicroServiceSearch.Backend.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceSearch.Backend.Repository.DatabaseSql.RelationHelpers
{
    public class ReportDiagnosticReferral
    {
        [Key] public string Id { get; set; }
        [ForeignKey("Report")] public string ReportSerialNumber { get; set; }
        public Report Report { get; set; }
        [ForeignKey("DiagnosticReferral")] public string DiagnosticReferralSerialNumber { get; set; }
        public DiagnosticReferral DiagnosticReferral { get; set; }
    }
}