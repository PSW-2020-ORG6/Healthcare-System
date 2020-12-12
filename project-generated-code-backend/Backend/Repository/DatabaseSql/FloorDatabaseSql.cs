using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class FloorDatabaseSql : GenericDatabaseSql<Floor>, IFloorRepository
    {
        public override List<Floor> GetAll()
        {
            return dbContext.Floor
                .Include(f => f.Building)
                .Include(f => f.Rooms)
                .ToList();
        }

        
        public override Floor GetById(string serialNumber)
        {
            return GetAll().Where(f => f.SerialNumber.Equals(serialNumber)).ToList()[0];
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