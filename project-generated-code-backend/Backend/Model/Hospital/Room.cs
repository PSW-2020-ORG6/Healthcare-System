using HealthClinicBackend.Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Room : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _floorSerialNumber;
        [ForeignKey("Floor")]
        public string FloorSerialNumber
        {
            get { return _floorSerialNumber; }
            private set { _floorSerialNumber = value; }
        }

        private string _roomTypeSerialNumber;
        [ForeignKey("RoomType")]
        public string RoomTypeSerialNumber
        {
            get { return _roomTypeSerialNumber; }
            private set { _roomTypeSerialNumber = value; }
        }

        private Position _position;
        public Position Position
        {
            get { return _position; }
            private set { _position = value; }
        }

        private RoomType _roomType;
        public virtual RoomType RoomType
        {
            get { return _roomType; }
            private set { _roomType = value; }
        }

        private List<Equipment> _equipment;
        public virtual List<Equipment> Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }

        private List<Bed> _beds;
        public virtual List<Bed> Beds
        {
            get { return _beds; }
            set { _beds = value; }
        }

        private List<Medicine> _medicines;
        public virtual List<Medicine> Medicines
        {
            get { return _medicines; }
            set { _medicines = value; }
        }

        private string _style;
        public string Style
        {
            get { return _style; }
            private set { _style = value; }
        }

        private int _bottomDoorVisible;
        public int BottomDoorVisible
        {
            get { return _bottomDoorVisible; }
            set { _bottomDoorVisible = value; }
        }

        private int _rightDoorVisible;
        public int RightDoorVisible
        {
            get { return _rightDoorVisible; }
            set { _rightDoorVisible = value; }
        }

        private int _leftDoorVisible;
        public int LeftDoorVisible
        {
            get { return _leftDoorVisible; }
            set { _leftDoorVisible = value; }
        }

        private int _topDoorVisible;
        public int TopDoorVisible
        {
            get { return _topDoorVisible; }
            set { _topDoorVisible = value; }
        }

        public Room() : base()
        {
        }

        [JsonConstructor]
        public Room(String serialNumber, int id, RoomType roomType) : base(serialNumber)
        {
            ValidateSerialNbr(serialNumber);
            ValidateId(id);

            _id = id;
            _roomType = roomType;
        }

        public Room(string serialNumber, string name, int id, string floorSerialNumber,
            string roomTypeSerialNumber, Position position, string style)
          : base(serialNumber)
        {
            ValidateSerialNbr(serialNumber);
            ValidateElementOfRoom(name);
            ValidateId(id);
            ValidateSerialNbr(floorSerialNumber);
            ValidateSerialNbr(roomTypeSerialNumber);
            ValidateElementOfRoom(style);

            _name = name;
            _id = id;
            _floorSerialNumber = floorSerialNumber;
            _roomTypeSerialNumber = roomTypeSerialNumber;
            _position = position;
            _style = style;
        }

        public Room(string serialNumber, string name, int id, string floorSerialNumber,
            string roomTypeSerialNumber, string style)
          : base(serialNumber)
        {
            ValidateSerialNbr(serialNumber);
            ValidateElementOfRoom(name);
            ValidateId(id);
            ValidateSerialNbr(floorSerialNumber);
            ValidateSerialNbr(roomTypeSerialNumber);
            ValidateElementOfRoom(style);

            _name = name;
            _id = id;
            _floorSerialNumber = floorSerialNumber;
            _roomTypeSerialNumber = roomTypeSerialNumber;
            _style = style;
        }

        public Room(string serialNumber, string name, int id, string floorSerialNumber,
           string roomTypeSerialNumber, string style, int bottomDoorVisible,
           int rightDoorVisible, int leftDoorVisible, int topDoorVisible)
         : base(serialNumber)
        {
            ValidateSerialNbr(serialNumber);
            ValidateElementOfRoom(name);
            ValidateId(id);
            ValidateSerialNbr(floorSerialNumber);
            ValidateSerialNbr(roomTypeSerialNumber);
            ValidateElementOfRoom(style);
            ValidateDoor(bottomDoorVisible);
            ValidateDoor(rightDoorVisible);
            ValidateDoor(leftDoorVisible);
            ValidateDoor(topDoorVisible);

            _name = name;
            _id = id;
            _floorSerialNumber = floorSerialNumber;
            _roomTypeSerialNumber = roomTypeSerialNumber;
            _style = style;
            _bottomDoorVisible = bottomDoorVisible;
            _rightDoorVisible = rightDoorVisible;
            _leftDoorVisible = leftDoorVisible;
            _topDoorVisible = topDoorVisible;
        }

        public Room(string serialNumber, string name, int id, string floorSerialNumber,
           string roomTypeSerialNumber, Position position, string style, int bottomDoorVisible,
           int rightDoorVisible, int leftDoorVisible, int topDoorVisible)
         : base(serialNumber)
        {
            ValidateSerialNbr(serialNumber);
            ValidateElementOfRoom(name);
            ValidateId(id);
            ValidateSerialNbr(floorSerialNumber);
            ValidateSerialNbr(roomTypeSerialNumber);
            ValidateElementOfRoom(style);
            ValidateDoor(bottomDoorVisible);
            ValidateDoor(rightDoorVisible);
            ValidateDoor(leftDoorVisible);
            ValidateDoor(topDoorVisible);

            _name = name;
            _id = id;
            _floorSerialNumber = floorSerialNumber;
            _roomTypeSerialNumber = roomTypeSerialNumber;
            _position = position;
            _style = style;
            _bottomDoorVisible = bottomDoorVisible;
            _rightDoorVisible = rightDoorVisible;
            _leftDoorVisible = leftDoorVisible;
            _topDoorVisible = topDoorVisible;
        }

        public Room(int id, RoomType roomType) : base()
        {
            ValidateId(id);

            _id = id;
            _roomType = roomType;
        }

        public Room(List<Bed> beds, RoomType roomType, List<Equipment> equipment, List<Medicine> medicines)
        {
            _beds = beds;
            _roomType = roomType;
            _equipment = equipment;
            _medicines = medicines;
        }

        public Room(string name, int id, string floorSerialNumber,
           string roomTypeSerialNumber, Position position, string style)
        {
            ValidateElementOfRoom(name);
            ValidateId(id);
            ValidateSerialNbr(floorSerialNumber);
            ValidateSerialNbr(roomTypeSerialNumber);
            ValidateElementOfRoom(style);

            _name = name;
            _id = id;
            _floorSerialNumber = floorSerialNumber;
            _roomTypeSerialNumber = roomTypeSerialNumber;
            _position = position;
            _style = style;
            _beds = new List<Bed>();
            _equipment = new List<Equipment>();
            _medicines = new List<Medicine>();
        }

        public Room(string name, int id, string floorSerialNumber,
           string roomTypeSerialNumber, Position position, string style,
           List<Equipment> equipment, List<Medicine> medicines, RoomType roomType)
        {
            ValidateElementOfRoom(name);
            ValidateId(id);
            ValidateSerialNbr(floorSerialNumber);
            ValidateSerialNbr(roomTypeSerialNumber);
            ValidateElementOfRoom(style);

            _name = name;
            _id = id;
            _floorSerialNumber = floorSerialNumber;
            _roomTypeSerialNumber = roomTypeSerialNumber;
            _position = position;
            _style = style;
            _beds = new List<Bed>();
            _equipment = equipment;
            _medicines = medicines;
            _roomType = roomType;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Room other))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(SerialNumber);
            hash.Add(Name);
            hash.Add(Id);
            hash.Add(FloorSerialNumber);
            hash.Add(RoomTypeSerialNumber);
            hash.Add(Position);
            hash.Add(RoomType);
            hash.Add(Equipment);
            hash.Add(Beds);
            hash.Add(Medicines);
            hash.Add(Style);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return SerialNumber + " - " + Name + " - " + Id + " - " + FloorSerialNumber
                + " - " + RoomTypeSerialNumber + " - " + Position;
        }

        public bool ContainsAllEquipment(List<Equipment> requiredEquipment)
        {
            return requiredEquipment.All(e => Equipment.Contains(e));
        }
        public Room(RoomDTO room)
        {
            Name = room.Name;
        }

        public void AddEquipment(Equipment newEquipment)
        {
            if (newEquipment == null)
                return;
            _equipment ??= new List<Equipment>();
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

        private void ValidateSerialNbr(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber)) throw new Exception("Serial number is required!");
            //else if (serialNumber.Length < 3) throw new Exception("Serial number is too short.");
            //else if (serialNumber.Length > 30) throw new Exception("Serial number is too long.");
        }

        private void ValidateId(int id)
        {
            if (id <= 0) throw new Exception("Id is not valid!");
        }

        private void ValidateElementOfRoom(string elementOfRoom)
        {
            if (string.IsNullOrEmpty(elementOfRoom)) throw new Exception("The element of the room is required!");
            else if (elementOfRoom.Length < 3) throw new Exception("The element of the room is too short.");
            else if (elementOfRoom.Length > 30) throw new Exception("The element of the room is too long.");
        }

        private void ValidateDoor(int door)
        {
            if (door > 4) throw new Exception("There doesn't exist this type of door.");
            else if (door < 0) throw new Exception("There doesn't exist this type of door.");
        }

       
    }
}