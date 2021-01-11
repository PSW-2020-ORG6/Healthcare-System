using System.Collections.Generic;
using System.Linq;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAppointment.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class FloorDatabaseSql : GenericMsAppointmentDatabaseSql<Floor>, IFloorRepository
    {
        public FloorDatabaseSql() : base()
        {
        }

        public FloorDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Floor> GetAll()
        {
            return DbContext.Floor
                .Include(f => f.Building)
                .Include(f => f.Rooms)
                .ToList();
        }

        public List<Floor> GetByName(string name)
        {
            return GetAll().Where(f => f.Name.Equals(name)).ToList();
        }

        public List<Floor> GetByBuildingSerialNumber(string buildingSerialNumber)
        {
            return GetAll().Where(f => f.BuildingSerialNumber.Equals(buildingSerialNumber)).ToList();
        }
    }
}