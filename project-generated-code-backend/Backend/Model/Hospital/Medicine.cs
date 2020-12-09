// File:    Medicine.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Medicine

using System;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Medicine : Entity
    {
        public string CopyrightName { get; set; }
        public string GenericName { get; set; }
        public bool IsApproved { get; set; }

        [ForeignKey("MedicineManufacturer")] public string MedicineManufacturerSerialNumber { get; set; }
        public virtual MedicineManufacturer MedicineManufacturer { get; set; }

        [ForeignKey("MedicineType")] public string MedicineTypeSerialNumber { get; set; }
        public virtual MedicineType MedicineType { get; set; }

        public Medicine() : base()
        {
        }

        public Medicine(string copyrightName, string genericName, MedicineManufacturer medicineManufacturer,
            MedicineType medicineType) : base()
        {
            CopyrightName = copyrightName;
            GenericName = genericName;
            MedicineManufacturer = medicineManufacturer;
            MedicineType = medicineType;
        }

        public Medicine(string serialNumber, string copyrightName, string genericName, string medicineManufacturer,
            string medicineType) : base(serialNumber)
        {
            CopyrightName = copyrightName;
            GenericName = genericName;
            (MedicineManufacturer ?? new MedicineManufacturer()).Name = medicineManufacturer;
            (MedicineType ?? new MedicineType()).Type = medicineType;
        }

        [JsonConstructor]
        public Medicine(String serialNumber, string copyrightName, string genericName,
            MedicineManufacturer medicineManufacturer, MedicineType medicineType) : base(serialNumber)
        {
            CopyrightName = copyrightName;
            GenericName = genericName;
            MedicineManufacturer = medicineManufacturer;
            MedicineType = medicineType;
        }

        public override bool Equals(object obj)
        {
            return obj is Medicine other && this.CopyrightName.Equals(other.CopyrightName);
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