using System;
using System.Collections.Generic;

namespace Bolsover.ThreeDLine
{
    public class Coordinate
    {
        private double _x;
        private double _y;
        private double _z;

        public Coordinate(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public double X
        {
            get => _x;
            set => _x = value;
        }

        public double Y
        {
            get => _y;
            set => _y = value;
        }

        public double Z
        {
            get => _z;
            set => _z = value;
        }
    }
}