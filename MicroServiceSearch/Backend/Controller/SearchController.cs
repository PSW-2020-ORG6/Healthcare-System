//using MicroServiceSearch.Backend.Service;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using WebApplication.Backend.DTO;

//namespace MicroServiceSearch.Backend.Controllers
//{
//    /// <summary>
//    /// This class does connection with service
//    /// </summary>
//    [Route("user")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly PrescriptionService _prescriptionService;
//        private readonly ReportService _reportService;
//        private SearchEntityDTO searchEntityDTO = new SearchEntityDTO();

//        public UserController(PrescriptionService prescriptionService, ReportService reportService)
//        {
//            _prescriptionService = prescriptionService;
//            _reportService = reportService;
//        }
//        [Authorize]
//        [HttpGet("advancedSearch")]
//        public List<SearchEntityDTO> GetAllFeedbacks([FromQuery] string prescriptionSearch,
//            [FromQuery] string reportSearch, [FromQuery] string date)
//        {
//            if (!searchEntityDTO.IsDateFormat(date))
//                return null;
//            if (searchEntityDTO.IsSearchesFormatValid(prescriptionSearch, reportSearch))
//            {
//                List<SearchEntityDTO> prescriptions =
//                    _prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
//                List<SearchEntityDTO> reports = _reportService.GetSearchedReport(reportSearch, date);
//                if (!searchEntityDTO.IsNull(prescriptions) && !searchEntityDTO.IsNull(reports))
//                    return searchEntityDTO.MergeLists(prescriptions, reports);
//                else if (searchEntityDTO.IsNull(prescriptions))
//                    return reports;
//                else
//                    return prescriptions;
//            }
//            else if (searchEntityDTO.IsSearchFormatValid(prescriptionSearch))
//            {
//                List<SearchEntityDTO> prescriptions =
//                    _prescriptionService.GetSearchedPrescription(prescriptionSearch, date);
//                if (!searchEntityDTO.IsNull(prescriptions))
//                    return prescriptions;
//            }
//            else if (searchEntityDTO.IsSearchFormatValid(reportSearch))
//            {
//                List<SearchEntityDTO> reports = _reportService.GetSearchedReport(reportSearch, date);
//                if (!searchEntityDTO.IsNull(reports))
//                    return reports;
//            }

//            return null;
//        }
//    }
//}
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