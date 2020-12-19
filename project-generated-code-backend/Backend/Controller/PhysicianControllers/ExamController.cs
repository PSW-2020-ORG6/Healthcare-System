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
        private Patient _selectedPatient;
        private Report _currentReport;

        private readonly ReportService _reportService;

        public ExamController(ReportService reportService)
        {
            _reportService = reportService;
        }

        public void StartExam(Appointment appointment)
        {
            String patientConditions = GetPatientConditions();
            _currentReport = new Report(DateTime.Today, "", _selectedPatient, appointment.Physician, patientConditions);
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
            return lastReport != null ? lastReport.PatientConditions : "";
        }
    }
}