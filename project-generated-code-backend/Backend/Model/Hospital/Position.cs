using HealthClinicBackend.Backend.Model.Util;
using System;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Position : Entity
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }

        public Position()
        {
        }


        public Position(string serialNumber, int row, int column, int rowSpan, int columnSpan) : base(serialNumber)
        {
            Validate(row, column, rowSpan, columnSpan);
            Row = row;
            Column = column;
            RowSpan = rowSpan;
            ColumnSpan = columnSpan;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   SerialNumber == position.SerialNumber &&
                   Row == position.Row &&
                   Column == position.Column &&
                   RowSpan == position.RowSpan &&
                   ColumnSpan == position.ColumnSpan;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Row.ToString() + " - " + RowSpan.ToString()
                 + " - " + Column.ToString() + " - " + ColumnSpan.ToString();
        }

        public void ExpandField(Position oldPosition, int height, int width)
        {
            int rowSpan = oldPosition.RowSpan + height;
            int columnSpan = oldPosition.ColumnSpan + width;

            ValidateElementOfField(rowSpan);
            ValidateElementOfField(columnSpan);

            oldPosition.RowSpan = rowSpan;
            oldPosition.ColumnSpan = columnSpan;
        }

        public void ReduceField(Position oldPosition, int height, int width)
        {
            int rowSpan = oldPosition.RowSpan - height;
            int columnSpan = oldPosition.ColumnSpan - width;

            ValidateElementOfField(rowSpan);
            ValidateElementOfField(columnSpan);

            oldPosition.RowSpan = rowSpan;
            oldPosition.ColumnSpan = columnSpan;
        }

        public void MoveField(Position oldPosition, int row, int column)
        {
            ValidateElementOfField(row);
            ValidateElementOfField(column);
            oldPosition.Row = row;
            oldPosition.Column = column;
        }

        private void Validate(int row, int column, int rowSpan, int columnSpan)
        {
            ValidateElementOfField(row);
            ValidateElementOfField(column);
            ValidateElementOfField(rowSpan);
            ValidateElementOfField(columnSpan);
        }

        private void ValidateElementOfField(int elementOfField)
        {
            if (elementOfField == 0) throw new Exception("The field is required!");
            else if (elementOfField < 0) throw new Exception("The field can't be negative.");
            else if (elementOfField > 1000) throw new Exception("The field is too big of a size.");
        }
    }
}
