// File:    DiagnosticType.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class DiagnosticType

using System;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.MedicalExam
{
    public class DiagnosticType : Entity
    {
        public string Name { get; set; }

        public DiagnosticType(string name) : base()
        {
            Name = name;
        }

        [JsonConstructor]
        public DiagnosticType(String serialNumber, string name) : base(serialNumber)
        {
            Name = name;
        }
        public override bool Equals(object obj)
        {
            return obj is DiagnosticType other && this.Name.Equals(other.Name);
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