using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IBedReservationRepository : IGenericRepository<BedReservation>
    {
        BedReservation GetBedReservationByPatient(Patient patient);
    }
}
