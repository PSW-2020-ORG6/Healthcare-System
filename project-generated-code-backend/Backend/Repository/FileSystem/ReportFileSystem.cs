// File:    ReportFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class ReportFileSystem

using Model.Accounts;
using Newtonsoft.Json;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace Backend.Repository
{
    public class ReportFileSystem : GenericFileSystem<Report>, IReportRepository
    {
        public ReportFileSystem()
        {
            path = @"./../../../../project-generated-code-backend/data/reports.txt";
        }

        public List<Report> GetReportsByPatient(Patient patient)
        {
            List<Report> reports = new List<Report>();
            foreach (Report report in GetAll())
            {
                if (patient.Equals(report.Patient))
                {
                    reports.Add(report);
                }
            }
            return reports;
        }

        public override Report Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Report>(objectStringFormat);
        }
    }
}