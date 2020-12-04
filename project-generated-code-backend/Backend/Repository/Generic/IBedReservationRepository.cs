using Model.Accounts;
using Model.Hospital;

namespace Backend.Repository
{
    public interface IBedReservationRepository : IGenericRepository<BedReservation>
    {
        BedReservation GetBedReservationByPatient(Patient patient);
    }
}
