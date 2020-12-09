// File:    PhysitianHospitalController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianHospitalController

using Backend.Service.SchedulingService;
using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;
using HealthClinicBackend.Backend.Service.PatientCareService;

namespace Backend.Controller.PhysitianControllers
{
    public class PhysitianHospitalAccountsController
    {
        private Physician _loggedPhysician;
        private HospitalService hospitalService;
        private ReportService reportService;
        private PatientAccountsService patientAccountsService;
        private PhysitianScheduleService physitianScheduleService;

        public PhysitianHospitalAccountsController(Physician loggedPhysician)
        {
            this._loggedPhysician = loggedPhysician;
            this.hospitalService = new HospitalService();
            this.reportService = new ReportService();
            this.patientAccountsService = new PatientAccountsService();
            this.physitianScheduleService = new PhysitianScheduleService(loggedPhysician);
        }

        public List<Patient> GetPatientsByPhysitian()
        {
            return patientAccountsService.getPatientsForPhysitian(_loggedPhysician);
        }
        
        public Appointment GetNextAppointmentForPatient(Patient patient)
        {

            return physitianScheduleService.GetNextAppointmentForPatient(patient);
        }

        public Appointment GetPreviousAppointmentForPatient(Patient patient)
        {
            return physitianScheduleService.GetPreviousAppointmentForPatient(patient);
        }
        public bool IsPatientScheduledToday(Patient patient)
        {
            Appointment todaysAppointment = physitianScheduleService.GetTodaysAppointmentForPatient(patient);
            return todaysAppointment != null;
        }

        public List<Report> GetAllReportsForPatient(Patient patient)
        {
            return reportService.GetReportsByPatient(patient);
        }
        public Report GetLastReportForPatient(Patient patient)
        {
            return reportService.GetLastReportByPatient(patient);
        }

        public Appointment GetTodaysAppointmentForPatient(Patient patient)
        {
            return physitianScheduleService.GetTodaysAppointmentForPatient(patient);
        }
        
    }
}