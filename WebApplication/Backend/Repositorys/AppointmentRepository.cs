using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

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

        public List<Appointment> GetAllAppointmentsByPatientIdPast(string patientId)
        {
            throw new NotImplementedException();
        }

        public bool IsSurveyDoneByPatientIdAppointmentDatePhysicianName(string patientId, string appointmentDate,
            string physicianName)
        {
            throw new NotImplementedException();
        }

        public void SetSurveyDoneOnAppointment(string patientId, string appointmentDate, string physicianName)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAllAppointmentsWithoutSurvey()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAllAppointmentsWithSurvey()
        {
            throw new NotImplementedException();
        }

        public bool CancelAppointment(string appointmentSerialNumber)
        {
            throw new NotImplementedException();
        }

        public List<DateTime> GetCancelingDates(string id)
        {
            throw new NotImplementedException();
        }


        public bool SetUserToMalicious(string patientId)
        {
            // TODO: move this logic to service and call patient repository
            return true;
            // try
            // {
            //     connection.Open();
            //     String sqlDml = "UPDATE patient SET IsMalicious = '1'  WHERE id like '" + patientId + "'";
            //     MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            //     sqlCommand.ExecuteNonQuery();
            //
            //     connection.Close();
            //     return true;
            // }
            // catch (Exception e)
            // {
            //     return false;
            // }
        }

        public List<Appointment> GetAppointmentsByDate(string date)
        {
            throw new NotImplementedException();
        }

        public bool AddAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}