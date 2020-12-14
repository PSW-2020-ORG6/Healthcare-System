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
        //public string Name { get; set; }
        //public string Id { get; set; }
        //public string RoomId { get; set; }
        //[ForeignKey("Building")] public string BuildingSerialNumber { get; set; }
        //[ForeignKey("Floor")] public string FloorSerialNumber { get; set; }
        //[ForeignKey("Room")] public string RoomSerialNumber { get; set; }
        [ForeignKey("Patient")] public string PatientSerialNumber { get; set; }
        public Patient Patient { get; set; }

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