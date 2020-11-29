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
        private ActionsAndBenefitsRepository actionsAndBenefitsRepository;

        public ActionsAndBenefitsService(HealthCareSystemDbContext context)
        {
            this.actionsAndBenefitsRepository = new ActionsAndBenefitsRepository(context);
        }

        public bool AddActionAndBenefitMessage(ActionAndBenefitMessage actionsAndBenefitsMessage)
        {
            return actionsAndBenefitsRepository.AddActionAndBenefitMessage(actionsAndBenefitsMessage);
            
        }
    }
}
