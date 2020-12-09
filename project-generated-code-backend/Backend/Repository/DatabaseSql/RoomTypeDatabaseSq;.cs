using System.Collections.Generic;
using System.Linq;
using HCI_SIMS_PROJEKAT.Backend.Repository;
using HealthClinicBackend.Backend.Model.Hospital;

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