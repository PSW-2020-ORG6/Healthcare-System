using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class ActionAndBenefitMessageDatabaseSql : GenericDatabaseSql<ActionAndBenefitMessage>,
        IActionAndBenefitMessageRepository
    {
        public override List<ActionAndBenefitMessage> GetAll()
        {
            return DbContext.ActionAndBenefitMessage.ToList();
        }
    }
}