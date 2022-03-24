namespace ImperialUnitsConverter.Validators
{
    public interface IInputValidator
    {
        bool ValidateLength(string[] input);
        decimal? ValidateAmount(string amount);
    }
}
