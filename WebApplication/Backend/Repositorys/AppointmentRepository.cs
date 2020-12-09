using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;
using WebApplication.Backend.Util;
using HealthClinicBackend.Backend.Dto;
using NPOI.SS.Formula.Functions;
using HealthClinicBackend.Backend.Model.Util;
using Model.Accounts;
using HealthClinicBackend.Backend.Dto;
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


        public bool SetUserToMalicious(string patientId)
        {
            try
            {
                connection.Open();
                String sqlDml = "UPDATE patient SET IsMalicious = '1'  WHERE id like '" + patientId + "'";
                MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
                sqlCommand.ExecuteNonQuery();

                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}