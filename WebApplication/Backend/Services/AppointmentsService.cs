using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Services
{
    public class AppointmentsService
    {
        private IAppointmentRepository iappointmentRepository;
        public AppointmentsService()
        {
            this.iappointmentRepository = new AppointmentRepository();
        }
        public AppointmentsService(IAppointmentRepository iApointmentRepository)
        {
            this.iappointmentRepository = iApointmentRepository;
        }

        public List<Appointment> GetAllAppointmentsByPatientId(string patientId)
        {
            return iappointmentRepository.GetAllAppointmentByPatientId(patientId);
        }

        public List<Appointment> GetAllAppointments()
        {
            return iappointmentRepository.GetAllAppointments();
        }

        internal List<Appointment> GetAllAppointmentsByPatientIdActive(string patientId)
        {
            return iappointmentRepository.GetAllAppointmentsByPatientIdActive(patientId);
        }

        internal List<Appointment> GetAllAppointmentsByPatientIdCanceled(string patientId)
        {
            return iappointmentRepository.GetAllAppointmentsByPatientIdCanceled(patientId);
        }
    }
}
