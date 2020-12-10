using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.PharmacySupport
{
    public class MedicineReport: Entity
    {
        public string Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual List<MedicineDosagePharmacy> Dosage { get; set; }  

        public MedicineReport() {
            Dosage = new List<MedicineDosagePharmacy>();
        }

    }
}
