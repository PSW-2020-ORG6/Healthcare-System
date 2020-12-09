// File:    MedicineManufacturer.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class MedicineManufacturer

using System;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class MedicineManufacturer : Entity
    {
        public virtual string Name { get; set; }

        public MedicineManufacturer() : base()
        {
        }

        public MedicineManufacturer(string name) : base()
        {
            Name = name;
        }

        [JsonConstructor]
        public MedicineManufacturer(String serialNumber, string name) : base(serialNumber)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is MedicineManufacturer other && Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}