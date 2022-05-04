using System;
using System.Collections.Generic;

namespace Bolsover.ThreeDLine
{
    public class Coordinate
    {
        private double x;
        private double y;
        private double z;

        public Coordinate(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X
        {
            get => x;
            set => x = value;
        }

        public double Y
        {
            get => y;
            set => y = value;
        }

        public double Z
        {
            get => z;
            set => z = value;
        }
    }
}