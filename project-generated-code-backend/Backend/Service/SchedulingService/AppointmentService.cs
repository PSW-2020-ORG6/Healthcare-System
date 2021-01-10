using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IProcedureTypeRepository _procedureTypeRepository = new ProcedureTypeDatabaseSql();
        private readonly IPatientRepository _patientRepository = new PatientDatabaseSql();
        private readonly IPhysicianRepository _physicianRepository = new PhysicianDatabaseSql();
        private readonly IRoomRepository _roomRepository = new RoomDatabaseSql();
        private List<ProcedureType> _procedureTypes;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentDatabaseSql();

            _procedureTypes = _procedureTypeRepository.GetAll();
        }

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment GetById(string id)
        {
            Appointment appointment = _appointmentRepository.GetById(id);
            FillComplexInfo(appointment);
            return appointment;
        }

        public List<Appointment> GetByRoomSerialNumber(string roomSerialNumber)
        {
            List<Appointment> appointments = _appointmentRepository.GetByRoomSerialNumber(roomSerialNumber);

            foreach (var appointment in appointments)
            {
                FillComplexInfo(appointment);
            }

            return appointments;
        }

        public List<Appointment> GetByPhysicianSerialNumber(string physicianSerialNumber)
        {
            List<Appointment> appointments = _appointmentRepository.GetByPhysicianSerialNumber(physicianSerialNumber);

            foreach (var appointment in appointments)
            {
                FillComplexInfo(appointment);
            }

            return appointments;
        }

        public List<Appointment> GetAll()
        {
            List<Appointment> appointments = _appointmentRepository.GetAll();

            foreach (var appointment in appointments)
            {
                FillComplexInfo(appointment);
            }

            return appointments;
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

        public void NewAppointment(ADTO appointmentDto)
        {
            _appointmentRepository.Save(new Appointment(appointmentDto));
        }

        private void FillComplexInfo(Appointment appointment)
        {
            appointment.ProcedureType = _procedureTypeRepository.GetById(appointment.ProcedureTypeSerialnumber);
            appointment.Patient = _patientRepository.GetById(appointment.PatientSerialNumber);
            appointment.Physician = _physicianRepository.GetById(appointment.PhysicianSerialNumber);
            appointment.Room = _roomRepository.GetById(appointment.RoomSerialNumber);
        }
    }
}