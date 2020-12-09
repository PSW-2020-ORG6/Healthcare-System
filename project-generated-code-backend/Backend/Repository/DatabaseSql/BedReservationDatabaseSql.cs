using Backend.Repository;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using Model.Accounts;

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