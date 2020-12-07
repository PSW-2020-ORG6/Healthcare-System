using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using Model.Accounts;
using Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class ReportDatabaseSql : GenericDatabaseSql<Report>, IReportRepository
    {
        public override List<Report> GetAll()
        {
            var reports = dbContext.Report.ToList();

            foreach (var report in reports)
            {
                report.AdditionalDocument = new List<AdditionalDocument>();
                var diagnosticReferrals = dbContext.ReportDiagnosticReferral
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.DiagnosticReferral);
                report.AdditionalDocument.AddRange(diagnosticReferrals);

                var specialistReferrals = dbContext.ReportSpecialistReferral
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.SpecialistReferral);
                report.AdditionalDocument.AddRange(specialistReferrals);

                var followUps = dbContext.ReportFollowUp
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.FollowUp);
                report.AdditionalDocument.AddRange(followUps);

                var prescriptions = dbContext.ReportPrescription
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.Prescription);
                report.AdditionalDocument.AddRange(prescriptions);
            }

            return reports;
        }

        public List<Report> GetReportsByPatient(Patient patient)
        {
            return GetAll().Where(x => x.PatientId.Equals(patient.SerialNumber)).ToList();
        }
    }
}