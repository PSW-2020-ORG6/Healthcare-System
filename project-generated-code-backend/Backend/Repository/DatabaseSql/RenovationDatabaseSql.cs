using System.Collections.Generic;
using Backend.Repository;
using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RenovationDatabaseSql: GenericDatabaseSql<Renovation>, IRenovationRepository
    {
        public override List<Renovation> GetAll()
        {
            // TODO: add renovation to db context
            return base.GetAll();
        }

        public List<Renovation> GetRenovationsByRoom(Room room)
        {
            throw new System.NotImplementedException();
        }
    }
}