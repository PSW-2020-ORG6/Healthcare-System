using System.Collections.Generic;
using System.Linq;
using health_clinic_class_diagram.Backend.Repository;
using HealthClinicBackend.Backend.Model.Hospital;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class FloorDatabaseSql: GenericDatabaseSql<Floor>, IFloorRepository
    {
        public override List<Floor> GetAll()
        {
            return dbContext.Floor
                .Include(f => f.Building)
                .Include(f => f.Rooms)
                .ToList();
        }
    }
}