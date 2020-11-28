using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IReportRepository
    {
        List<Report> GetReports(String sqlDml);
        ProcedureType GetProcedureTypeById(string sqlDml);
        Specialization GetSpecialization(string sqlDml);
        List<Report> GetReportsByProperty(string property, string value, string dateTimes,bool not);

    }
}
