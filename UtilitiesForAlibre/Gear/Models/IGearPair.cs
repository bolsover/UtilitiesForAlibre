namespace Bolsover.Gear.Models
{
    public interface IGearPair
    {
        IGear Pinion { get; set; }
        IGear Gear { get; set; }
    }
}