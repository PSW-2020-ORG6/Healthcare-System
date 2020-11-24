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
        public ReportService()
        {
            this.reportRepository = new ReportRepository();
        }

        internal List<SearchEntityDTO> GetSearchedReport(string searchedReport)
        {
            string[] search = searchedReport.Split(";");
            List<Report> firstSearchedList = reportRepository.GetReportsByProperty(search[0].Split(",")[2], search[0].Split(",")[1], false);
            if (search.Length == 2)
                return ConverToDTO(firstSearchedList);
            for (int i = 1; i < search.Length; i++)
            {
                if (search[i].Split(",")[2].Equals("AND"))
                    firstSearchedList = OperationAND(firstSearchedList, reportRepository.GetReportsByProperty(search[i].Split(",")[2], search[i].Split(",")[1], false));
                else if (search[i].Split(",")[2].Equals("OR"))
                    firstSearchedList = OperationOR(firstSearchedList, reportRepository.GetReportsByProperty(search[i].Split(",")[2], search[i].Split(",")[1], false));
                else
                    firstSearchedList = OperationAND(firstSearchedList, reportRepository.GetReportsByProperty(search[i].Split(",")[2], search[i].Split(",")[1], true));
            }
            return ConverToDTO(firstSearchedList);

        }

        private List<SearchEntityDTO> ConverToDTO(List<Report> reports)
        {
            List<SearchEntityDTO> searchEntityDTOs = new List<SearchEntityDTO>();
            foreach (Report report in reports)
            {
                string text = "";
                text +=report.Patient.FullName + "; "+report.ProcedureType.Specialization+report.Physitian.FullName+";"+report.ProcedureType.Name;
                searchEntityDTOs.Add(new SearchEntityDTO("Report", text, report.Date));
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
                    if (!rfirst.SerialNumber.Equals(rsecond.SerialNumber))
                    {
                        foreach (Report rReturnList in returnList)
                        {
                            if (!rReturnList.SerialNumber.Equals(rfirst.SerialNumber) || !rReturnList.SerialNumber.Equals(rsecond.SerialNumber))
                                returnList.Add(rfirst);
                            returnList.Add(rsecond);
                        }
                    }
                }
            }
            return returnList;
        }
        private List<Report> OperationOR(List<Report> firstSearchedList, List<Report> secondSearchedList)
        {
            List<Report> returnList = new List<Report>();
            foreach (Report rfirst in firstSearchedList)
            {
                foreach (Report rsecond in secondSearchedList)
                {
                    if (rfirst.SerialNumber.Equals(rsecond.SerialNumber))
                    {
                        foreach (Report rReturnList in returnList)
                        {
                            if (!rReturnList.SerialNumber.Equals(rfirst.SerialNumber) || !rReturnList.SerialNumber.Equals(rsecond.SerialNumber))
                                returnList.Add(rfirst);
                            returnList.Add(rsecond);
                        }
                    }
                }
            }
            return returnList;
        }
    }
}
