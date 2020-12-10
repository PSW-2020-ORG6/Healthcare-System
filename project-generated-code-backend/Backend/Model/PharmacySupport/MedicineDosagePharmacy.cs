using System.ComponentModel.DataAnnotations;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.PharmacySupport
{
    public class MedicineDosagePharmacy: Entity
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public int Amount { get; set; }

        public MedicineDosagePharmacy(int id, string medicineName, int amount)
        {
            Id = id;
            MedicineName = medicineName;
            Amount = amount;
        }
    }
}