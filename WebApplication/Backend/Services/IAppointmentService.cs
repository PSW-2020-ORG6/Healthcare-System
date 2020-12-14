using HealthClinicBackend.Backend.Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.DTO;

namespace WebApplication.Backend.Services
{
    public interface IAppointmentService
    {
        public List<TimeIntervalDTO> GetAllAvailableAppointments(string physicianId, string specializationName, string date);
        public List<AppointmentWithRecommendationDTO> AppointmentRecomendationWithPhysicianPriority(string physicianId, string specializationName, string[] dates);
        public List<AppointmentWithRecommendationDTO> AppointmentRecomendation(string physicianId, string specializationName, string[] dates);
    }
}
