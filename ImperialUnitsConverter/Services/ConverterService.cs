using ImperialUnitsConverter.Models;

namespace ImperialUnitsConverter.Services
{
    public class ConverterService : IConverterService
    {
        private static Unit[] _units;
        public ConverterService()
        {
            _units = Constants.SupportedUnits;
        }

        public Unit GetUnit(string userInput)
        {
            foreach (var unit in _units)
            {
                if (unit.Name == userInput.ToLower() || unit.Accronym == userInput.ToLower())
                {
                    return unit;
                }
            }
            return null;
        }

        public Unit[] GetAllSupportedUnits()
        {
            return _units;
        }
    }
}
