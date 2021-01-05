// File:    ExamController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class ExamController

using System;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.PatientCareService;

namespace HealthClinicBackend.Backend.Controller.PhysicianControllers
{
    public class ExamController
    {
        private Physician _loggedPhysician;
        private Patient _selectedPatient;
        private Report _currentReport;

        private readonly ReportService _reportService;

        public ExamController(Appointment appointment, ReportService reportService)
        {
            _reportService = reportService;

            _loggedPhysician = appointment.Physician;
            SelectedPatient = appointment.Patient;
            String patientConditions = GetPatientConditions();
            CurrentReport = new Report(DateTime.Today, "", _selectedPatient, _loggedPhysician, patientConditions);
        }

        public void SaveReport()
        {
            _reportService.NewReport(_currentReport);
        }

        public void AddDocument(AdditionalDocument additionalDocument)
        {
            _currentReport.AddAdditionalDocument(additionalDocument);
        }

        private String GetPatientConditions()
        {
            Report lastReport = _reportService.GetLastReportByPatient(_selectedPatient);

            if (lastReport != null)
            {
                return lastReport.PatientConditions;
            }

            return "";
        }

        public Report CurrentReport
        {
            get => _currentReport;
            set => _currentReport = value;
        }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => _selectedPatient = value;
        }
    }
}