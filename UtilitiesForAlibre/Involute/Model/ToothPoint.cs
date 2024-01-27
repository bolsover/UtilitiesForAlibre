namespace Bolsover.Involute.Model
{
    public class ToothPoint
    {
        public ToothPoint(int id, string name, GearPoint point)
        {
            Id = id;
            Name = name;
            Point = point;
        }

        public int Id { get; set; }

        public GearPoint Point { get; set; }

        public string Name { get; set; }
    }
}