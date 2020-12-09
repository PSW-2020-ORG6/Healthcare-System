// File:    PhysitianHospitalController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianHospitalController

using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using HealthClinicBackend.Backend.Service.PatientCareService;
using HealthClinicBackend.Backend.Service.SchedulingService;
using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class PhysicianHospitalAccountsController
    {
        private readonly Physician _loggedPhysician;
        private HospitalService _hospitalService;
        private readonly ReportService _reportService;
        private readonly PatientAccountsService _patientAccountsService;
        private readonly PhysicianScheduleService _physicianScheduleService;

        public PhysicianHospitalAccountsController(Physician loggedPhysician)
        {
            _loggedPhysician = loggedPhysician;
            _hospitalService = new HospitalService();
            _reportService = new ReportService();
            _patientAccountsService = new PatientAccountsService();
            _physicianScheduleService = new PhysicianScheduleService(loggedPhysician);
        }

        public List<Patient> GetPatientsByPhysician()
        {
            return _patientAccountsService.getPatientsForPhysitian(_loggedPhysician);
        }

        public Appointment GetNextAppointmentForPatient(Patient patient)
        {
            return _physicianScheduleService.GetNextAppointmentForPatient(patient);
        }

        public Appointment GetPreviousAppointmentForPatient(Patient patient)
        {
            return _physicianScheduleService.GetPreviousAppointmentForPatient(patient);
        }

        public bool IsPatientScheduledToday(Patient patient)
        {
            Appointment todaysAppointment = _physicianScheduleService.GetTodaysAppointmentForPatient(patient);
            return todaysAppointment != null;
        }

        public List<Report> GetAllReportsForPatient(Patient patient)
        {
            return _reportService.GetReportsByPatient(patient);
        }

        public Report GetLastReportForPatient(Patient patient)
        {
            return _reportService.GetLastReportByPatient(patient);
        }

        public Appointment GetTodaysAppointmentForPatient(Patient patient)
        {
            return _physicianScheduleService.GetTodaysAppointmentForPatient(patient);
        }
    }
}