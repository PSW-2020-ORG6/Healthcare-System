using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public override Floor GetById(string id)
        {
            return dbContext.Floor.Find(id);
        }

        public override void Save(Floor newEntity)
        {
            dbContext.Floor.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Floor updateEntity)
        {
            dbContext.Floor.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var floor = GetById(id);
            if (floor == null) return;
            dbContext.Floor.Remove(floor);
            dbContext.SaveChanges();
        }

        public List<Floor> GetByName(string name)
        {
            return GetAll().Where(f => f.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Floor> GetByBuildingSerialNumber(string buildingSerialNumber)
        {
            return GetAll().Where(f => f.BuildingSerialNumber.Equals(buildingSerialNumber)).ToList();
        }
    }
}