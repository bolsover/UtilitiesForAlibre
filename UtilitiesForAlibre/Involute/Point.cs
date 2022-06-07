namespace Bolsover.Involute
{
    /// <summary>
    /// A class to represent points in space
    /// </summary>
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point()
        {
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Z: " + Z;
        }
    }
}