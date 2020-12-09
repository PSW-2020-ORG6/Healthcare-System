using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;
using HealthClinicBackend.Backend.Model.Util;

namespace WebApplication.Backend.Repositorys
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentDatabaseSql _appointmentRepository;

        public AppointmentRepository()
        {
            _appointmentRepository = new AppointmentDatabaseSql();
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetAppointmentBySerialNumber(string serialNumber)
        {
            return _appointmentRepository.GetById(serialNumber);
        }

        public List<Appointment> GetAppointmentByRoomSerialNumber(string roomSerialNumber)
        {
            return _appointmentRepository.GetByRoomSerialNumber(roomSerialNumber);
        }

        public List<Appointment> GetAppointmentByPhysitianSerialNumber(string physicianSerialNumber)
        {
            return _appointmentRepository.GetByPhysicianSerialNumber(physicianSerialNumber);
        }

        public List<Appointment> GetAppointmentByPatientSerialNumber(string patientSerialNumber)
        {
            return _appointmentRepository.GetByPatientSerialNumber(patientSerialNumber);
        }

        public List<Appointment> GetAllAppointmentByPatientId(string patientId)
        {
            return _appointmentRepository.GetByPatientId(patientId);
        }

        public List<Appointment> GetAllAppointmentsByPatientIdActive(string patientId)
        {
            return _appointmentRepository.GetByPatientIdActive(patientId);
        }

        public List<Appointment> GetAllAppointmentsByPatientIdCanceled(string patientId)
        {
            return _appointmentRepository.GetByPatientIdCanceled(patientId);
        }
    }
}