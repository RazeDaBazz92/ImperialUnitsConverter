using ImperialUnitsConverter.Models;

namespace ImperialUnitsConverter.Services
{
    public interface IConverterService
    {
        Unit GetUnit(string userInput);
        Unit[] GetAllSupportedUnits();
    }
}
