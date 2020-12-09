// File:    ProcedureType.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class ProcedureType

using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Schedule
{
    public class ProcedureType : Entity
    {
        public virtual Specialization Specialization { get; set; }
        public string Name { get; set; }
        public int EstimatedTimeInMinutes { get; set; }
        public List<Equipment> RequiredEquipment { get; set; }

        public ProcedureType() : base()
        {
        }

        public ProcedureType(string name, int estimatedTimeInMinutes, Specialization specialization) : base()
        {
            Name = name;
            Specialization = specialization;
            EstimatedTimeInMinutes = estimatedTimeInMinutes;
            RequiredEquipment = new List<Equipment>();
        }

        [JsonConstructor]
        public ProcedureType(String serialNumber, int estimatedTimeInMinutes, string name,
            Specialization specialization) : base(serialNumber)
        {
            Name = name;
            Specialization = specialization;
            EstimatedTimeInMinutes = estimatedTimeInMinutes;
            RequiredEquipment = new List<Equipment>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ProcedureType other))
            {
                return false;
            }

            if (RequiredEquipment.Count != other.RequiredEquipment.Count)
            {
                return false;
            }

            if (RequiredEquipment.Any(e => !other.RequiredEquipment.Contains(e)))
            {
                return false;
            }

            return Specialization.Equals(other.Specialization) && Name.Equals(other.Name);
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