using MicroServiceAccount.Backend.Model.Util;
using System;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Model.Hospital
{
    public class Building : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private int _row;
        public int Row
        {
            get { return _row; }
            private set { _row = value; }
        }

        private int _column;
        public int Column
        {
            get { return _column; }
            private set { _column = value; }
        }

        private string _style;
        public string Style
        {
            get { return _style; }
            set { _style = value; }
        }


        private List<Floor> _floors;
        public List<Floor> Floors
        {
            get { return _floors; }
            set { _floors = value; }
        }

        public Building() : base()
        {
        }

        public Building(string name, string color) : base()
        {
            ValidateElementOfBuilding(name);
            ValidateElementOfBuilding(color);

            _name = name;
            _color = color;
            _floors = new List<Floor>();
        }

        public Building(string serialNumber, string name, string color) : base(serialNumber)
        {
            ValidateSerialNbr(serialNumber);
            ValidateElementOfBuilding(name);
            ValidateElementOfBuilding(color);

            _name = name;
            _color = color;
            _floors = new List<Floor>();
        }

        public Building(string name, string color, int row, int column, string style) : this(name, color)
        {
            ValidateElementOfBuilding(name);
            ValidateElementOfBuilding(color);
            ValidateFieldElement(row);
            ValidateFieldElement(column);
            ValidateElementOfBuilding(style);

            _name = name;
            _color = color;
            _row = row;
            _column = column;
            _style = style;
            _floors = new List<Floor>();
        }

        public Building(string serialNumber, string name, string color, int row, int column, string style) : this(serialNumber, name, color)
        {
            ValidateSerialNbr(serialNumber);
            ValidateElementOfBuilding(name);
            ValidateElementOfBuilding(color);
            ValidateFieldElement(row);
            ValidateFieldElement(column);
            ValidateElementOfBuilding(style);

            _name = name;
            _color = color;
            _row = row;
            _column = column;
            _style = style;
            _floors = new List<Floor>();
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

        private void ValidateElementOfBuilding(string elementOfBuilding)
        {
            if (string.IsNullOrEmpty(elementOfBuilding)) throw new Exception("The element of the building is required!");
            else if (elementOfBuilding.Length < 3) throw new Exception("The element of the building is too short.");
            else if (elementOfBuilding.Length > 30) throw new Exception("The element of the building is too long.");
        }

        private void ValidateSerialNbr(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber)) throw new Exception("Serial number is required!");
            else if (serialNumber.Length < 3) throw new Exception("Serial number is too short.");
            else if (serialNumber.Length > 30) throw new Exception("Serial number is too long.");
        }

        private void ValidateFieldElement(int fieldElement)
        {
            if (fieldElement > 1000) throw new Exception("The field element is too big of a size.");
            else if (fieldElement < 0) throw new Exception("The field element can't be negative.");
        }

        public Building(Building building) : base(building.SerialNumber)
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