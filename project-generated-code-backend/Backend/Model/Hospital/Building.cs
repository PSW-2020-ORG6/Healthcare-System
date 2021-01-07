using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Building : Entity
    {
        public string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string _color;
        public string Color
        {
            get { return _color; }
            private set { _color = value; }
        }

        public int _row;
        public int Row
        {
            get { return _row; }
            private set { _row = value; }
        }

        public int _column;
        public int Column
        {
            get { return _column; }
            private set { _column = value; }
        }

        public string _style;
        public string Style
        {
            get { return _style; }
            private set { _style = value; }
        }


        public List<Floor> _floors;
        public List<Floor> Floors
        {
            get { return _floors; }
            private set { _floors = value; }
        }

        public Building() : base()
        {
        }

        public Building(string name, string color) : base()
        {
            Validate(name, color);
            _name = name;
            _color = color;
        }

        public Building(string serialNumber, string name, string color) : base(serialNumber)
        {
            Validate(name, color);
            _name = name;
            _color = color;
        }

        public override bool Equals(object obj)
        {
            return obj is Building building &&
                   SerialNumber == building.SerialNumber &&
                   _row == building._row &&
                   Name == building.Name &&
                   Color == building.Color &&
                   Row == building.Row &&
                   Column == building.Column &&
                   Style == building.Style &&
                   EqualityComparer<List<Floor>>.Default.Equals(Floors, building.Floors);
        }

        public static bool operator ==(Building firstBuilding, Building secondBuilding)
        {
            if (firstBuilding is null)
                return secondBuilding is null;

            return firstBuilding.Equals(secondBuilding);
        }

        public static bool operator !=(Building firstBuilding, Building secondBuilding)
        {
            if (firstBuilding is null)
            {
                throw new ArgumentNullException(nameof(firstBuilding));
            }

            if (secondBuilding is null)
            {
                throw new ArgumentNullException(nameof(secondBuilding));
            }

            return !(firstBuilding == secondBuilding);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SerialNumber, Name, Color, Row, Column, Style, Floors);
        }

        public override string ToString()
        {
            var text = SerialNumber + " - " + Name + " - " + Color + " - "
                + Row + " - " + Column + " - " + Style + " - Floors:";
            foreach (Floor f in Floors)
                text += "   " + f.Name;
            return text;
        }

        private void Validate(string name, string color)
        {
            ValidateElementOfBuilding(name);
            ValidateElementOfBuilding(color);
        }

        private void ValidateElementOfBuilding(string elementOfBuilding)
        {
            if (string.IsNullOrEmpty(elementOfBuilding)) throw new Exception("The element of the building is required!");
            else if (elementOfBuilding.Length < 3) throw new Exception("The element of the building is too short.");
            else if (elementOfBuilding.Length > 20) throw new Exception("The element of the building is too long.");
        }

        public Building(Building building): base(building.SerialNumber)
        {
            _name = building.Name;
            _color = building.Color;
            _row = building.Row;
            _column = building.Column;
            _style = building.Style;
            if (building.Floors != null) _floors = new List<Floor>(building.Floors);
            else _floors = new List<Floor>();
        }
    }
}