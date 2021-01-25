using HealthClinicBackend.Backend.Model.Survey;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        List<Survey> GetByPatientId(string patientId);
        List<string> GetDoctorNamesByPatientId(string patientId);
        List<Survey> GetByDoctorName(string doctorName);
    }
}