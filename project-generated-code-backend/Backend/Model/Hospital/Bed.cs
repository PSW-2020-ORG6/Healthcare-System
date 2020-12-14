// File:    Bed.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Bed

using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Bed : Equipment
    {
        [ForeignKey("Patient")] public string PatientSerialNumber { get; set; }
        public Patient Patient { get; set; }


        private bool occupied;

        public bool IsOccupied 
        { 
            get
            {
                if (PatientSerialNumber == null) return false;
                else return true;
            }
        }

        public Bed()
        {
        }

        public Bed(string name, string id) : base()
        {
            Name = name;
            Id = id;
        }

        [JsonConstructor]
        public Bed(String serialNumber, string name, string id) : base(serialNumber)
        {
            Name = name;
            Id = id;
        }
    }
}