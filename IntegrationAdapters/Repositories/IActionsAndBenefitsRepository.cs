using IntegrationAdapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Repository.Generic;

namespace IntegrationAdapters.Repositories
{
    public interface IActionsAndBenefitsRepository: IGenericRepository<ActionAndBenefitMessage>
    {
        public bool AddActionAndBenefitMessage(ActionAndBenefitMessage actionsAndBenefits);
        public bool IsMessageExisting(ActionAndBenefitMessage api);
        public List<String> GetHospitalSubscribedPharmacies();
        public List<ActionAndBenefitMessage> GetAllPublishedActionsAndBenefitsMessages();
        public ActionAndBenefitMessage GetActionAndBenefitMessegeByID(Guid acitonID);
    }
}
