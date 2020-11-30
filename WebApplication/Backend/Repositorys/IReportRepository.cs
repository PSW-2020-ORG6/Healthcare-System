using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IReportRepository
    {
        List<Report> GetReportsByProperty(SearchProperty property, string value, string dateTimes,bool not);

    }
}
