using System;

namespace SimpleCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== ПРОСТОЙ КАЛЬКУЛЯТОР ===");

			bool continueCalculations = true;

			while (continueCalculations)
			{
				try
				{
					Console.WriteLine("\nДоступные операции: +, -, *, /, ^");
					Console.Write("Выберите операцию: ");
					string operation = Console.ReadLine();

					if (operation != "+" && operation != "-" && operation != "*" &&
						operation != "/" && operation != "^")
					{
						Console.WriteLine("Ошибка: Неверная операция!");
						continue;
					}

					Console.Write("Введите первое число: ");
					double num1 = GetNumberFromInput();
					Console.Write("Введите второе число: ");
					double num2 = GetNumberFromInput();
					double result = Calculate(num1, num2, operation);
					Console.WriteLine($"\nРезультат: {num1} {operation} {num2} = {result}");
					continueCalculations = AskToContinue();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Ошибка: {ex.Message}");
				}
			}

			Console.WriteLine("\nСпасибо за использование калькулятора!");
		}
		static double GetNumberFromInput()
		{
			while (true)
			{
				string input = Console.ReadLine();
				if (double.TryParse(input, out double number))
				{
					return number;
				}
				else
				{
					Console.Write("Ошибка! Введите корректное число: ");
				}
			}
		}
		static double Calculate(double a, double b, string operation)
		{
			return operation switch
			{
				"+" => a + b,
				"-" => a - b,
				"*" => a * b,
				"/" => a / b,
				"^" => Math.Pow(a, b),
				_ => throw new ArgumentException("Неизвестная операция")
			};
		}
		static bool AskToContinue()
		{
			while (true)
			{
				Console.Write("\nПродолжить вычисления? (y/n): ");
				string response = Console.ReadLine().ToLower();

				if (response == "y" || response == "д" || response == "yes")
					return true;
				else if (response == "n" || response == "н" || response == "no")
					return false;
				else
					Console.WriteLine("Пожалуйста, введите 'y' для продолжения или 'n' для выхода");
			}
		}
	}
}

