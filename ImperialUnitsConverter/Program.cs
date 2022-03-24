using ImperialUnitsConverter.Services;
using ImperialUnitsConverter.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ImperialUnitsConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConverterService, ConverterService>()
                .AddSingleton<IInputValidator, InputValidator>()
                .BuildServiceProvider();

            var converterService = serviceProvider.GetService<IConverterService>();
            var inputValidator = serviceProvider.GetService<IInputValidator>();
            
            Console.WriteLine("The following imperical units (and their accronyms) are currently supported:");
            foreach (var unit in converterService.GetAllSupportedUnits()){
                Console.Write($" {unit.Name} ({unit.Accronym}) ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please input your conversion using the following four string sentence as an example \"25 foot in yard\":");
            Console.WriteLine();

            while (true)
            {
                var input = Console.ReadLine();
                Console.SetCursorPosition(input.Length + 1, Console.CursorTop - 1);
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var splitInput = input.Split(" ");
                if (!inputValidator.ValidateLength(splitInput))
                {
                    Console.WriteLine("=> Please submit your request in four seperate strings");
                    continue;
                }

                var amount = splitInput[0];
                var fromInput = splitInput[1];
                var toInput = splitInput[3];

                var convertedAmount = inputValidator.ValidateAmount(amount);

                if (convertedAmount == null)
                {
                    Console.WriteLine($"=> The amount {amount} is not a valid number");
                    continue;
                }

                var fromUnit = converterService.GetUnit(fromInput);
                var toUnit = converterService.GetUnit(toInput);

                if (fromUnit == null || toUnit == null)
                {
                    Console.WriteLine($"=> Could not convert between {fromInput} and {toInput}. Please check valid unit types above and try again.");
                    continue;
                }

                Console.Write($"=> {fromUnit.CalculateConversion(convertedAmount, fromUnit.UnitType, toUnit)}");
                Console.WriteLine();
            }
        }
    }
}
