using MicroServiceAppointment.Backend.Model.Survey;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface ISurveyRepository : IGenericMsAppointmentRepository<Survey>
    {
        List<Survey> GetByPatientId(string patientId);
        List<string> GetDoctorNamesByPatientId(string patientId);
        List<Survey> GetByDoctorName(string doctorName);
    }
}