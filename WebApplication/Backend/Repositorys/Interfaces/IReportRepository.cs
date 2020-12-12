using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace WebApplication.Backend.Repositorys
{
    public interface IReportRepository
    {
        List<Report> GetReportsByProperty(SearchProperty property, string value, string dateTimes, bool not);

    }
}
