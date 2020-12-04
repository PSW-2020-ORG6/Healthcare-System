using Model.Schedule;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private MySqlConnection connection;
        private RoomRepository roomRepository = new RoomRepository();
        private PhysitianRepository physitianRepository = new PhysitianRepository();
        private PatientRepository patientRepository = new PatientRepository();
        private TimeIntervalRepository timeIntervalRepository = new TimeIntervalRepository();
        private ProcedureTypeRepository procedureTypeRepository = new ProcedureTypeRepository();

        public AppointmentRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=newdb;user=root;password=root");
        }

        private List<Appointment> GetAppointments(String query)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Appointment> resultList = new List<Appointment>();
            while (sqlReader.Read())
            {
                Appointment entity = new Appointment();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Room = roomRepository.GetRoomBySerialNumber((string)sqlReader[1]);
                entity.Physician = physitianRepository.GetPhysitianBySerialNumber((string)sqlReader[2]);
                entity.Patient = patientRepository.GetPatientBySerialNumber((string)sqlReader[3]);
                entity.TimeInterval = timeIntervalRepository.GetTimeIntervalById((string)sqlReader[6]);
                entity.ProcedureType = procedureTypeRepository.GetProcedureTypeBySerialNumber((string)sqlReader[7]);
                entity.Urgency = (bool)sqlReader[1];
                entity.Active = (bool)sqlReader[2];
                entity.Date = Convert.ToDateTime(sqlReader[8]);
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Appointment> GetAllAppointments()
        {
            try
            {
                return GetAppointments("Select * from appointment");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Appointment GetAppointmentBySerialNumber(string serialNumber)
        {
            try
            {
                return GetAppointments("Select * from appointment where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Appointment> GetAppointmentByRoomSerialNumber(string roomSerialNumber)
        {
            try
            {
                return GetAppointments("Select * from appointment where RoomSerialNumber='" + roomSerialNumber + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Appointment> GetAppointmentByPhysitianSerialNumber(string physitianSerialNumber)
        {
            try
            {
                return GetAppointments("Select * from appointment where PhysitianSerialNumber='" + physitianSerialNumber + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Appointment> GetAppointmentByPatientSerialNumber(string patientSerialNumber)
        {
            try
            {
                return GetAppointments("Select * from appointment where PatientSerialNumber='" + patientSerialNumber + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Appointment> GetAllAppointmentByPatientId(string patientId)
        {
            try
            {
                return GetAppointments("Select * from appointment where PatientSerialNumber like '" + patientId + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Appointment> GetAllAppointmentsByPatientIdActive(string patientId)
        {
            try
            {
                return GetAppointments("Select * from appointment where PatientSerialNumber='" + patientId + "'" + " AND  Active like '" + 1 + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Appointment> GetAllAppointmentsByPatientIdCanceled(string patientId)
        {
            try
            {
                return GetAppointments("Select * from appointment where PatientSerialNumber='" + patientId + "'" + " AND  Active like '" + 0 + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
