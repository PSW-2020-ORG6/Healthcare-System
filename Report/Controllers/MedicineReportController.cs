using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Report.Models;
using Report.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Report.Controllers
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
