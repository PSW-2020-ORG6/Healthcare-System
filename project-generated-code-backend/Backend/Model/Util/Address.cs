// File:    Address.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Address

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Util
{
    public class Address : Entity
    {
        public string Street { get; set; }

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