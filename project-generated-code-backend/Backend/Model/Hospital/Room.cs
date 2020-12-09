// File:    Room.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        [ForeignKey("Floor")] public string FloorSerialNumber { get; set; }
        public Floor Floor { get; set; }
        public string BuildingSerialNumber { get; set; } // TODO: get this from Floor
        [ForeignKey("RoomType")] public string RoomTypeSerialNumber { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual List<Equipment> Equipment { get; set; }
        public virtual List<Bed> Beds { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }

        public string Style { get; set; }

        public Room() : base()
        {
        }

        [JsonConstructor]
        public Room(String serialNumber, int id, RoomType roomType) : base(serialNumber)
        {
            Id = id;
            RoomType = roomType;
            Equipment = new List<Equipment>();
            Beds = new List<Bed>();
        }

        public Room(int id, RoomType roomType) : base()
        {
            Id = id;
            RoomType = roomType;
            Equipment = new List<Equipment>();
            Beds = new List<Bed>();
        }

        public void AddEquipment(Equipment newEquipment)
        {
            if (newEquipment == null)
                return;
            Equipment ??= new List<Equipment>();
            if (!Equipment.Contains(newEquipment))
                Equipment.Add(newEquipment);
        }

        public void RemoveEquipment(Equipment oldEquipment)
        {
            if (oldEquipment == null)
                return;
            if (Equipment == null) return;
            if (Equipment.Contains(oldEquipment))
                Equipment.Remove(oldEquipment);
        }

        public void RemoveAllEquipment()
        {
            if (Equipment != null)
                Equipment.Clear();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Room other))
            {
                return false;
            }

            return Id.Equals(other.Id) && RoomType.Equals(other.RoomType);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool ContainsAllEquipment(List<Equipment> requiredEquipment)
        {
            return requiredEquipment.All(e => Equipment.Contains(e));
        }
    }
}