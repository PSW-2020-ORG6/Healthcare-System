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
        public UserController()
        {
            this.prescriptionService = new PrescriptionService();
        }
        [HttpGet("advancedSearch")]
        public List<SearchEntityDTO> GetAllFeedbacks([FromQuery]string prescriptionSearch, [FromQuery] string reportSearch, [FromQuery] bool approximate, [FromQuery] string date)
        {
            return searchEntityDTO.MergeLists(prescriptionService.GetSearchedPrescription(prescriptionSearch),reportService.GetSearchedReport(reportSearch));
        }
    }
}
