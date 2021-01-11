using MicroServiceAppointment.Backend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Service
{
    public interface IAppointmentService
    {
        public List<TimeIntervalsDTO> GetAllAvailableAppointments(string physicianId, string specializationName, string date);
        public List<AppointmentWithRecommendationDTO> AppointmentRecomendationWithPhysicianPriority(string physicianId, string specializationName, string[] dates);
     //   public List<AppointmentWithRecommendationDTO> AppointmentRecomendation(string physicianId, string specializationName, string[] dates);
    }
}
