using HealthClinicBackend.Backend.Model.Util;
using System;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Position : Entity
    {
        public int _row;
        public int _column;
        public int _rowSpan;
        public int _columnSpan;
        public int Row => _row;
        public int Column => _column;
        public int RowSpan => _rowSpan;
        public int ColumnSpan => _columnSpan;

        public Position()
        {
        }


        public Position(string serialNumber, int row, int column, int rowSpan, int columnSpan) : base(serialNumber)
        {
            Validate(row, column, rowSpan, columnSpan);
            _row = row;
            _column = column;
            _rowSpan = rowSpan;
            _columnSpan = columnSpan;
        }

        public Position(int row, int column, int rowSpan, int columnSpan)
        {
            _row = row;
            _column = column;
            _rowSpan = rowSpan;
            _columnSpan = columnSpan;
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

        public Position ExpandField(Position oldPosition, int height, int width)
        {
            int rowSpan = oldPosition.RowSpan + height;
            int columnSpan = oldPosition.ColumnSpan + width;

            ValidateElementOfField(rowSpan);
            ValidateElementOfField(columnSpan);

            return new Position(
                oldPosition.Row,
                oldPosition.Column,
                rowSpan, columnSpan);
        }

        public Position ReduceField(Position oldPosition, int height, int width)
        {
            int rowSpan = oldPosition.RowSpan - height;
            int columnSpan = oldPosition.ColumnSpan - width;

            ValidateElementOfField(rowSpan);
            ValidateElementOfField(columnSpan);

            return new Position(
              oldPosition.Row,
              oldPosition.Column,
              rowSpan, columnSpan);
        }

        public Position MoveField(Position oldPosition, int row, int column)
        {
            ValidateElementOfField(row);
            ValidateElementOfField(column);
            return new Position(
                row, column,
                oldPosition.RowSpan,
                oldPosition.ColumnSpan);
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
