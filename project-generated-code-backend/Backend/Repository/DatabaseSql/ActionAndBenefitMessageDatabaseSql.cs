using HealthClinicBackend.Backend.Model.PharmacySupport;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class ActionAndBenefitMessageDatabaseSql : GenericDatabaseSql<ActionAndBenefitMessage>,
        IActionAndBenefitMessageRepository
    {
        public ActionAndBenefitMessageDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<ActionAndBenefitMessage> GetAll()
        {
            return DbContext.ActionAndBenefitMessage.ToList();
        }
    }
}