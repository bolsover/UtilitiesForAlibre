using Bolsover.Involute.Model;

namespace Bolsover.Involute.Builder
{
    public interface IToothPointsBuilder
    {
        Tooth Build(IGearDesignOutputParams gearPairDesignOutputParams);
    }
}