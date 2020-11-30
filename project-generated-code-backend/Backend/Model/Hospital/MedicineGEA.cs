using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace health_clinic_class_diagram.Backend.Model.Hospital
{
    public class MedicineGEA : Entity
    {
        private String copyrightName;
        private String genericName;
        private String medicineManufacturerId;
        private String medicineTypeId;

        public string CopyrightName { get => copyrightName; set => copyrightName = value; }
        public string GenericName { get => genericName; set => genericName = value; }

        public string MedicineManufacturerId { get => medicineManufacturerId; set => medicineManufacturerId = value; }

        public string MedicineTypeId { get => medicineTypeId; set => medicineTypeId = value; }

        public MedicineGEA() { }

        public MedicineGEA(string copyrightName, string genericName, string medicineManufacturerId, string medicineTypeId)
        {
            this.copyrightName = copyrightName;
            this.genericName = genericName;
            this.medicineManufacturerId = medicineManufacturerId;
            this.medicineTypeId = medicineTypeId;
        }

        [JsonConstructor]
        public MedicineGEA(String serialNumber, string copyrightName, string genericName, string medicineManufacturerId, string medicineTypeId) : base(serialNumber)
        {
            this.copyrightName = copyrightName;
            this.genericName = genericName;
            this.medicineManufacturerId = medicineManufacturerId;
            this.medicineTypeId = medicineTypeId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return CopyrightName;
        }

    }
}
