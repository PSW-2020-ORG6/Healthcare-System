// File:    Medicine.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Medicine

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Hospital
{
    public class Medicine : Entity
    {
        private String copyrightName;
        private String genericName;
        private MedicineManufacturer medicineManufacturer;
        private MedicineType medicineType;
        private String medicineManufacturerSerialNumber;
        private String medicineTypeSerialNumber;

        public string CopyrightName { get => copyrightName; set => copyrightName = value; }
        public string GenericName { get => genericName; set => genericName = value; }
        public virtual MedicineManufacturer MedicineManufacturer { get => medicineManufacturer; set => medicineManufacturer = value; }
        public virtual MedicineType MedicineType { get => medicineType; set => medicineType = value; }
        public Medicine() : base(Guid.NewGuid().ToString())
        {
        }
        public string MedicineManufacturerSerialNumber { get => medicineManufacturerSerialNumber; set => medicineManufacturerSerialNumber = value; }
        public string MedicineTypeSerialNumber { get => medicineTypeSerialNumber; set => medicineTypeSerialNumber = value; }

        public Medicine(string copyrightName, string genericName, MedicineManufacturer medicineManufacturer, MedicineType medicineType) : base(Guid.NewGuid().ToString())
        {
            this.copyrightName = copyrightName;
            this.genericName = genericName;
            this.medicineManufacturer = medicineManufacturer;
            this.medicineType = medicineType;
        }

        public Medicine(string serialNumber, string copyrightName, string genericName, string medicineManufacturer, string medicineType) : base(serialNumber)
        {
            this.copyrightName = copyrightName;
            this.genericName = genericName;
            this.medicineManufacturer.Name = medicineManufacturer;
            this.medicineType.Type = medicineType;
        }

        [JsonConstructor]
        public Medicine(String serialNumber, string copyrightName, string genericName, MedicineManufacturer medicineManufacturer, MedicineType medicineType) : base(serialNumber)
        {
            this.copyrightName = copyrightName;
            this.genericName = genericName;
            this.medicineManufacturer = medicineManufacturer;
            this.medicineType = medicineType;
        }

        public override bool Equals(object obj)
        {
            Medicine other = obj as Medicine;

            if (other == null)
            {
                return false;
            }

            return this.CopyrightName.Equals(other.CopyrightName);
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