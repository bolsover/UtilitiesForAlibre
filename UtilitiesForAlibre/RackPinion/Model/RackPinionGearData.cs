namespace Bolsover.RackPinion.Model
{
    public class RackPinionGearData
    {
        public string Item { get; set; }
        public string PinionMetricValue { get; set; }
        public string GearMetricValue { get; set; }
        public string PinionImperialValue { get; set; }
        public string GearImperialValue { get; set; }
        public string PinionNotes { get; set; }
        public string GearNotes { get; set; }

        public RackPinionGearData(string item, string pinionMetricValue,  string pinionImperialValue, string pinionNotes,string gearMetricValue,string gearImperialValue,  string gearNotes)
        {
            Item = item;
            PinionMetricValue = pinionMetricValue;
            GearMetricValue = gearMetricValue;
            PinionImperialValue = pinionImperialValue;
            GearImperialValue = gearImperialValue;
            PinionNotes = pinionNotes;
            GearNotes = gearNotes;
        }
    }
}