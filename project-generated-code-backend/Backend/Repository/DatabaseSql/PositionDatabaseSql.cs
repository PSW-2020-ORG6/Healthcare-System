using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PositionDatabaseSql : GenericDatabaseSql<Position>, IPositionRepository
    {
        public override List<Position> GetAll()
        {
            return dbContext.Position.ToList();
        }

        public override Position GetById(string id)
        {
            return dbContext.Position.Find(id);
        }

        public override void Save(Position newEntity)
        {
            dbContext.Position.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Position updateEntity)
        {
            dbContext.Position.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var position = GetById(id);
            if (position == null) return;
            dbContext.Position.Remove(position);
            dbContext.SaveChanges();
        }
    }
}