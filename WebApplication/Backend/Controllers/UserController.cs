using Microsoft.AspNetCore.Mvc;
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
        private readonly PrescriptionService prescriptionService = new PrescriptionService();
        private readonly ReportService reportService = new ReportService();
        private SearchEntityDTO searchEntityDTO = new SearchEntityDTO();

        public UserController()
        {
            this.reportService = new ReportService();
        }

        [HttpGet("advancedSearch")]
        public List<SearchEntityDTO> GetAllFeedbacks([FromQuery] string prescriptionSearch, [FromQuery] string reportSearch, [FromQuery] string date)
        {
            if (!searchEntityDTO.IsDateFormat(date))
                return null;
            if (searchEntityDTO.IsSearchesFormatValid(prescriptionSearch, reportSearch))
            {
                List<SearchEntityDTO> prescriptions = prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
                List<SearchEntityDTO> reports = reportService.GetSearchedReport(reportSearch, date);
                if (!searchEntityDTO.IsNull(prescriptions) && !searchEntityDTO.IsNull(reports))
                    return searchEntityDTO.MergeLists(prescriptions, reports);
                else if (searchEntityDTO.IsNull(prescriptions))
                    return reports;
                else
                    return prescriptions;
            }
            else if (searchEntityDTO.IsSearchFormatValid(prescriptionSearch))
            {
                List<SearchEntityDTO> prescriptions = prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
                if (!searchEntityDTO.IsNull(prescriptions))
                    return prescriptions;
            }
            else if (searchEntityDTO.IsSearchFormatValid(reportSearch))
            {
                List<SearchEntityDTO> reports = reportService.GetSearchedReport(reportSearch, date);
                if (!searchEntityDTO.IsNull(reports))
                    return reports;
            }
            return null;
        }
    }
}
