﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using WebApplication.Backend.Repositorys.Interfaces;
using WebApplication.Backend.Util;
using HealthClinicBackend.Backend.Dto;
using NPOI.SS.Formula.Functions;
using HealthClinicBackend.Backend.Model.Util;
using Model.Accounts;
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
                entity.Room = roomRepository.GetRoomBySerialNumber((string)sqlReader[1]);
                entity.Physician = physitianRepository.GetPhysitianBySerialNumber((string)sqlReader[2]);
                entity.Patient = patientRepository.GetPatientBySerialNumber((string)sqlReader[3]);
                entity.TimeInterval = timeIntervalRepository.GetTimeIntervalById((string)sqlReader[6]);
                entity.ProcedureType = procedureTypeRepository.GetProcedureTypeBySerialNumber((string)sqlReader[7]);
                entity.Urgency = (bool)sqlReader[1];
                entity.Active = (bool)sqlReader[2];
                entity.Date = Convert.ToDateTime(sqlReader[8]);
                entity.IsSurveyDone = Convert.ToBoolean(sqlReader[10]);
                


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
            List<Appointment> allAppointments = new List<Appointment>();

            try
            {
                allAppointments = GetAppointments("Select * from appointment where PatientSerialNumber='" + patientId + "'" + " AND  Active like '" + 1 + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            DateTime dateNow = DateTime.Now;
            List<Appointment> appotintmentsInFuture = new List<Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.Date > dateNow)
                {
                    appotintmentsInFuture.Add(appointment);
                }
            }
            return appotintmentsInFuture;
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


        public List<Appointment> GetAllAppointmentsByPatientIdPast(String patientId)
        {
            List<Appointment> allAppointments = new List<Appointment>();
            try
            {
                allAppointments = GetAppointments("Select * from appointment where PatientSerialNumber='" + patientId + "'" + " AND  Active like '" + 1 + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            DateTime dateNow = DateTime.Now;
            List<Appointment> appotintmentsInPast = new List<Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.Date < dateNow)
                {
                    appotintmentsInPast.Add(appointment);
                }
            }
            return appotintmentsInPast;
        }
        bool IAppointmentRepository.IsSurveyDoneByPatientIdAppointmentDatePhysicianName(String patientId, String appointmentDate, String physicianName)
        {
            bool var = false;
            List<Physician> physitianResult = physitianRepository.GetPhysitiansByFullName(physicianName);
            List<String> physicianId = new List<string>();
            foreach (Physician physician in physitianResult)
            {
                physicianId.Add(physician.Id);
            }

            List<Appointment> appointmentList = GetAppointments("Select * from appointment where PatientSerialNumber like '" + patientId + "'" + " and PhysitianId like '" + physicianId[0] + "'" + " and Date like '" + appointmentDate + "'");
            return appointmentList[0].IsSurveyDone;


        }
        public void SetSurveyDoneOnAppointment(String patientId, String appointmentDate, String physicianName)
        {
            String dateD;

            String[] date = appointmentDate.Split(" ")[0].Split(".");
            if (date[1].Length == 1)
                dateD = date[2] + "-" + "0" + date[1] + "-" + date[0] + " 00:00:00";
            else
                dateD = date[2] + "-" + date[1] + "-" + date[0] + " 00:00:00";

            connection.Open();
            List<Physician> physitianResult = physitianRepository.GetPhysitiansByFullName(physicianName);
            List<String> physicianId = new List<string>();
            foreach (Physician physician in physitianResult)
            {
                physicianId.Add(physician.Id);
            }
            String sqlDml = "Update appointment set isSurveyDone=1 where PatientSerialNumber like '" + patientId + "'" + "and Date like '" + dateD + "'" + "and PhysitianId like '" + physicianId[0] + "'";
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            sqlCommand.ExecuteNonQuery();

        }

        public List<Appointment> GetAllAppointmentsWithSurvey()
        {

            List<Appointment> allAppointments = new List<Appointment>();
            try
            {
                return allAppointments = GetAppointments("Select * from appointment where isSurveyDone like '" + 1 + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


        }

        public List<Appointment> GetAllAppointmentsWithoutSurvey()
        {

            List<Appointment> allAppointments = new List<Appointment>();
            try
            {
                allAppointments = GetAppointments("Select * from appointment where isSurveyDone like '" + 0 + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            DateTime dateNow = DateTime.Now;
            List<Appointment> appotintmentsInPastWitohutSurvey = new List<Appointment>();
            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.Date < dateNow)
                {
                    appotintmentsInPastWitohutSurvey.Add(appointment);
                }
            }
            return appotintmentsInPastWitohutSurvey;

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
