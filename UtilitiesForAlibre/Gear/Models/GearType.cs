namespace Bolsover.Gear.Models
{
    public class GearType
    {
        
        public static readonly GearType Internal = new GearType("Internal");
        public static readonly GearType External = new GearType("External");

        
        public string ShortName { get; }
        
        private GearType(string shortName)
        {
            ShortName = shortName;
        }

    }
}