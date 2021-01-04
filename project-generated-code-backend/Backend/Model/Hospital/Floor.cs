using HealthClinicBackend.Backend.Model.Util;
using System;
using HealthClinicBackend.Backend.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Floor : Entity
    {
        public string _name;
        public string _buildingSerialNumber;
        public List<Room> _rooms;

        public string Name => _name;
        [ForeignKey("Building")] public string BuildingSerialNumber => _buildingSerialNumber;
        public List<Room> Rooms => _rooms;

        public Floor() : base()
        {
        }

        public Floor(string serialNumber, string name, string buildingSerialNumber) : base(serialNumber)
        {
            ValidateElementOfFloor(name);
            ValidateElementOfFloor(serialNumber);

            _name = name;
            _buildingSerialNumber = buildingSerialNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is Floor floor &&
                   SerialNumber == floor.SerialNumber &&
                   Name == floor.Name &&
                   BuildingSerialNumber == floor.BuildingSerialNumber &&
                   EqualityComparer<List<Room>>.Default.Equals(Rooms, floor.Rooms);
        }

        public static bool operator ==(Floor firstFloor, Floor secondFloor)
        {
            if (firstFloor is null)
                return secondFloor is null;

            return firstFloor.Equals(secondFloor);
        }

        public static bool operator !=(Floor firstFloor, Floor secondFloor)
        {
            if (firstFloor is null)
            {
                throw new ArgumentNullException(nameof(firstFloor));
            }

            if (secondFloor is null)
            {
                throw new ArgumentNullException(nameof(secondFloor));
            }

            return !(firstFloor == secondFloor);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SerialNumber, Name, BuildingSerialNumber, Rooms);
        }

        public override string ToString()
        {
            var text =  SerialNumber + " - " + Name + " - " + BuildingSerialNumber + " - Rooms: ";
            foreach(Room r in Rooms)
                text += "   " + r.Name;
            return text;
        }

        private void ValidateElementOfFloor(string elementOfFloor)
        {
            if (string.IsNullOrEmpty(elementOfFloor)) throw new Exception("All elements of the floor are required!");
            else if (elementOfFloor.Length < 3) throw new Exception("Element of the floor is too short.");
            else if (elementOfFloor.Length > 20) throw new Exception("Element of the floor is too long.");
        }

        public Floor(Building building, int nameNumber) : base()
        {
            Name = Constants.FloorNames[nameNumber];
            BuildingSerialNumber = building.SerialNumber;
            Rooms = new List<Room>();
        }
    }
}