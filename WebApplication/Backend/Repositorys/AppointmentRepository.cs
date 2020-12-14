using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Repositorys.Interfaces;
using WebApplication.Backend.Util;
using HealthClinicBackend.Backend.Dto;
using NPOI.SS.Formula.Functions;

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
            connection = new MySqlConnection("server=localhost;port=3306;database=novabaza1;user=root;password=neynamneynam12");
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

        public bool CancelAppointment(string appointmentSerialNumber)
        {
            try
            {
                connection.Open();
                String sqlDml = "UPDATE appointment SET active = 0 , DateOfCanceling = '" + DateTime.Now + "'  WHERE SerialNumber like '" + appointmentSerialNumber + "'";
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

        public List<DateTime> GetCancelingDates(string patientId)
        {
            String sqlDml = "Select  DateOfCanceling FROM appointment WHERE PatientSerialNumber like '" + patientId + "' AND Active = '0'";
            try
            {
                connection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
                MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
                List<DateTime> dates = new List<DateTime>();
                while (sqlReader.Read())
                {
                    string entity = (string)sqlReader[0];
                    String[] entitySplit = (entity.Split(' ')[0]).Split('/');
                    String[] entitySplitHours = (entity.Split(' ')[1]).Split(':');
                    dates.Add(new DateTime(Int32.Parse(entitySplit[2]), Int32.Parse(entitySplit[0]), Int32.Parse(entitySplit[1]), Int32.Parse(entitySplitHours[0]), Int32.Parse(entitySplitHours[1]), Int32.Parse(entitySplitHours[2])));
                }

                return dates;
            }
            catch (Exception e)
            {
                return null;
            }
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
