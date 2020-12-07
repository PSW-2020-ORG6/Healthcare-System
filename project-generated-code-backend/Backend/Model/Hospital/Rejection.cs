// File:    Rejection.cs
// Author:  Vladimir
// Created: Monday, May 25, 2020 17:06:42
// Purpose: Definition of Class Rejection

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Hospital
{
    public class Rejection : Entity
    {
        public string Reason { get; set; }
        public Medicine Medicine { get; set; }

        public Rejection(string reason, Medicine medicine) : base(Guid.NewGuid().ToString())
        {
            Reason = reason;
            Medicine = medicine;
        }

        [JsonConstructor]
        public Rejection(String serialNumber, string reason, Medicine medicine) : base(serialNumber)
        {
            Reason = reason;
            Medicine = medicine;
        }

        public override bool Equals(object obj)
        {
            var other = (Rejection) obj;
            if (other == null)
            {
                return false;
            }

            return Reason.Equals(other.Reason) && Medicine.Equals(other.Medicine);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "medicine: " + Medicine + "\nreason: " + Reason;
        }
    }
}