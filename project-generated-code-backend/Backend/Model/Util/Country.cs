// File:    Country.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Country

using System;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Util
{
    public class Country : Entity
    {
        public string Name { get; set; }

        public Country(string name) : base()
        {
            Name = name;
        }

        [JsonConstructor]
        public Country(String serialNumber, string name) : base(serialNumber)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Country other))
            {
                return false;
            }

            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}