using HealthClinicBackend.Backend.Model.Util;
using System;
using HealthClinicBackend.Backend.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Floor : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        private string _buildingSerialNumber;
        [ForeignKey("Building")]
        public string BuildingSerialNumber
        {
            get { return _buildingSerialNumber; }
            private set { _buildingSerialNumber = value; }
        }

        private List<Room> _rooms;
        public List<Room> Rooms
        {
            get { return _rooms; }
            private set { _rooms = value; }
        }

        public Floor() : base()
        {
        }

        public Floor(string serialNumber, string name, string buildingSerialNumber) : base(serialNumber)
        {
            Validate(serialNumber, name, buildingSerialNumber);

            _name = name;
            _buildingSerialNumber = buildingSerialNumber;
            _rooms = new List<Room>();
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
            var text = SerialNumber + " - " + Name + " - " + BuildingSerialNumber + " - Rooms: ";
            foreach (Room r in Rooms)
                text += "   " + r.Name;
            return text;
        }

        private void Validate(string serialNumber, string name, string buildingSerialNumber)
        {
            ValidateElementOfFloor(serialNumber);
            ValidateElementOfFloor(name);
            ValidateElementOfFloor(buildingSerialNumber);
        }

        private void ValidateElementOfFloor(string elementOfFloor)
        {
            if (string.IsNullOrEmpty(elementOfFloor)) throw new Exception("All elements of the floor are required!");
            else if (elementOfFloor.Length < 3) throw new Exception("Element of the floor is too short.");
            else if (elementOfFloor.Length > 30) throw new Exception("Element of the floor is too long.");
        }

        public Floor(Building building, int nameNumber) : base()
        {
            Name = Constants.FloorNames[nameNumber];
            BuildingSerialNumber = building.SerialNumber;
            Rooms = new List<Room>();
        }
    }
}