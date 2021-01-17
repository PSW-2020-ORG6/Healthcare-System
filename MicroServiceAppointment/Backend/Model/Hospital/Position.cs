using System;

namespace MicroServiceAppointment.Backend.Model.Hospital
{
    public class Position
    {
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

        private int _rowSpan;
        public int RowSpan
        {
            get { return _rowSpan; }
            private set { _rowSpan = value; }
        }

        private int _columnSpan;
        public int ColumnSpan
        {
            get { return _columnSpan; }
            private set { _columnSpan = value; }
        }

        public Position()
        {
        }

        public Position(int row, int column, int rowSpan, int columnSpan)
        {
            ValidateField(row, column, rowSpan, columnSpan);

            _row = row;
            _column = column;
            _rowSpan = rowSpan;
            _columnSpan = columnSpan;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column &&
                   RowSpan == position.RowSpan &&
                   ColumnSpan == position.ColumnSpan;
        }

        public static bool operator ==(Position firstPosition, Position secondPosition)
        {
            if (firstPosition is null)
                return secondPosition is null;

            return firstPosition.Equals(secondPosition);
        }

        public static bool operator !=(Position firstPosition, Position secondPosition)
        {
            if (firstPosition is null)
            {
                throw new ArgumentNullException(nameof(firstPosition));
            }

            if (secondPosition is null)
            {
                throw new ArgumentNullException(nameof(secondPosition));
            }

            return !(firstPosition == secondPosition);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column, RowSpan, ColumnSpan);
        }

        public override string ToString()
        {
            return Row + " - " + RowSpan + " - " + Column + " - " + ColumnSpan;
        }

        public Position ExpandField(Position oldPosition, int height, int width)
        {
            int rowSpan = oldPosition.RowSpan + height;
            int columnSpan = oldPosition.ColumnSpan + width;
            return new Position(oldPosition.Row, oldPosition.Column, rowSpan, columnSpan);
        }

        public Position ReduceField(Position oldPosition, int height, int width)
        {
            int rowSpan = oldPosition.RowSpan - height;
            int columnSpan = oldPosition.ColumnSpan - width;
            return new Position(oldPosition.Row, oldPosition.Column, rowSpan, columnSpan);
        }

        public Position MoveField(Position oldPosition, int row, int column)
        {
            return new Position(row, column, oldPosition.RowSpan, oldPosition.ColumnSpan);
        }

        private void ValidateField(int row, int column, int rowSpan, int columnSpan)
        {
            ValidateElementOfField(row);
            ValidateElementOfField(column);
            ValidateSpanOfField(rowSpan);
            ValidateSpanOfField(columnSpan);
        }

        private void ValidateElementOfField(int elementOfField)
        {
            if (elementOfField > 1000) throw new Exception("The field element is too big of a size.");
            else if (elementOfField < 0) throw new Exception("The field element can't be negative.");
        }

        private void ValidateSpanOfField(int spanOfField)
        {
            if (spanOfField > 1000) throw new Exception("The span of the field is too big of a size.");
            else if (spanOfField < 1) throw new Exception("The span of the field can't be that small.");
        }
    }
}
