using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly TenderService tenderService;

        public TenderController()
        {
            this.tenderService = new TenderService();
        }
        [HttpPost("createTender")]
        public IActionResult AddTender(Tender tender)
        {
            tenderService.AddTender(tender);
            return Ok();
        }
        [HttpGet("getAllTenders")]
        public IEnumerable<Tender> GetAllTenders()
        {
            return tenderService.GetAllTenders();
        }
    }
}
