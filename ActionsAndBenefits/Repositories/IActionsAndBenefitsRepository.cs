using ActionsAndBenefits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinicBackend.Backend.Model.PharmacySupport;

namespace ActionsAndBenefits.Repositories { 
    public interface IActionsAndBenefitsRepository
    {
        public bool AddActionAndBenefitMessage(ActionAndBenefitMessage actionsAndBenefits);
        public bool IsMessageExisting(ActionAndBenefitMessage api);
        public List<String> GetHospitalSubscribedPharmacies();
        public List<ActionAndBenefitMessage> GetAllPublishedActionsAndBenefitsMessages();
        public ActionAndBenefitMessage GetActionAndBenefitMessegeByID(Guid acitonID);
    }
}
