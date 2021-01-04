// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Schedule;
// using WebApplication.Backend.Repositorys.Interfaces;
// using WebApplication.Backend.Util;
// using HealthClinicBackend.Backend.Dto;
// using NPOI.SS.Formula.Functions;
// using HealthClinicBackend.Backend.Model.Util;
// using HealthClinicBackend.Backend.Dto;
// using HealthClinicBackend.Backend.Model.Util;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class AppointmentRepository : IAppointmentRepository
//     {
//         private MySqlConnection connection;
//         private RoomRepository roomRepository = new RoomRepository();
//         private PhysicianRepository physitianRepository = new PhysicianRepository();
//         private PatientRepository patientRepository = new PatientRepository();
//         private TimeIntervalRepository timeIntervalRepository = new TimeIntervalRepository();
//         private ProcedureTypeRepository procedureTypeRepository = new ProcedureTypeRepository();
//
//         public AppointmentRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<Appointment> GetAppointments(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Appointment> resultList = new List<Appointment>();
//             while (sqlReader.Read())
//             {
//                 Appointment entity = new Appointment();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Urgency = (bool)sqlReader[1];
//                 entity.Patient = patientRepository.GetPatientBySerialNumber((string)sqlReader[2]);
//                 entity.Room = roomRepository.GetRoomBySerialNumber((string)sqlReader[3]);
//                 entity.Physician = physitianRepository.GetPhysicianBySerialNumber((string)sqlReader[4]);
//                 entity.ProcedureType = procedureTypeRepository.GetProcedureTypeBySerialNumber((string)sqlReader[5]);
//                 entity.Date = Convert.ToDateTime(sqlReader[6]);
//                 entity.TimeInterval = new TimeInterval { Start = (DateTime)sqlReader[7] };
//                 entity.Active = (bool)sqlReader[8];
//                 entity.IsSurveyDone = Convert.ToBoolean(sqlReader[9]);
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<Appointment> GetAllAppointments()
//         {
//             try
//             {
//                 return GetAppointments("Select * from appointment");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//         
//         public Appointment GetAppointmentBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetAppointments("Select * from appointment where SerialNumber='" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Appointment> GetAppointmentByRoomSerialNumber(string roomSerialNumber)
//         {
//             try
//             {
//                 return GetAppointments("Select * from appointment where RoomId='" + roomSerialNumber + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Appointment> GetAppointmentByPhysitianSerialNumber(string physitianSerialNumber)
//         {
//             try
//             {
//                 return GetAppointments("Select * from appointment where PhysitianId='" + physitianSerialNumber + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Appointment> GetAppointmentByPatientSerialNumber(string patientSerialNumber)
//         {
//             try
//             {
//                 return GetAppointments("Select * from appointment where PatientId='" + patientSerialNumber + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Appointment> GetAllAppointmentByPatientId(string patientId)
//         {
//             try
//             {
//                 return GetAppointments("Select * from appointment where PatientId like '" + patientId + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Appointment> GetAllAppointmentsByPatientIdActive(string patientId)
//         {
//             List<Appointment> allAppointments = new List<Appointment>();
//             try
//             {
//               return  allAppointments = GetAppointments("Select * from appointment where PatientId='" + patientId + "'" + " AND  Active like '" + 1 + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Appointment> GetAllAppointmentsByPatientIdCanceled(string patientId)
//         {
//             try
//             {
//                 return GetAppointments("Select * from appointment where PatientId='" + patientId + "'" + " AND  Active like '" + 0 + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//
//         public List<Appointment> GetAllAppointmentsByPatientIdPast(String patientId)
//         {
//             List<Appointment> allAppointments = new List<Appointment>();
//             try
//             {
//               return   allAppointments = GetAppointments("Select * from appointment where PatientId='" + patientId + "'" + " AND  Active like '" + 1 + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         bool IAppointmentRepository.IsSurveyDoneByPatientIdAppointmentDatePhysicianName(String patientId, String appointmentDate, String physicianId)
//         {
//             List<Appointment> appointmentList = GetAppointments("Select * from appointment where PatientId like '" + patientId + "'" + " and PhysitianId like '" + physicianId + "'" + " and Date like '" + appointmentDate + "'");
//             return appointmentList[0].IsSurveyDone;
//         }
//         public void SetSurveyDoneOnAppointment(String patientId, String appointmentDate, String physicianName)
//         {
//             connection.Open();
//             String sqlDml = "Update appointment set isSurveyDone=1 where PatientId like '" +patientId + "'" + "and Date like '" + appointmentDate + "'" + "and PhysitianId like '" + physicianName + "'";
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             sqlCommand.ExecuteNonQuery();
//         }
//
//         public List<Appointment> GetAllAppointmentsWithSurvey()
//         {
//
//             List<Appointment> allAppointments = new List<Appointment>();
//             try
//             {
//                 return allAppointments = GetAppointments("Select * from appointment where isSurveyDone like '" + 1 + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Appointment> GetAllAppointmentsWithoutSurvey()
//         {
//
//             List<Appointment> allAppointments = new List<Appointment>();
//             try
//             {
//              return allAppointments = GetAppointments("Select * from appointment where isSurveyDone like '" + 0 + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//
//         public List<Appointment> GetAppointmentsByDate(string date)
//         {
//             return GetAppointments("Select * from appointment where Date ='" + date + "'");
//         }
//
//         public bool AddAppointment(Appointment appointment)
//         {
//             connection.Open();
//             string[] dateString = appointment.Date.ToString().Split(" ");
//             string[] partsOfDate = dateString[0].Split("/");
//             string[] dateString1 = appointment.TimeInterval.Start.ToString().Split(" ");
//             string[] partsOfDate1 = dateString1[0].Split("/");
//
//             string sqlDml = "INSERT into appointment (SerialNumber,Urgency,PatientId,RoomId,PhysitianId,ProcedureTypeId,Date,TimeIntervalStart,Active,isSurveyDone,TimeIntervalSerialNumber)  VALUES('"
//                 + appointment.SerialNumber + "','" + 0 + "','" + "96736fd7-3018-4f3f-a14b-35610a1c8959" + "','" + "101" + "','" + appointment.Physician.SerialNumber
//                 + "','" + "300001" + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
//                 + "','" + partsOfDate1[2] + "-" + partsOfDate1[0] + "-" + partsOfDate1[1] + "T" + ConvertTime(dateString1[1], dateString1[2])
//                 + "','" + 1 + "','" + 0 + "','" + appointment.TimeInterval.Id + "')";
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             sqlCommand.ExecuteNonQuery();
//             connection.Close();
//             return true;
//         }
//
//         private string ConvertTime(string time, string partOfTheDay)
//         {
//             string[] parts = time.Split(":");
//             if(partOfTheDay == "PM")
//                 return (Int32.Parse(parts[0]) + 12).ToString() + ":" + parts[1] + ":" + parts[2];
//             return time;
//         }
//
//         public bool CancelAppointment(string appointmentSerialNumber)
//         {
//             try
//             {
//                 connection.Open();
//                 String sqlDml = "UPDATE appointment SET active = 0 , DateOfCanceling = '" + DateTime.Now + "'  WHERE SerialNumber like '" + appointmentSerialNumber + "'";
//                 MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//                 sqlCommand.ExecuteNonQuery();
//                 connection.Close();
//                 return true;
//             }
//             catch (Exception e)
//             {
//                 return false;
//             }
//         }
//
//         public List<DateTime> GetCancelingDates(string patientId)
//         {
//             String sqlDml = "Select  DateOfCanceling FROM appointment WHERE PatientId like '" + patientId + "' AND Active = '0'";
//             try
//             {
//                 connection.Open();
//                 MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//                 MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//                 List<DateTime> dates = new List<DateTime>();
//                 while (sqlReader.Read())
//                 {
//                     string entity = (string)sqlReader[0];
//                     String[] entitySplit = (entity.Split(' ')[0]).Split('/');
//                     String[] entitySplitHours = (entity.Split(' ')[1]).Split(':');
//                     dates.Add(new DateTime(Int32.Parse(entitySplit[2]), Int32.Parse(entitySplit[0]), Int32.Parse(entitySplit[1]), Int32.Parse(entitySplitHours[0]), Int32.Parse(entitySplitHours[1]), Int32.Parse(entitySplitHours[2])));
//                 }
//                 return dates;
//             }
//             catch (Exception e)
//             {
//                 return null;
//             }
//         }
//
//         public bool SetUserToMalicious(string patientId)
//         {
//             try
//             {
//                 connection.Open();
//                 String sqlDml = "UPDATE patient SET IsMalicious = '1'  WHERE id like '" + patientId + "'";
//                 MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//                 sqlCommand.ExecuteNonQuery();
//
//                 connection.Close();
//                 return true;
//             }
//             catch (Exception e)
//             {
//                 return false;
//             }
//         }
//         public List<string> GetAllDoctorsFromAppointmentsWithoutSurvey(string patientId)
//         {
//             List<Appointment> result = GetAppointments("Select * from appointment where PatientId='" + patientId + "'" + " AND  isSurveyDone like '" + 0 + "'");
//             List<String> resultList = new List<String>();
//             foreach (Appointment r in result)
//             {
//                 resultList.Add(r.Physician.Name+" "+r.Physician.Surname + "-" + r.Date.ToString().Split(" ")[0]);
//             }
//
//             return resultList;
//         }
//     }
// }
