using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RenovationDatabaseSql : GenericDatabaseSql<Renovation>, IRenovationRepository
    {
        public RenovationDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Renovation> GetAll()
        {
            // TODO: add renovation to db context
            return base.GetAll();
        }

        public List<Renovation> GetRenovationsByRoom(Room room)
        {
            throw new System.NotImplementedException();
        }
    }
}