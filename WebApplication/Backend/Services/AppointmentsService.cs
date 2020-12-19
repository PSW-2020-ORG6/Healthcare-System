using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;

namespace WebApplication.Backend.Services
{
    public class AppointmentsService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<Appointment> GetAllAppointmentsByPatientId(string patientId)
        {
            return _appointmentRepository.GetByPatientId(patientId);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        internal List<Appointment> GetAllAppointmentsByPatientIdActive(string patientId)
        {
            return _appointmentRepository.GetByPatientIdActive(patientId);
        }

        internal List<Appointment> GetAllAppointmentsByPatientIdCanceled(string patientId)
        {
            return _appointmentRepository.GetByPatientIdCanceled(patientId);
        }
    }
}