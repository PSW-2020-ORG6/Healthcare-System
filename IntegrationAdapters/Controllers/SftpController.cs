using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;
using Model.Util;

namespace IntegrationAdapters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SftpController : ControllerBase
    {
        private readonly SftpService sftpService;
        private readonly MedicineReportService medicineReportService;

        public SftpController()
        {
            this.sftpService = new SftpService();
            this.medicineReportService = new MedicineReportService();
        }

        [HttpPost("report")]
        public IActionResult Post(Interval interval)
        {
            List<MedicineReport> result = medicineReportService.GetByDateInterval(new TimeInterval(DateTime.Parse(interval.start), DateTime.Parse(interval.end)));
            
            sftpService.GenerateFile(result,"SavedList.txt");

            if (sftpService.SendFile("SavedList.txt")) return Ok(result);
            else return BadRequest();

        }
    }
}
