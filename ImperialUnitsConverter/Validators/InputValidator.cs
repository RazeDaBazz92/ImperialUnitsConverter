using System;

namespace ImperialUnitsConverter.Validators
{
    public class InputValidator : IInputValidator
    {
        public bool ValidateLength(string[] input)
        {
            if (input.Length != 4)
            {
                return false;
            }

            return true;
        }

        public decimal? ValidateAmount(string amount)
        {
            try
            {
                return Convert.ToDecimal(amount);
            }
            catch
            {
                return null;
            }
        }
    }
}
