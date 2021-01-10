using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace MicroServiceAccount.Backend.Repository.DatabaseSql
{
    public class ActionAndBenefitMessageDatabaseSql : GenericMsAccountDatabaseSql<ActionAndBenefitMessage>,
        IActionAndBenefitMessageRepository
    {
        public ActionAndBenefitMessageDatabaseSql(MsAccountDbContext dbContext) : base(dbContext)
        {
        }

        public override List<ActionAndBenefitMessage> GetAll()
        {
            return DbContext.ActionAndBenefitMessage.ToList();
        }
    }
}