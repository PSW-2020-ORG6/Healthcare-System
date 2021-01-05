using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class BuildingDatabaseSql : GenericDatabaseSql<Building>, IBuildingRepository
    {
        public BuildingDatabaseSql() : base()
        {
        }

        public BuildingDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Building> GetAll()
        {
            return DbContext.Building
                .Include(b => b.Floors)
                .ToList();
        }

        public List<Building> GetByName(string name)
        {
            return GetAll().Where(b => b.Name.Equals(name)).ToList();
        }
    }
}