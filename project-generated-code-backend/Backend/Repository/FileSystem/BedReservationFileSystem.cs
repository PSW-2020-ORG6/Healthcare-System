using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class BedReservationFileSystem : GenericFileSystem<BedReservation>, IBedReservationRepository
    {
        public BedReservationFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/approved_medicine.txt";
            path = @"./../../data/bedreservations.txt";
        }

        public BedReservation GetBedReservationByPatient(Patient patient)
        {
            List<BedReservation> bedReservations = GetAll();
            foreach (BedReservation bedReservation in bedReservations)
            {
                if (patient.Equals(bedReservation.Patient))
                {
                    return bedReservation;
                }
            }
            return null;
        }

        public override BedReservation Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<BedReservation>(objectStringFormat);
        }
    }
}
