using Model.MedicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Repositorys;

namespace WebApplication.Backend.Services
{
    public class ReportService
    {
        private ReportRepository reportRepository;
        private IReportRepository iReportRepository;
        public ReportService()
        {
            this.reportRepository = new ReportRepository();
        }
        public ReportService(IReportRepository iReportRepository)
        {
            this.iReportRepository = iReportRepository;
        }
        public List<SearchEntityDTO> GetSearchedReport(string searchedReport, string dateTimes)
        {
            try
            {
                string[] search = searchedReport.Split(";");

                List<Report> firstSearchedList = iReportRepository.GetReportsByProperty(search[0].Split(",")[2], search[0].Split(",")[1], dateTimes,false);

                for (int i = 1; i < search.Length; i++)
                {
                    if (search[i].Split(",")[0].Equals("AND"))
                        firstSearchedList = OperationAND(firstSearchedList, iReportRepository.GetReportsByProperty(search[i].Split(",")[2], search[i].Split(",")[1], dateTimes,false));
                    else if (search[i].Split(",")[0].Equals("OR"))
                        firstSearchedList = OperationOR(firstSearchedList, iReportRepository.GetReportsByProperty(search[i].Split(",")[2], search[i].Split(",")[1], dateTimes,false));
                    else
                        firstSearchedList = OperationAND(firstSearchedList, iReportRepository.GetReportsByProperty(search[i].Split(",")[2], search[i].Split(",")[1], dateTimes,true));
                }

                return ConverToDTO(firstSearchedList);
            }
            catch (Exception e)
            {
                return ConverToDTO(iReportRepository.GetReportsByProperty(searchedReport.Split(",")[2], searchedReport.Split(",")[1], dateTimes,false));
            }

        }

        private List<SearchEntityDTO> ConverToDTO(List<Report> reports)
        {
            if (reports == null || reports.Count == 0)
                return null;
            List<SearchEntityDTO> searchEntityDTOs = new List<SearchEntityDTO>();
            foreach (Report report in reports)
            {
                string text = "";
                text +="Patient: "+report.Patient.FullName + ";Doctor: "+report.ProcedureType.Specialization+" "+report.Physitian.FullName+"; Procedure Type: "+report.ProcedureType.Name;
                searchEntityDTOs.Add(new SearchEntityDTO("Report", text,report.Date.ToString("dddd, MMMM dd yyyy")));
            }
            return searchEntityDTOs;
        }

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
