//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using HealthClinicBackend.Backend.Dto;
//using HealthClinicBackend.Backend.Model.Accounts;
//using HealthClinicBackend.Backend.Model.Schedule;
//using WebApplication.Backend.Repositorys;
//using WebApplication.Backend.Repositorys.Interfaces;

//namespace WebApplication.Backend.Services
//{
//    public class AppointmentsService
//    {
//        private IAppointmentRepository iappointmentRepository;
//        public AppointmentsService()
//        {
//            this.iappointmentRepository = new AppointmentRepository();
//        }
//        public AppointmentsService(IAppointmentRepository iApointmentRepository)
//        {
//            this.iappointmentRepository = iApointmentRepository;
//        }

//        public List<Appointment> GetAllAppointmentsByPatientId(string patientId)
//        {
//            return iappointmentRepository.GetAllAppointmentByPatientId(patientId);
//        }

//        public List<Appointment> GetAllAppointments()
//        {
//            return iappointmentRepository.GetAllAppointments();
//        }

//        public List<Appointment> GetAllAppointmentsByPatientIdActive(string patientId)
//        {
//            return iappointmentRepository.GetAllAppointmentsByPatientIdActive(patientId);
//        }

//        public List<Appointment> GetAllAppointmentsByPatientIdCanceled(string patientId)
//        {
//            return iappointmentRepository.GetAllAppointmentsByPatientIdCanceled(patientId);
//        }

//        public bool CancelAppointment(string appointmentSerialNumber)
//        {
//            return iappointmentRepository.CancelAppointment(appointmentSerialNumber);

//        }

//        public bool IsUserMalicious(string patientId)
//        {

//            List<DateTime> dates = iappointmentRepository.GetCancelingDates(patientId);

//            DateTime date = DateTime.Now;

//            dates.Sort((date1, date2) => date2.CompareTo(date1));

//            if (dates.Count >= 2)
//            {
//                System.TimeSpan difference = dates[1].Subtract(date);
//                if (Math.Abs(difference.Days) <= 30)
//                    return true;
//                else
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public bool SetUserToMalicious(string patientId)
//        {
//            return iappointmentRepository.SetUserToMalicious(patientId);
//        }

//    }
//}
