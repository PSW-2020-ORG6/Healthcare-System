using System;
using System.Collections.Generic;
using System.Linq;
using MicroServiceAccount.Backend.Model;
using MicroServiceSearch.Backend.Model;
using MicroServiceSearch.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceSearch.Backend.Repository.DatabaseSql
{
    public class ReportDatabaseSql : GenericMsSearchDatabaseSql<Report>, IReportRepository
    {
        public ReportDatabaseSql()
        {
        }

        public ReportDatabaseSql(MsSearchDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Report> GetAll()
        {
            var reports = DbContext.Report.ToList();

            foreach (var report in reports)
            {
                report.AdditionalDocument = new List<AdditionalDocument>();
                var diagnosticReferrals = DbContext.ReportDiagnosticReferral
                    .Include(x => x.DiagnosticReferral)
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.DiagnosticReferral);
                report.AdditionalDocument.AddRange(diagnosticReferrals);

                var specialistReferrals = DbContext.ReportSpecialistReferral
                    .Include(x => x.SpecialistReferral)
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.SpecialistReferral);
                report.AdditionalDocument.AddRange(specialistReferrals);

                var followUps = DbContext.ReportFollowUp
                    .Include(x => x.FollowUp)
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.FollowUp);
                report.AdditionalDocument.AddRange(followUps);

                var prescriptions = DbContext.ReportPrescription
                    .Include(x => x.Prescription)
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.Prescription);
                report.AdditionalDocument.AddRange(prescriptions);
           
            }

            return reports;
        }

        public List<Report> GetByPatient(Patient patient)
        {
            return GetAll()
                .Where(x => x.PatientId.Equals(patient.SerialNumber) || x.PatientId.Equals(patient.Id))
                .ToList();
        }

        public List<Report> GetByPatientId(string id)
        {
            return GetAll().Where(r => r.PatientId.Equals(id)).ToList();
        }


        public List<Report> GetReportsBetweenDates(DateTime[] datetimes)
        {
            return GetAll().Where(t => t.Date > datetimes[0] && t.Date < datetimes[1]).ToList();
        }

        public Report GetReportByAppointment(DateTime date, string patientSerialNumber, string physicianSerialNumber)
        {
            return GetAll()
                .Where(r => r.Date.Equals(date) && r.PatientId.Equals(patientSerialNumber) && r.PhysicianSerialNumber.Equals(physicianSerialNumber))
                .ToList()[0];
        }
    }
}