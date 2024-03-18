namespace Bolsover.RackPinion.Model
{
    public class RackParams
    {
        // session.Parameters.Item("Alpha").Value = Radians(Model.Gear.PressureAngle);
        // session.Parameters.Item("Beta").Value = Radians(Model.Gear.HelixAngle);
        // session.Parameters.Item("Module").Value = Model.Gear.Module * 0.1;
        // session.Parameters.Item("RackTeeth").Value = Model.Gear.Teeth;
        // session.Parameters.Item("Width").Value = Model.Gear.Height * 0.1;
        public double PressureAngle { get; set; }
        public double HelixAngle { get; set; }
        public double Module { get; set; }
        public double Teeth { get; set; }
        public double Height { get; set; }
    }
}