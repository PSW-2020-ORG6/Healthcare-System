using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicineReportController : ControllerBase
    {
        private readonly MedicineReportService medicineReportService;

        public MedicineReportController()
        {
            this.medicineReportService = new MedicineReportService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            medicineReportService.AddPrescription();
            return Ok();
        }
    }
}
