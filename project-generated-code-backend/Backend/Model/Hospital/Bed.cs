// File:    Bed.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Bed

using Newtonsoft.Json;
using System;
using Backend.Model.Util;

namespace Model.Hospital
{
    public class Bed : Entity
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string BuildingSerialNumber { get; set; }
        public string FloorSerialNumber { get; set; }
        public string RoomSerialNumber { get; set; }
        public string PatientID { get; set; }

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