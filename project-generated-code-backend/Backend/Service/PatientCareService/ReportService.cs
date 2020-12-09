using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using Model.Accounts;

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
            return _reportRepository.GetReportsByPatient(patient);
        }

        public Report GetLastReportByPatient(Patient patient)
        {
            var reports = _reportRepository.GetReportsByPatient(patient);
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