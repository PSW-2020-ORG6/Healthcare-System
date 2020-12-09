using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using Model.Accounts;

namespace Backend.Repository
{
    public interface IBedReservationRepository : IGenericRepository<BedReservation>
    {
        BedReservation GetBedReservationByPatient(Patient patient);
    }
}
