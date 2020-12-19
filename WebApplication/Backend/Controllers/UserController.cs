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
        private readonly PrescriptionService _prescriptionService;
        private readonly ReportService _reportService;
        private SearchEntityDTO searchEntityDTO = new SearchEntityDTO();

        public UserController(PrescriptionService prescriptionService, ReportService reportService)
        {
            _prescriptionService = prescriptionService;
            _reportService = reportService;
        }

        [HttpGet("advancedSearch")]
        public List<SearchEntityDTO> GetAllFeedbacks([FromQuery] string prescriptionSearch,
            [FromQuery] string reportSearch, [FromQuery] string date)
        {
            if (!searchEntityDTO.IsDateFormat(date))
                return null;
            if (searchEntityDTO.IsSearchesFormatValid(prescriptionSearch, reportSearch))
            {
                List<SearchEntityDTO> prescriptions =
                    _prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
                List<SearchEntityDTO> reports = _reportService.GetSearchedReport(reportSearch, date);
                if (!searchEntityDTO.IsNull(prescriptions) && !searchEntityDTO.IsNull(reports))
                    return searchEntityDTO.MergeLists(prescriptions, reports);
                else if (searchEntityDTO.IsNull(prescriptions))
                    return reports;
                else
                    return prescriptions;
            }
            else if (searchEntityDTO.IsSearchFormatValid(prescriptionSearch))
            {
                List<SearchEntityDTO> prescriptions =
                    _prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
                if (!searchEntityDTO.IsNull(prescriptions))
                    return prescriptions;
            }
            else if (searchEntityDTO.IsSearchFormatValid(reportSearch))
            {
                List<SearchEntityDTO> reports = _reportService.GetSearchedReport(reportSearch, date);
                if (!searchEntityDTO.IsNull(reports))
                    return reports;
            }

            return null;
        }
    }
}