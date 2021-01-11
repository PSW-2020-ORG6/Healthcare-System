using MicroServiceSearch.Backend.Dto;
using MicroServiceSearch.Backend.Model;
using System;
using System.Collections.Generic;
namespace MicroServiceSearch.Backend.DTO
{
    public class SearchEntityDTO
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }

        public SearchEntityDTO()
        {
        }

        public SearchEntityDTO(string type, string text, string date)
        {
            this.Type = type;
            this.Text = text;
            this.Date = date;
        }

        public List<SearchEntityDTO> MergeLists(List<SearchEntityDTO> searchEntityDTOPrescriotions, List<SearchEntityDTO> searchEntityDTOReport)
        {
            List<SearchEntityDTO> searchEntityDTOs = searchEntityDTOPrescriotions;
            if (searchEntityDTOReport != null)
            {
                foreach (SearchEntityDTO searchEntityDTO in searchEntityDTOReport)
                    searchEntityDTOs.Add(searchEntityDTO);
            }
            return searchEntityDTOs;
        }

        public bool IsSearchesFormatValid(string prescriptionSearch, string reportSearch)
        {
            return IsSearchFormatValid(prescriptionSearch) && IsSearchFormatValid(reportSearch);
        }

        public bool IsSearchFormatValid(string search)
        {
            return search != null || search.Split("-").Length < 3 || search.Split("-").Length > 4;
        }

        public bool IsDateFormat(string dateFrom, string dateTo)
        {
            return IsSearchFormatValid(dateFrom) && IsSearchFormatValid(dateTo);
        }

        public bool IsNull(List<SearchEntityDTO> searchEntityDTOs)
        {
            return searchEntityDTOs == null;
        }

        public List<SearchEntityDTO> ConverToDTO(List<ReportDto> reports)
        {
            if (reports == null || reports.Count == 0)
                return null;
            List<SearchEntityDTO> searchEntityDTOs = new List<SearchEntityDTO>();
            foreach (ReportDto report in reports)
            {
                string text = "";
                text += "Patient: " + report.Patient + ";Doctor: " + report.Specialization + " " + report.Physician + "; Procedure Type: " + report.ProcedureType;
                searchEntityDTOs.Add(new SearchEntityDTO("Report", text, report.Date));
            }
            return searchEntityDTOs;
        }

        public List<SearchEntityDTO> ConverPrescriptionToDTO(List<Prescription> prescriptions)
        {
            if (prescriptions == null || prescriptions.Count == 0)
                return null;
            List<SearchEntityDTO> searchEntityDTOs = new List<SearchEntityDTO>();
            foreach (Prescription prescription in prescriptions)
            {
                string text = "";
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                    text += "Medicine: " + medicineDosage.Medicine.GenericName + " - " + medicineDosage.Medicine.MedicineType.Type + " - " + medicineDosage.Amount + " - " + medicineDosage.Note + ";\n";
                searchEntityDTOs.Add(new SearchEntityDTO("Prescriprion", text, prescription.Date.ToString("dddd, MMMM dd yyyy")));
            }
            return searchEntityDTOs;
        }
    }
}
