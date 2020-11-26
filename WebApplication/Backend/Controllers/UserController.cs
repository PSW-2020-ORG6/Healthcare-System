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
            if(!searchEntityDTO.IsNotEmptySearches(prescriptionSearch, reportSearch))
                return searchEntityDTO.MergeLists(prescriptionService.GetSearchedPrescription(prescriptionSearch, date),reportService.GetSearchedReport(reportSearch, date));
            if (!searchEntityDTO.IsNotEmptySeacrh(prescriptionSearch))
                return prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
            else
                return reportService.GetSearchedReport(reportSearch, date);

        }   
    }
}
