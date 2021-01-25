// File:    ReportRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface ReportRepository

using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        List<Report> GetByPatient(Patient patient);
        List<Report> GetByPatientId(string id);
        List<Report> GetReportsBetweenDates(DateTime[] datetimes);
    }
}