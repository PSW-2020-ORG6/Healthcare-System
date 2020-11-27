using Microsoft.AspNetCore.Mvc;
using Model.MedicalExam;
using System.Collections.Generic;
using WebApplication.Backend.DTO;
using WebApplication.Backend.Services;

namespace WebApplication.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PrescriptionService prescriptionService;
        private readonly ReportService reportService;
        private SearchEntityDTO searchEntityDTO = new SearchEntityDTO();
        private DateTimeDTO dateTimeDTO = new DateTimeDTO();
        public UserController()
        {
            this.prescriptionService = new PrescriptionService();
            this.reportService = new ReportService();
        }
        [HttpGet("advancedSearch")]
        public List<SearchEntityDTO> GetAllFeedbacks([FromQuery]string prescriptionSearch, [FromQuery] string reportSearch, [FromQuery] string date)
        {
            if (!searchEntityDTO.IsDateFormatValid(date))
                return null;
            if (!searchEntityDTO.IsValicSeacrhes(prescriptionSearch, reportSearch))
            {
                List<SearchEntityDTO> prescriptions = prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
                List<SearchEntityDTO> reports = reportService.GetSearchedReport(reportSearch, date);
                if (!searchEntityDTO.IsNull(prescriptions) && !searchEntityDTO.IsNull(reports))
                    return searchEntityDTO.MergeLists(prescriptions, reports);
            }
            else if (!searchEntityDTO.IsValicSeacrh(prescriptionSearch))
            {
                List<SearchEntityDTO> prescriptions = prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
                if (!searchEntityDTO.IsNull(prescriptions))
                    return prescriptions;
            }
            else
            {
                List<SearchEntityDTO> reports = reportService.GetSearchedReport(reportSearch, date);
                if (!searchEntityDTO.IsNull(reports))
                    return reports;
            }
                return null;
        } 
    }
}
