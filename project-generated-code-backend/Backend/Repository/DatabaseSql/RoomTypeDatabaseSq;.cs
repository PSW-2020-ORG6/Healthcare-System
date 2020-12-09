using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomTypeDatabaseSql: GenericDatabaseSql<RoomType>, IRoomTypeRepository
    {
        public override List<RoomType> GetAll()
        {
            return dbContext.RoomType.ToList();
        }
    }
}