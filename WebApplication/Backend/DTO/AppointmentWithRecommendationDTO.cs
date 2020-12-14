using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class AppointmentWithRecommendationDTO
    {
        public string Date { get; set; }
        public List<TimeIntervalDTO> TimeIntervals { get; set; }
        public string PhysicianId { get; set; }
        public string PhysicianFullName { get; set; }

        public AppointmentWithRecommendationDTO() 
        { 
        }
        public AppointmentWithRecommendationDTO(string date, string physician, List<TimeIntervalDTO> timeIntervals, string physicianFullName)
        {
            this.Date = date;
            this.TimeIntervals = timeIntervals;
            this.PhysicianId = physician;
            this.PhysicianFullName = physicianFullName;
        }
    }
}
