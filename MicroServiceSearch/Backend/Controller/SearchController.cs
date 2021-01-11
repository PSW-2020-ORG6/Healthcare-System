using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MicroServiceSearch.Backend.DTO;
using MicroServiceSearch.Backend.Services;

namespace MicroServiceSearch.Backend.Controllers
{
    /// <summary>
    /// This class does connection with service
    /// </summary>
    [Route("searchMicroservices")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly PrescriptionService prescriptionService = new PrescriptionService();
        private readonly ReportService reportService = new ReportService();
        private SearchEntityDTO searchEntityDTO = new SearchEntityDTO();

        public SearchController()
        {
            //this.reportService = new ReportService();
        }

        [Authorize]
        [HttpGet("prescriptionsSearch/{prescriptionSearch}/{dateFrom}/{dateTo}")]
        public List<SearchEntityDTO> GetAllPrescription(string prescriptionSearch, string dateFrom, string dateTo)
        {
            if (searchEntityDTO.IsDateFormat(dateFrom, dateTo) && searchEntityDTO.IsSearchFormatValid(prescriptionSearch))
            {
                List<SearchEntityDTO> prescriptions = prescriptionService.GetSearchedPrescription(prescriptionSearch,
                                            new DateTime[] { Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo) });
                if (!searchEntityDTO.IsNull(prescriptions))
                    return prescriptions;
            }
            return null;
        }
        [Authorize]
        [HttpGet("reportsSearch/{reportSearch}/{dateFrom}/{dateTo}")]
        public List<SearchEntityDTO> GetAllReports(string reportSearch, string dateFrom, string dateTo)
        {
            if (searchEntityDTO.IsDateFormat(dateFrom, dateTo) && searchEntityDTO.IsSearchFormatValid(reportSearch))
            {
                List<SearchEntityDTO> reports = reportService.GetSearchedReport(reportSearch,
                                                new DateTime[] { Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo) });
                if (!searchEntityDTO.IsNull(reports))
                    return reports;
            }
            return null;
        }
    }
}