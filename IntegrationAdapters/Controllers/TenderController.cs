using IntegrationAdapters.Models;
using IntegrationAdapters.Models.DTO;
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
        [HttpGet("getAllOffers")]
        public IEnumerable<TenderOffer> GetAllOffers()
        {
            return tenderService.GetAllOffers();
        }
        [HttpGet("getTenderById/{name}")]
        public Tender GetTender(string name)
        {
            return tenderService.GetTenderByName(name);
        }
        [HttpPost("addOffer")]
        public IActionResult AddOffer(TenderOffer offer)
        {
            if (tenderService.AddOffer(offer))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("addMedicine")]
        public IActionResult AddMedicine(MedicineDTO medicine)
        {
            if (tenderService.AddMedicine(medicine))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("getAllMedicines/{tenderName}")]
        public IEnumerable<MedicineDTO> GetAllMedicines(string tenderName)
        {
            return tenderService.GetAllMedicines(tenderName);
        }

        [HttpGet("getAllOffersByEmailAndTender/{emailAndTender}")]
        public IEnumerable<TenderOffer> GetAllOffersByEmailAndTender(string emailAndTender)
        {
            return tenderService.GetAllOffersByEmailAndTender(emailAndTender);
        }
    }
}
