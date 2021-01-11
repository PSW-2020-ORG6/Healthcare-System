// File:    ReportRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface ReportRepository

using MicroServiceAccount.Backend.Model;
using MicroServiceSearch.Backend.Model;
using MicroServiceSearch.Backend.Repository.Generic;
using System;
using System.Collections.Generic;

namespace MicroServiceSearch.Backend.Repository.Generic
{
    public interface IReportRepository : IGenericMsSearchRepository<Report>
    {
        List<Report> GetByPatient(Patient patient);
        List<Report> GetByPatientId(string id);
        List<Report> GetReportsBetweenDates(DateTime[] datetimes);
    }
}