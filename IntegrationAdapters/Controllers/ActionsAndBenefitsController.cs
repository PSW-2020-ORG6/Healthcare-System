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
        private readonly ActionsAndBenefitsService  actionsAndBenefitsService;

        public ActionsAndBenefitsController()
        {
            this.actionsAndBenefitsService = new ActionsAndBenefitsService();
        }

        [HttpGet("getActionsAndBenefits")]
        public IEnumerable<ActionAndBenefitMessage> GetActionsAndBenefits()
        {
            return GetSubscribedPharmacyMessages();
        }

        [HttpPost("publishActionsAndBenefits/{trid}")]
        public IActionResult SaveActionsAndBenefitsMessage(Guid trid)
        {
            if (GetActionAndBenefitMessageByID(trid) != null)
            {
                actionsAndBenefitsService.AddActionAndBenefitMessage(GetActionAndBenefitMessageByID(trid));
                return Ok();
            }
            else return NotFound();
              
        }
      
        public List<ActionAndBenefitMessage> GetSubscribedPharmacyMessages()
        {
            List<ActionAndBenefitMessage> SubscribedMessages = new List<ActionAndBenefitMessage>();
            List<String> pharmacyNames = actionsAndBenefitsService.GetHospitalSubscribedPharmacies();
            foreach(ActionAndBenefitMessage message in Program.Messages)
            {
                if (pharmacyNames.Contains(message.PharmacyName)) SubscribedMessages.Add(message);
            }
            return SubscribedMessages;
        }

        public ActionAndBenefitMessage GetActionAndBenefitMessageByID(Guid actionID)
        {
            List<ActionAndBenefitMessage> SubscribedMessages = GetSubscribedPharmacyMessages();
            foreach(ActionAndBenefitMessage actionAndBenefitMessage in SubscribedMessages)
            {
                if (actionAndBenefitMessage.ActionID.Equals(actionID)) return actionAndBenefitMessage;
            }
            return null;
        }
       
    }
}
