using System;
using static ImperialUnitsConverter.Models.Constants;

namespace ImperialUnitsConverter.Models
{
    public class Unit
    {
        public string Name { get; }
        public string Accronym { get; }
        public decimal Ratio { get; }
        public UnitTypes UnitType { get; }

        public Unit(string name, string accronym, decimal ratio, UnitTypes unitType)
        {
            Name = name.ToLower();
            Accronym = accronym.ToLower();
            Ratio = ratio;
            UnitType = unitType;
        }

        public decimal? CalculateConversion(decimal? value, UnitTypes unitType, Unit unit)
        {
            if (unitType == unit.UnitType && unitType == UnitTypes.Length && value != null)
            {
                decimal decimalValue = Convert.ToDecimal(value);
                return Math.Round(decimalValue * Ratio / unit.Ratio, 10);
            }

            return null;
        }
    }
}
