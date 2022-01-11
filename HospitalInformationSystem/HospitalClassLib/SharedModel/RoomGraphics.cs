using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.SharedModel
{
    public class RoomGraphics
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int XSpan { get; private set; }
        public int YSpan { get; private set; }
        public float RowPercent { get; private set; }

        private RoomGraphics() { }

        public RoomGraphics(int x, int y, int xSpan, int ySpan, float rowPercent)
        {
            X = x;
            Y = y;
            XSpan = xSpan;
            YSpan = ySpan;
            RowPercent = rowPercent;
            Validate();
        }

        private void Validate()
        {
            if (X < 0 || Y < 0) throw new ArgumentException("Coordinates cannot be negative");
            if (RowPercent > 100) throw new ArgumentException("Width cannot be greater than 100%");
        }
    }

    
}
