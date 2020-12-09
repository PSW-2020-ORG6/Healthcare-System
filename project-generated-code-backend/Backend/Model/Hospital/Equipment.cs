// File:    Equipment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Equipment

using System;
using System.ComponentModel.DataAnnotations.Schema;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Equipment : Entity
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string RoomId { get; set; }
        [ForeignKey("Building")] public string BuildingSerialNumber { get; set; }
        public Building Building { get; set; }
        [ForeignKey("Floor")] public string FloorSerialNumber { get; set; }
        public Floor Floor { get; set; }
        [ForeignKey("Room")] public string RoomSerialNumber { get; set; }
        public Room Room { get; set; }

        public Equipment() : base()
        {
        }

        public Equipment(string name, string id) : base()
        {
            Name = name;
            Id = id;
        }

        [JsonConstructor]
        public Equipment(String serialNumber, string name, string id) : base(serialNumber)
        {
            Name = name;
            Id = id;
        }

        public Equipment(Equipment equipment) : base(equipment.SerialNumber)
        {
            Name = equipment.Name;
            Id = equipment.Id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Equipment other))
            {
                return false;
            }

            return Name.Equals(other.Name) && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "name: " + Name + "\nid: " + Id;
        }
    }
}