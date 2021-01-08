using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
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
            return DbContext.Building.ToList();
        }

        public override Building GetById(string id)
        {
            return DbContext.Building.Find(id);
        }

        public override void Save(Building newEntity)
        {
            DbContext.Building.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Building updateEntity)
        {
            DbContext.Building.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var building = GetById(id);
            if (building == null) return;
            DbContext.Building.Remove(building);
            DbContext.SaveChanges();
        }

        public List<Building> GetByName(string name)
        {
            return GetAll().Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public override Building GetBySerialNumber(string serialNumber)
        {
            return GetAll().Where(b => b.SerialNumber.Contains(serialNumber)).ToList()[0];
        }
    }
}