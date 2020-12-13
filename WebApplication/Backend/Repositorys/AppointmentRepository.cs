using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Repositorys.Interfaces;
using HealthClinicBackend.Backend.Model.Util;

namespace WebApplication.Backend.Repositorys
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private MySqlConnection connection;
        private RoomRepository roomRepository = new RoomRepository();
        private PhysicianRepository physitianRepository = new PhysicianRepository();
        private PatientRepository patientRepository = new PatientRepository();
        private TimeIntervalRepository timeIntervalRepository = new TimeIntervalRepository();
        private ProcedureTypeRepository procedureTypeRepository = new ProcedureTypeRepository();

        public AppointmentRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
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
                entity.Urgency = (bool)sqlReader[1];
                entity.Patient = patientRepository.GetPatientBySerialNumber((string)sqlReader[2]);
                entity.Room = roomRepository.GetRoomBySerialNumber((string)sqlReader[3]);
                entity.Physician = physitianRepository.GetPhysicianBySerialNumber((string)sqlReader[4]);
                entity.ProcedureType = procedureTypeRepository.GetProcedureTypeBySerialNumber((string)sqlReader[5]);
                entity.Date = Convert.ToDateTime(sqlReader[6]);
                entity.TimeInterval = new TimeInterval { Start = (DateTime)sqlReader[7] };
                entity.Active = (bool)sqlReader[8];
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

        public List<Appointment> GetAppointmentsByDate(string date)
        {
            return GetAppointments("Select * from appointment where Date ='" + date + "'");
        }

        public bool AddAppointment(Appointment appointment)
        {
            connection.Open();
            string[] dateString = appointment.Date.ToString().Split(" ");
            string[] partsOfDate = dateString[0].Split("/");
            string[] dateString1 = appointment.TimeInterval.Start.ToString().Split(" ");
            string[] partsOfDate1 = dateString1[0].Split("/");

            string sqlDml = "INSERT into appointment (SerialNumber,Urgency,PatientId,RoomId,PhysitianId,ProcedureTypeId,Date,TimeIntervalStart,Active)  VALUES('"
                + appointment.SerialNumber + "','" + 0 + "','" + "96736fd7-3018-4f3f-a14b-35610a1c8959" + "','" + null + "','" + appointment.Physician.SerialNumber
                + "','" + "300001" + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
                + "','" + partsOfDate1[2] + "-" + partsOfDate1[0] + "-" + partsOfDate1[1] + "T" + dateString1[1]
                + "','" + 1 + "')";
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            return true;
        }
    }
}
