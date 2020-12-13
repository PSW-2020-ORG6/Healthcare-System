using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Repositorys.Interfaces;
using WebApplication.Backend.Util;
using HealthClinicBackend.Backend.Dto;

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
                + "','" + partsOfDate1[2] + "-" + partsOfDate1[0] + "-" + partsOfDate1[1] + "T" + ConvertTime(dateString1[1], dateString1[2])
                + "','" + 1 + "')";
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        private string ConvertTime(string time, string partOfTheDay)
        {
            string[] parts = time.Split(":");
            if(partOfTheDay == "PM")
                return (Int32.Parse(parts[0]) + 12).ToString() + ":" + parts[1] + ":" + parts[2];
            return time;
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

        public bool CheckIfUserIsMalicious(string patientId)
        {

            String sqlDml = "Select  DateOfCanceling FROM appointment WHERE PatientSerialNumber like '" + patientId + "' AND Active = '0'";
            try
            {
                connection.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
                MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
                List<DateSubstitute> datesToSort = new List<DateSubstitute>();
                while (sqlReader.Read())
                {
                    string entity = (string)sqlReader[0];
                    String[] entitySplit = (entity.Split(' ')[0]).Split('/');
                    datesToSort.Add(new DateSubstitute(entitySplit[2], entitySplit[0], entitySplit[1]));


                }

                DateSubstitute sortingObject = new DateSubstitute();
                List<DateSubstitute> sortedDates = sortingObject.SortDateSubstitutes(datesToSort);


                connection.Close();

                DateTime date = DateTime.Now;

                String[] dateSplit = (date.ToString().Split(' ')[0]).Split('/');
                DateSubstitute today = new DateSubstitute(dateSplit[2], dateSplit[0], dateSplit[1]);

                if (sortedDates.Count >= 2)
                {
                    if (sortingObject.CalculateDiference(sortedDates[sortedDates.Count - 2], today) <= 30)
                        return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public List<DateTime> sortDates(List<DateTime> datesToSort)
        {
            DateTime temp;
            for (int j = 0; j <= datesToSort.Count - 1; j++)
            {
                for (int i = 0; i <= datesToSort.Count - 1; i++)
                {
                    if (datesToSort[i].Year > datesToSort[i + 1].Year)
                    {
                        temp = datesToSort[i + 1];
                        datesToSort[i + 1] = datesToSort[i];
                        datesToSort[i] = temp;
                    }
                }
            }

            return datesToSort;
        }

        public bool setUserToMalicious(string patientId)
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
