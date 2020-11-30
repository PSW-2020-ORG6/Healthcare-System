using IntegrationAdapters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Repositories
{
    public class ActionsAndBenefitsRepository : IActionsAndBenefitsRepository
    {
        public DbContextOptions<HealthCareSystemDbContext> options = new DbContextOptionsBuilder<HealthCareSystemDbContext>()
                .UseMySql(connectionString: "server=localhost;port=3306;database=newmydb;user=root;password=root").UseLazyLoadingProxies()
                .Options;
        public readonly HealthCareSystemDbContext dbContext;

        public ActionsAndBenefitsRepository()
        {
            this.dbContext = new HealthCareSystemDbContext(options);
        }

        public bool AddActionAndBenefitMessage(ActionAndBenefitMessage actionsAndBenefits)
        {
            if (!IsMessageExisting(actionsAndBenefits))
            {
                dbContext.Add<ActionAndBenefitMessage>(actionsAndBenefits);
                dbContext.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool IsMessageExisting(ActionAndBenefitMessage api)
        {
            List<ActionAndBenefitMessage> apis = dbContext.ActionAndBenefitMessage.ToList();
            foreach (ActionAndBenefitMessage a in apis)
            {
                if (a.ActionID.Equals(api.ActionID)) return true;
            }
            return false;
        }

        public List<String> GetHospitalSubscribedPharmacies()
        {
            List<String> SubscribedPharmacyNameList = new List<String>();
            List<Api> apis = dbContext.Apis.ToList();
            foreach (Api a in apis)
            {
                if (a.Subscribed) SubscribedPharmacyNameList.Add(a.PharmacyName);
            }
            return SubscribedPharmacyNameList;
        }

        public List<ActionAndBenefitMessage> GetAllPublishedActionsAndBenefitsMessages()
        {
            return dbContext.ActionAndBenefitMessage.ToList();
        }

        public ActionAndBenefitMessage GetActionAndBenefitMessegeByID( Guid id)
        {
            foreach (ActionAndBenefitMessage abMessage in GetAllPublishedActionsAndBenefitsMessages())
            {
                if (abMessage.ActionID.Equals(id)) return abMessage;
            }
            return null;
        }
    }
}
