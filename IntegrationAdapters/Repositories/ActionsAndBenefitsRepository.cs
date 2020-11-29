using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public class ActionsAndBenefitsRepository
    {
        public readonly HealthCareSystemDbContext dbContext;

        public ActionsAndBenefitsRepository(HealthCareSystemDbContext context)
        {
            this.dbContext = context;
        }

        public bool AddActionAndBenefitMessage(ActionAndBenefitMessage actionsAndBenefits)
        {
            if (!isMessageExisting(actionsAndBenefits))
            {
                dbContext.Add<ActionAndBenefitMessage>(actionsAndBenefits);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isMessageExisting(ActionAndBenefitMessage api)
        {
            List<ActionAndBenefitMessage> apis = dbContext.ActionAndBenefitMessage.ToList();
            foreach (ActionAndBenefitMessage a in apis)
            {
                if (a.Text.Equals(api.Text)) return true;
            }
            return false;
        }
    }
}
