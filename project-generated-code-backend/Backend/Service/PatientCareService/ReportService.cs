using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Service.PatientCareService
{
    public class ReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
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