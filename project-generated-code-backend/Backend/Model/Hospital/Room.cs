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
        public string _name;
        public int _id;
        public string _floorSerialNumber;
        public string _roomTypeSerialNumber;
        public string _positionSerialNumber;
        public RoomType _roomType;
        public List<Equipment> _equipment;
        public List<Bed> _beds;
        public List<Medicine> _medinices;
        public string _style;

        public string Name => _name;
        public int Id => _id;
        [ForeignKey("Floor")] public string FloorSerialNumber => _floorSerialNumber;
        [ForeignKey("RoomType")] public string RoomTypeSerialNumber => _roomTypeSerialNumber;
        [ForeignKey("Position")] public string PositionSerialNumber => _positionSerialNumber;
        public virtual RoomType RoomType => _roomType;
        public virtual List<Equipment> Equipment => _equipment;
        public virtual List<Bed> Beds => _beds;
        public virtual List<Medicine> Medinices => _medinices;
        public string Style => _style;

        public int TopDoorVisible { get; set; }
        public int RightDoorVisible { get; set; }
        public int LeftDoorVisible { get; set; }
        public int BottomDoorVisible { get; set; }

        public Room() : base()
        {
        }

        [JsonConstructor]
        public Room(String serialNumber, int id, RoomType roomType) : base(serialNumber)
        {
            ValidateSerialNbr(serialNumber);
            ValidateId(id);
            ValidateRoomType(roomType);

            _id = id;
            _roomType = roomType;
            _equipment = new List<Equipment>();
            _beds = new List<Bed>();
        }

        public Room(string serialNumber, string name, int id, string floorSerialNumber, string roomTypeSerialNumber,
            string positionSerialNumber, string style)
          : base(serialNumber)
        {
            ValidateSerialNbr(serialNumber);
            ValidateElementOfRoom(name);
            ValidateId(id);
            ValidateSerialNbr(floorSerialNumber);
            ValidateSerialNbr(roomTypeSerialNumber);
            ValidateSerialNbr(positionSerialNumber);
            ValidateElementOfRoom(style);

            _name = name;
            _id = id;
            _floorSerialNumber = floorSerialNumber;
            _roomTypeSerialNumber = roomTypeSerialNumber;
            _positionSerialNumber = positionSerialNumber;
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

        public Room(int id, RoomType roomType) : base()
        {
            ValidateId(id);
            ValidateRoomType(roomType);

            _id = id;
            _roomType = roomType;
            _equipment = new List<Equipment>();
            _beds = new List<Bed>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Room other))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }


        public static bool operator ==(Room firstRoom, Room secondRoom)
        {
            if (firstRoom is null)
                return secondRoom is null;

            return firstRoom.Equals(secondRoom);
        }

        public static bool operator !=(Room firstRoom, Room secondRoom)
        {
            if (firstRoom is null)
            {
                throw new ArgumentNullException(nameof(firstRoom));
            }

            if (secondRoom is null)
            {
                throw new ArgumentNullException(nameof(secondRoom));
            }

            return !(firstRoom == secondRoom);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(SerialNumber);
            hash.Add(Name);
            hash.Add(Id);
            hash.Add(FloorSerialNumber);
            hash.Add(RoomTypeSerialNumber);
            hash.Add(PositionSerialNumber);
            hash.Add(RoomType);
            hash.Add(Equipment);
            hash.Add(Beds);
            hash.Add(Medinices);
            hash.Add(Style);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return SerialNumber + " - " + Name + " - " + Id + " - " + FloorSerialNumber
                + " - " + RoomTypeSerialNumber + " - " + PositionSerialNumber;
        }

        public bool ContainsAllEquipment(List<Equipment> requiredEquipment)
        {
            return requiredEquipment.All(e => Equipment.Contains(e));
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
            else if (serialNumber.Length < 3) throw new Exception("Serial number is too short.");
            else if (serialNumber.Length > 20) throw new Exception("Serial number is too long.");
        }

        private void ValidateId(int id)
        {
            if (id <= 0) throw new Exception("Id is not valid!");
        }

        private void ValidateElementOfRoom(string elementOfRoom)
        {
            if (string.IsNullOrEmpty(elementOfRoom)) throw new Exception("The element of the room is required!");
            else if (elementOfRoom.Length < 3) throw new Exception("The element of the room is too short.");
            else if (elementOfRoom.Length > 20) throw new Exception("The element of the room is too long.");
        }

        private void ValidateRoomType(RoomType roomType)
        {
            if (roomType.Name is null) throw new Exception("The name of the room type is required!");
            else if (roomType.Name.Length < 3) throw new Exception("The name of the room type is too short.");
            else if (roomType.Name.Length > 20) throw new Exception("The name of the room type is too long.");
        }
    }
}