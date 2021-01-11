using System.Collections.Generic;
using System.Linq;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAppointment.Backend.Repository.DatabaseSql;
using MicroServiceAppointment.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class BuildingDatabaseSql : GenericMsAppointmentDatabaseSql<Building>, IBuildingRepository
    {
        public BuildingDatabaseSql() : base()
        {
        }

        public BuildingDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
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