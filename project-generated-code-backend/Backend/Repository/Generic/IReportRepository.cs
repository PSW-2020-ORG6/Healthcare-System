// File:    ReportRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface ReportRepository

using Model.Accounts;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace Backend.Repository
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        List<Report> GetReportsByPatient(Patient patient);
    }
}