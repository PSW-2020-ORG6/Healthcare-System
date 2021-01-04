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
            return DbContext.Position.ToList();
        }

        public override Position GetById(string id)
        {
            return DbContext.Position.Find(id);
        }

        public override void Save(Position newEntity)
        {
            DbContext.Position.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Position updateEntity)
        {
            DbContext.Position.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var position = GetById(id);
            if (position == null) return;
            DbContext.Position.Remove(position);
            DbContext.SaveChanges();
        }
    }
}