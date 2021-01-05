using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class FloorDatabaseSql : GenericDatabaseSql<Floor>, IFloorRepository
    {
        public FloorDatabaseSql() : base()
        {
        }

        public FloorDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
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