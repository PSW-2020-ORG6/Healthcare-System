// File:    ExamController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class ExamController

using System;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.PatientCareService;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class ExamController
    {
        private Physician _loggedPhysician;
        private Patient selectedPatient;
        private Report currentReport;

        private ReportService reportService;

        public ExamController(Appointment appointment)
        {
            //this._loggedPhysician = appointment.Physician;
            //this.SelectedPatient = appointment.Patient;
            //ProcedureType procedure = appointment.ProcedureType;

            reportService = new ReportService();

            String patientConditions = this.GetPatientConditions();
            this.CurrentReport = new Report(DateTime.Today, "", selectedPatient, _loggedPhysician, patientConditions);
        }

        public void SaveReport()
        {
            reportService.NewReport(currentReport);
        }

        public void AddDocument(AdditionalDocument additionalDocument)
        {
            currentReport.AddAdditionalDocument(additionalDocument);
        }

        private String GetPatientConditions()
        {
            Report lastReport = reportService.GetLastReportByPatient(selectedPatient);

            if (lastReport != null)
            {
                return lastReport.PatientConditions;
            }

            return "";
        }

        public Report CurrentReport { get => currentReport; set => currentReport = value; }
        public Patient SelectedPatient { get => selectedPatient; set => selectedPatient = value; }

    }
}