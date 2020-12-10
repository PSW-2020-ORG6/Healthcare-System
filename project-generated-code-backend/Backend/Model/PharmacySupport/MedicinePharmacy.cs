using System;
using System.ComponentModel.DataAnnotations;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.PharmacySupport
{
    public class MedicinePharmacy: Entity
    {
        public string MedicineID { get; set; }
        public string Name { get; set; }
        public string MedicineSpecificationID { get; set; }

        public MedicinePharmacy()
        {
        }
        public MedicinePharmacy(string medicineID, string name, string medicineSpecificationID)
        {
            MedicineID = medicineID;
            Name = name;
            MedicineSpecificationID = medicineSpecificationID;
        }
    }
}
