using Model.Accounts;
using Model.Hospital;

namespace Backend.Repository
{
    public interface BedReservationRepository : GenericRepository<BedReservation>
    {
        BedReservation GetBedReservationByPatient(Patient patient);
    }
}
