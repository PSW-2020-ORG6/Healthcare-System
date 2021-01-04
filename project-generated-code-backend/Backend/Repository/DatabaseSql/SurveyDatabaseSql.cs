using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Survey;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class SurveyDatabaseSql : GenericDatabaseSql<Survey>, ISurveyRepository
    {
        public override List<Survey> GetAll()
        {
            return DbContext.Survey.ToList();
        }

        public override void Save(Survey newEntity)
        {
            DbContext.Survey.Add(newEntity);
            DbContext.SaveChanges();
        }
    }
}