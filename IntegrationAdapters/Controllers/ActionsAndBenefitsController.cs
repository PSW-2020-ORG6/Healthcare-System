using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.Models;
using IntegrationAdapters.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapters.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : ControllerBase
    {
        private readonly ActionsAndBenefitsService  actionsAndBenefits;
        public  List<ActionAndBenefitMessage> SubscribedMesseges = new List<ActionAndBenefitMessage>();
        public ActionsAndBenefitsController(HealthCareSystemDbContext context)
        {
            this.actionsAndBenefits = new ActionsAndBenefitsService(context);
        }

        [HttpGet("getActionsAndBenefits")]
        public IEnumerable<ActionAndBenefitMessage> GetActionsAndBenefits()
        {
            return Program.Messages;
        }

        [HttpPost("publishActionsAndBenefits/{trid}")]
        public void SaveActionsAndBenefitsMessage(Guid trid)
        {
            Console.WriteLine("Sacuvaj u bazu: "+ trid);
        }
    }
}
