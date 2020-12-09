using Backend.Repository;
using Model.Accounts;
using Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class BedReservationDatabaseSql: GenericDatabaseSql<BedReservation>, IBedReservationRepository
    {
        public BedReservation GetBedReservationByPatient(Patient patient)
        {
            throw new System.NotImplementedException();
        }
    }
}