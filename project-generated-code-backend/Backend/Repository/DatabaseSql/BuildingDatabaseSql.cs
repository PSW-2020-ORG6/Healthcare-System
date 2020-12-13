using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return dbContext.Building.ToList();
        }

        public override Building GetById(string id)
        {
            return dbContext.Building.Find(id);
        }

        public override void Save(Building newEntity)
        {
            dbContext.Building.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Building updateEntity)
        {
            dbContext.Building.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var building = GetById(id);
            if (building == null) return;
            dbContext.Building.Remove(building);
            dbContext.SaveChanges();
        }

        public List<Building> GetByName(string name)
        {
            return GetAll().Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}