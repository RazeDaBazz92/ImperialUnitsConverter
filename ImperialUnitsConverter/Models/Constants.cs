namespace ImperialUnitsConverter.Models
{
    public static class Constants
    {
        public enum UnitTypes
        {
            Length,
            Weight
        };

        public static Unit[] SupportedUnits => new Unit[]
        { 
           new Unit("thou", "th", 0.001M, UnitTypes.Length),
           new Unit("inch", "in", 1.0M, UnitTypes.Length),
           new Unit("foot", "ft", 12M, UnitTypes.Length),
           new Unit("yard", "yd", 36M, UnitTypes.Length),
           new Unit("furlong", "fur", 7920M, UnitTypes.Length)
        };
    }
}
