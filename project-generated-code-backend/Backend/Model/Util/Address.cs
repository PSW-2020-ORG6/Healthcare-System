// File:    Address.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Address

using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Dto;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Util
{
    public class Address : Entity
    {
        public string Street { get; set; }
        [ForeignKey("City")] public string CitySerialNumber { get; set; }
        public City City { get; set; }

        public Address() : base()
        {
        }

        public Address(string street) : base()
        {
            Street = street;
        }

        [JsonConstructor]
        public Address(string serialNumber, string street) : base(serialNumber)
        {
            Street = street;
        }

        public Address(AddressDto addressDto)
        {
            Street = addressDto.Street;
        }

        public override string ToString()
        {
            return Street;
        }

        public override bool Equals(object obj)
        {
            return obj is Address other && Street.Equals(other.Street);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}