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
