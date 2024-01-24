using Bolsover.Gear.Models;

namespace Bolsover.Involute.Model
{
    public class ToothPoint
    {
        private int _id;
        private string _name;
        private GearPoint _point;

        public ToothPoint(int id, string name, GearPoint point)
        {
            _id = id;
            _name = name;
            _point = point;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public GearPoint Point
        {
            get => _point;
            set => _point = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}