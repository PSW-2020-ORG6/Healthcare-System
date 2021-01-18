// File:    ProcedureType.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class ProcedureType

using System;
using System.Collections.Generic;
using System.Linq;
using MicroServiceAccount.Backend.Model;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAccount.Backend.Model.Util;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using MicroServiceAppointment.Backend.Dto;

namespace MicroServiceAppointment.Backend.Model
{
    public class ProcedureType : Entity
    {
        [ForeignKey("Specialization")] public string SpecializationSerialNumber { get; set; }
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

        public ProcedureType(ProcedureTypeDTO procedureTypeDTO)
        {
            this.Specialization = new Specialization(procedureTypeDTO.Specialization);
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