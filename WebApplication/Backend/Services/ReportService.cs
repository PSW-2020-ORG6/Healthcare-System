using Model.MedicalExam;
using System;
using System.Collections.Generic;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    public class ReportService
    {
        private IReportRepository iReportRepository;

        public ReportService()
        {
            this.iReportRepository = new ReportRepository();
        }

        public ReportService(IReportRepository iReportRepository)
        {
            this.iReportRepository = iReportRepository;
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get reports by search
        ///</summary>
        ///<param name="searchedReport"> search
        ///<param name="dateTimes"> search by date times
        ///</param>
        ///<returns>
        ///list of reports DTO objects
        ///</returns>
        public List<SearchEntityDTO> GetSearchedReport(string searchedReport, string dateTimes)
        {
            try
            {
                string[] search = searchedReport.Split(";");
                List<Report> firstSearchedList = iReportRepository.GetReportsByProperty(Property(search[0].Split(",")[2]), search[0].Split(",")[1], dateTimes, false);
                for (int i = 1; i < search.Length; i++)
                {
                    if (search[i].Split(",")[0].Equals("AND"))
                        firstSearchedList = OperationAND(firstSearchedList, iReportRepository.GetReportsByProperty(Property(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, false));
                    else if (search[i].Split(",")[0].Equals("OR"))
                        firstSearchedList = OperationOR(firstSearchedList, iReportRepository.GetReportsByProperty(Property(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, false));
                    else
                        firstSearchedList = OperationAND(firstSearchedList, iReportRepository.GetReportsByProperty(Property(search[i].Split(",")[2]), search[i].Split(",")[1], dateTimes, true));
                }
                return ConverToDTO(firstSearchedList);
            }
            catch (Exception e)
            {
                return ConverToDTO(iReportRepository.GetReportsByProperty(Property(searchedReport.Split(",")[2]), searchedReport.Split(",")[1], dateTimes, false));
            }
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

        private List<SearchEntityDTO> ConverToDTO(List<Report> reports)
        {
            if (reports == null || reports.Count == 0)
                return null;
            List<SearchEntityDTO> searchEntityDTOs = new List<SearchEntityDTO>();
            foreach (Report report in reports)
            {
                string text = "";
                text += "Patient: " + report.Patient.FullName + ";Doctor: " + report.ProcedureType.Specialization + " " + report.Physitian.FullName + "; Procedure Type: " + report.ProcedureType.Name;
                searchEntityDTOs.Add(new SearchEntityDTO("Report", text, report.Date.ToString("dddd, MMMM dd yyyy")));
            }
            return searchEntityDTOs;
        }

        ///Tanja Drcelic RA124/2017 and Marija Vucetic RA157/2017
        /// <summary>
        ///Get searched reports by AND operation
        ///</summary>
        ///<param name="firstSearchedList"> first list for operation
        ///<param name="secondSearchedList"> second list for operation
        ///</param>
        ///<returns>
        ///list of reports
        ///</returns>
        private List<Report> OperationAND(List<Report> firstSearchedList, List<Report> secondSearchedList)
        {
            List<Report> returnList = new List<Report>();
            foreach (Report rfirst in firstSearchedList)
            {
                foreach (Report rsecond in secondSearchedList)
                {
                    if (rfirst.SerialNumber.Equals(rsecond.SerialNumber))
                    {
                        if (NotInResult(returnList, rfirst.SerialNumber))
                        {
                            returnList.Add(rfirst);
                            break;
                        }
                    }
                }
            }
            return returnList;
        }

        private bool NotInResult(List<Report> returnList, string serialNumber)
        {
            foreach (Report rReturnList in returnList)
            {
                if (rReturnList.SerialNumber.Equals(serialNumber))
                    return false;
            }
            return true;
        }

        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get searched reports by OR operation
        ///</summary>
        ///<param name="firstSearchedList"> first list for operation
        ///<param name="secondSearchedList"> second list for operation
        ///</param>
        ///<returns>
        ///list of reports
        ///</returns>
        private List<Report> OperationOR(List<Report> firstSearchedList, List<Report> secondSearchedList)
        {
            List<Report> returnList = firstSearchedList;
            foreach (Report rsecond in secondSearchedList)
            {
                if (NotInResult(returnList, rsecond.SerialNumber))
                    returnList.Add(rsecond);
            }
            return returnList;
        }
    }
}
