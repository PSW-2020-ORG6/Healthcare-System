using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentDatabaseSql();
        }

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment GetById(string id)
        {
            return _appointmentRepository.GetById(id);
        }

        public List<Appointment> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return _appointmentRepository.GetByRoomSerialNumber(roomSerialNumber);
        }

        public List<Appointment> GetByPhysicianSerialNumber(string physicianSerialNumber)
        {
            return _appointmentRepository.GetByPhysicianSerialNumber(physicianSerialNumber);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public void EditAppointment(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment.SerialNumber);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _appointmentRepository.GetAppointmentsByDate(date);
        }

        public void NewAppointment(AppointmentDto appointmentDto)
        {
            _appointmentRepository.Save(new Appointment(appointmentDto));
        }
    }
}