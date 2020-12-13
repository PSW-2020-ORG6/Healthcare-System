using IntegrationAdapters.Models;
using IntegrationAdapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Services
{
    public class ActionsAndBenefitsService
    {
        private IActionsAndBenefitsRepository actionsAndBenefitsRepository;

        public ActionsAndBenefitsService()
        {
            this.actionsAndBenefitsRepository = new ActionsAndBenefitsRepository();
        }
        public ActionsAndBenefitsService(IActionsAndBenefitsRepository actionsAndBenefitsRepository)
        {
            this.actionsAndBenefitsRepository = actionsAndBenefitsRepository;
        }

        public bool AddActionAndBenefitMessage(ActionAndBenefitMessage actionsAndBenefitsMessage)
        {
            return actionsAndBenefitsRepository.AddActionAndBenefitMessage(actionsAndBenefitsMessage);
        }

        public List<String> GetHospitalSubscribedPharmacies()
        {
            return actionsAndBenefitsRepository.GetHospitalSubscribedPharmacies();
        }

        public List<ActionAndBenefitMessage> GetAllPublishedActionsAndBenefitsMessages()
        {
            return actionsAndBenefitsRepository.GetAllPublishedActionsAndBenefitsMessages();
        }
        public ActionAndBenefitMessage GetActionAndBenefitMessegeByID(Guid acitonID)
        {
            return actionsAndBenefitsRepository.GetActionAndBenefitMessegeByID( acitonID);
        }

        public bool IsMessageExisting(ActionAndBenefitMessage api)
        {
            return actionsAndBenefitsRepository.IsMessageExisting(api);
        }
    }
}
