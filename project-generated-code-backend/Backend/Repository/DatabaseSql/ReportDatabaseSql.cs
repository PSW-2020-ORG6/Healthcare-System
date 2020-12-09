﻿using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;

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
                    .Include(x => x.DiagnosticReferral)
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.DiagnosticReferral);
                report.AdditionalDocument.AddRange(diagnosticReferrals);

                var specialistReferrals = dbContext.ReportSpecialistReferral
                    .Include(x => x.SpecialistReferral)
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.SpecialistReferral);
                report.AdditionalDocument.AddRange(specialistReferrals);

                var followUps = dbContext.ReportFollowUp
                    .Include(x => x.FollowUp)
                    .Where(x => x.ReportSerialNumber.Equals(report.SerialNumber))
                    .Select(x => x.FollowUp);
                report.AdditionalDocument.AddRange(followUps);

                var prescriptions = dbContext.ReportPrescription
                    .Include(x => x.Prescription)
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