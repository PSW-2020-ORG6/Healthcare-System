﻿using System;
using System.Collections.Generic;
using MicroServiceSearch.Backend.Util;
using MicroServiceSearch.Backend.Dto;
using MicroServiceSearch.Backend.DTO;
using MicroServiceSearch.Backend.Model;
using MicroServiceSearch.Backend.Repository.DatabaseSql;
using MicroServiceSearch.Backend.Repository.Generic;

namespace MicroServiceSearch.Backend.Services
{
    public class ReportService
    {
        private IReportRepository _reportRepository=new ReportDatabaseSql();
        private IPrescriptionRepository _prescriptionRepository = new PrescriptionDatabaseSql();
        private SearchEntityDTO searchEntityDTO = new SearchEntityDTO();

        public ReportService(IReportRepository reportRepository, IPrescriptionRepository prescriptionRepository)
        {
            _reportRepository = reportRepository;
            _prescriptionRepository = prescriptionRepository;
        }

        public ReportService()
        {
        }

        /// <summary>
        ///Get reports by search
        ///</summary>
        ///<param name="searchedReport"> search
        ///<param name="dateTimes"> search by date times
        ///</param>
        ///<returns>
        ///list of reports DTO objects
        ///</returns>
        public List<SearchEntityDTO> GetSearchedReport(string searchedReport, DateTime[] dateTimes)
        {
            try
            {
                string[] search = searchedReport.Split(";");
                List<ReportDto> firstSearchedList = GetReportsByProperty(Property(search[0].Split(",")[2]), search[0].Split(",")[1], dateTimes, false);
                for (int i = 1; i < search.Length; i++)
                {
                    if (search[i].Split(",")[0].Equals("AND"))
                        firstSearchedList = OperationAND(firstSearchedList, GetReportsByProperty(Property(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, false));
                    else if (search[i].Split(",")[0].Equals("OR"))
                        firstSearchedList = OperationOR(firstSearchedList, GetReportsByProperty(Property(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, false));
                    else
                        firstSearchedList = OperationAND(firstSearchedList, GetReportsByProperty(Property(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, true));
                }
                return searchEntityDTO.ConverToDTO(firstSearchedList);
            }
            catch (Exception e)
            {
                return searchEntityDTO.ConverToDTO(GetReportsByProperty(Property(searchedReport.Split(",")[2]), searchedReport.Split(",")[1], dateTimes, false));
            }
        }

        private List<ReportDto> GetReportsByProperty(SearchProperty property, string value, DateTime[] dateTimes, bool not)
        {
            List<ReportDto> reports = GetAppointmentDtos(_reportRepository.GetReportsBetweenDates(dateTimes));
            if (!not && property.Equals(SearchProperty.All))
                return GetReportssByAllProperties(value, reports);
            else if (not && property.Equals(SearchProperty.All))
                return GetRepportsByAllPropertiesNegation(value, reports);
            else if (!not && property.Equals(SearchProperty.Patient))
                return GetPrescriptionsByPatient(value, reports);
            else if (not && property.Equals(SearchProperty.Patient))
                return GetPrescriptionsByPatientNegation(value, reports);
            else if (!not && property.Equals(SearchProperty.Doctor))
                return GetPrescriptionsByPhysition(value, reports);
            else if (not && property.Equals(SearchProperty.Doctor))
                return GetPrescriptionsByPhysitionNegation(value, reports);
            else if (!not && property.Equals(SearchProperty.Specialist))
                return GetPrescriptionsBySpecialization(value, reports);
            else if (not && property.Equals(SearchProperty.Specialist))
                return GetPrescriptionsBySpecializationNegation(value, reports);
            else if (!not && property.Equals(SearchProperty.ProcedureType))
                return GetPrescriptionsByProedureType(value, reports);
            else
                return GetPrescriptionsByProedureTypeNegation(value, reports);
        }
        private List<ReportDto> GetAppointmentDtos(List<Report> reports)
        {
            List<ReportDto> reportDtos = new List<ReportDto>();
            foreach (Report r in reports)
            {
                ReportDto reportDto = new ReportDto(r);
                reportDto.Physician = HttpRequest.GetPhysiciantByIdAsync(r.PhysicianSerialNumber).Result.FullName;
                var patient = HttpRequest.GetPatientByIdAsync(r.PatientId).Result;
                reportDto.Patient = patient.Name + " " + patient.Surname;
                var procedureType = HttpRequest.GetProcedureTypeByIdAsync(r.ProcedureTypeSerialNumber).Result;
                reportDto.ProcedureType = procedureType.Name;
                reportDto.Specialization = procedureType.Specialization;
                var p = HttpRequest.GetProcedureTypeByIdAsync(r.ProcedureTypeSerialNumber).Result;
                reportDtos.Add(reportDto);
            }
            return reportDtos;
        }

        private SearchProperty Property(string property)
        {
            if (property.Equals("All"))
                return SearchProperty.All;
            else if (property.Equals("Doctor reports"))
                return SearchProperty.Doctor;
            else if (property.Equals("Patient reports"))
                return SearchProperty.Patient;
            else if (property.Equals("Specialist reports"))
                return SearchProperty.Specialist;
            else
                return SearchProperty.ProcedureType;
        }

        private List<ReportDto> OperationAND(List<ReportDto> firstSearchedList, List<ReportDto> secondSearchedList)
        {
            List<ReportDto> returnList = new List<ReportDto>();
            foreach (ReportDto rfirst in firstSearchedList)
            {
                foreach (ReportDto rsecond in secondSearchedList)
                {
                    if (rfirst.EqualsReport(rsecond))
                    {
                        if (!rfirst.NotInResult(returnList))
                        {
                            returnList.Add(rfirst);
                            break;
                        }
                    }
                }
            }
            return returnList;
        }

        private List<ReportDto> OperationOR(List<ReportDto> firstSearchedList, List<ReportDto> secondSearchedList)
        {
            List<ReportDto> returnList = firstSearchedList;
            foreach (ReportDto rsecond in secondSearchedList)
                if (!rsecond.NotInResult(firstSearchedList))
                    returnList.Add(rsecond);
            return returnList;
        }

        private List<ReportDto> GetPrescriptionsBySpecializationNegation(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (!report.SpecializationContains(value))
                    resultList.Add(report);
            return resultList;
        }

        private List<ReportDto> GetPrescriptionsByProedureTypeNegation(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (!report.ProcedureTypeContains(value))
                    resultList.Add(report);
            return resultList;
        }
        private List<ReportDto> GetPrescriptionsByProedureType(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (report.ProcedureTypeContains(value))
                    resultList.Add(report);
            return resultList;
        }

        private List<ReportDto> GetPrescriptionsBySpecialization(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (report.SpecializationContains(value))
                    resultList.Add(report);
            return resultList;
        }

        private List<ReportDto> GetPrescriptionsByPhysitionNegation(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (!report.PhysicianContains(value))
                    resultList.Add(report);
            return resultList;
        }

        private List<ReportDto> GetPrescriptionsByPhysition(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (report.PhysicianContains(value))
                    resultList.Add(report);
            return resultList;
        }

        private List<ReportDto> GetPrescriptionsByPatientNegation(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (!report.Patient.ToUpper().Contains(value.ToUpper()))
                    resultList.Add(report);
            return resultList;
        }

        private List<ReportDto> GetPrescriptionsByPatient(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (report.PatientContains(value))
                    resultList.Add(report);
            return resultList;
        }
        private List<ReportDto> GetReportssByAllProperties(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (report.AllContains(value))
                    resultList.Add(report);
            return resultList;
        }

        private List<ReportDto> GetRepportsByAllPropertiesNegation(string value, List<ReportDto> reports)
        {
            List<ReportDto> resultList = new List<ReportDto>();
            foreach (ReportDto report in reports)
                if (!report.AllContains(value))
                    resultList.Add(report);
            return resultList;
        }
        /// <summary>
        ///Get report and prescription by appointment
        ///</summary>
        ///<param name="date"> date
        ///<param name="patientSerialNumber"> examined patient
        ///<param name="physicianSerialNumber"> physician who examined the patient 
        ///</param>
        ///<returns>
        ///list string objects
        ///</returns>
        public List<string> GetReportByAppointment(DateTime date, string patientSerialNumber, string physicianSerialNumber)
        {
            var report = _reportRepository.GetReportByAppointment(date, patientSerialNumber, physicianSerialNumber);
            var procedureType = HttpRequest.GetProcedureTypeByIdAsync(report.ProcedureTypeSerialNumber).Result;
            List<string> appointmentReports = new List<string>();
            appointmentReports.Add("ProcedureType: " + procedureType.Name + " " + procedureType.Specialization + ";" +
                            "Findings: " + report.Findings);
            var prescription = (Prescription)report.AdditionalDocument[0];
            prescription = _prescriptionRepository.GetById(prescription.SerialNumber);
            var text = "";
            foreach(MedicineDosage medicineDosage in prescription.MedicineDosage)
            {
                var medicine = HttpRequest.GetMedicineByIdAsync(medicineDosage.SerialNumber).Result;
                text += "Medicine: " + medicine.Name + " - " + medicine.MedicineType + " - " + medicineDosage.Amount + " - " + medicineDosage.Note + ";";
            }
            appointmentReports.Add(text);
            return appointmentReports;
        }
    }
}