using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class EquipmentDatabaseSql : GenericDatabaseSql<Equipment>, IEquipmentRepository
    {
        public override List<Equipment> GetAll()
        {
            return dbContext.Equipment
                .Include(e => e.Building)
                .Include(e => e.Floor)
                .Include(e => e.Room)
                .ToList();
        }

        public List<Equipment> GetByName(string name)
        {
            return GetAll().Where(e => e.Name.Equals(name)).ToList();
        }

        public List<Equipment> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return GetAll().Where(e => e.SerialNumber.Equals(roomSerialNumber)).ToList();
        }
    }
}