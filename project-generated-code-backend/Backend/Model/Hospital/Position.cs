using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Model.Hospital
{
    public class Position : Entity
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }

        public Position() : base()
        {
        }

        public Position(string serialNumber, int row, int column, int rowSpan, int columnSpan) : base(serialNumber)
        {
            Row = row;
            Column = column;
            RowSpan = rowSpan;
            ColumnSpan = columnSpan;
        }
    }
}
