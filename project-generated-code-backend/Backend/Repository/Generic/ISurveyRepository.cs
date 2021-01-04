using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Survey;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        List<Survey> GetByPatientId(string patientId);
        List<string> GetDoctorNamesByPatientId(string patientId);
        List<Survey> GetByDoctorName(string doctorName);
    }
}