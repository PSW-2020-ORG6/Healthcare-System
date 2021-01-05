// File:    PhysitianHospitalController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianHospitalController

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using HealthClinicBackend.Backend.Service.PatientCareService;
using HealthClinicBackend.Backend.Service.SchedulingService;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class PhysicianHospitalAccountsController
    {
        private readonly Physician _loggedPhysician;
        private readonly ReportService _reportService;
        private readonly PatientAccountsService _patientAccountsService;
        private readonly PhysicianScheduleService _physicianScheduleService;

        public PhysicianHospitalAccountsController(Physician loggedPhysician, ReportService reportService,
            PatientAccountsService patientAccountsService, PhysicianScheduleService physicianScheduleService)
        {
            _loggedPhysician = loggedPhysician;
            _reportService = reportService;
            _patientAccountsService = patientAccountsService;
            _physicianScheduleService = physicianScheduleService;
        }

        public List<Patient> GetPatientsByPhysician()
        {
            return _patientAccountsService.GetPatientsForPhysician(_loggedPhysician);
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