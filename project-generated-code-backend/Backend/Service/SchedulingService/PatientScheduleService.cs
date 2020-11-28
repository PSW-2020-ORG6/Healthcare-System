using Backend.Dto;
using Backend.Repository;
using Model.Accounts;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace health_clinic_class_diagram.Backend.Service.SchedulingService
{
    class PatientScheduleService
    {
        private Patient loggedPatient;

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment NextAppointment()
        {
            throw new NotImplementedException();
        }

        public void NewAppointment(AppointmentDTO appointmentDTO)
        {
            throw new NotImplementedException();
        }

        public AppointmentRepository appointmentRepository;
    }
}
