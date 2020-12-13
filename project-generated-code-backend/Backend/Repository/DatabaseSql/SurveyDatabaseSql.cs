using HealthClinicBackend.Backend.Model.Survey;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class SurveyDatabaseSql : GenericDatabaseSql<Survey>, ISurveyRepository
    {
        public override List<Survey> GetAll()
        {
            return dbContext.Survey.ToList();
        }

        public override void Save(Survey newEntity)
        {
            dbContext.Survey.Add(newEntity);
            dbContext.SaveChanges();
        }
    }
}