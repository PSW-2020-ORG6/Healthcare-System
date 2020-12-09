// File:    MedicineType.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class MedicineType

using System;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class MedicineType : Entity
    {
        public string Type { get; set; }

        public MedicineType() : base()
        {
        }

        public MedicineType(string type) : base()
        {
            Type = type;
        }

        [JsonConstructor]
        public MedicineType(String serialNumber, string type) : base(serialNumber)
        {
            Type = type;
        }

        public override bool Equals(object obj)
        {
            return obj is MedicineType other && Type.Equals(other.Type);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Type;
        }
    }
}