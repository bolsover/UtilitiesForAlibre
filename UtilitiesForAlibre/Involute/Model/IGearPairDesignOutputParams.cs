namespace Bolsover.Involute.Model
{
    public interface IGearPairDesignOutputParams
    {
        IGearPairDesignInputParams GearPairDesignInputParams { get; set; }
        IGearDesignOutputParams PinionDesignOutput { get; set; }
        IGearDesignOutputParams GearDesignOutput { get; set; }
        
        void Reset();
    }
}