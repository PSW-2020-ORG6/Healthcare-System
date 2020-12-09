// File:    ReportRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface ReportRepository

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        List<Report> GetByPatient(Patient patient);
        List<Report> GetByPatientId(string id);
    }
}