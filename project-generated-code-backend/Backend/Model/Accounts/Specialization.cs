// File:    Specialization.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Specialization

using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Accounts
{
    public class Specialization : Entity
    {
        public string Name { get; set; }

        public Specialization() : base(Guid.NewGuid().ToString())
        {
        }

        public Specialization(string name) : base(Guid.NewGuid().ToString())
        {
            Name = name;
        }

        [JsonConstructor]
        public Specialization(String serialNumber, string name) : base(serialNumber)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override bool Equals(object obj)
        {
            Specialization other = obj as Specialization;
            return other != null && Name.Equals(other.Name);
        }
    }
}