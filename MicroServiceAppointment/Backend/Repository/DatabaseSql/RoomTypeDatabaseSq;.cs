using System.Collections.Generic;
using System.Linq;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAppointment.Backend.Repository.Generic;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class RoomTypeDatabaseSql : GenericMsAppointmentDatabaseSql<RoomType>, IRoomTypeRepository
    {
        public RoomTypeDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
        {
        }

        public override List<RoomType> GetAll()
        {
            return DbContext.RoomType.ToList();
        }
    }
}