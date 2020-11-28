// File:    PhysitianHospitalController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianHospitalController

using Backend.Service.HospitalAccountsService;
using Backend.Service.PatientCareService;
using Backend.Service.SchedulingService;
using health_clinic_class_diagram.Backend.Service.HospitalAccountsService;
using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using System.Collections.Generic;

namespace Backend.Controller.PhysitianControllers
{
    public class PhysitianHospitalAccountsController
    {
        private Physitian loggedPhysitian;
        private HospitalService hospitalService;
        private ReportService reportService;
        private PatientAccountsService patientAccountsService;
        private PhysitianScheduleService physitianScheduleService;

        public PhysitianHospitalAccountsController(Physitian loggedPhysitian)
        {
            this.loggedPhysitian = loggedPhysitian;
            this.hospitalService = new HospitalService();
            this.reportService = new ReportService();
            this.patientAccountsService = new PatientAccountsService();
            this.physitianScheduleService = new PhysitianScheduleService(loggedPhysitian);
        }

        public List<Patient> GetPatientsByPhysitian()
        {
            return patientAccountsService.getPatientsForPhysitian(loggedPhysitian);
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