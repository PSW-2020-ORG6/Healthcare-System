using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.PatientCareService
{
    class ReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService()
        {
            _reportRepository = new ReportDatabaseSql();
        }

        public List<Report> GetReportsByPatient(Patient patient)
        {
            return _reportRepository.GetByPatient(patient);
        }

        public Report GetLastReportByPatient(Patient patient)
        {
            var reports = _reportRepository.GetByPatient(patient);
            if (reports.Count <= 0) return null;
            reports.Sort((a, b) => b.CompareTo(a));
            return reports[0];
        }

        public void NewReport(Report report)
        {
            _reportRepository.Save(report);
        }
    }
}