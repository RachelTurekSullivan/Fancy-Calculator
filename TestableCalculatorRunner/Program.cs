using CalculatorCore;
using System;



namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var run = true;
            string prevResult = "0";

            while (run)
            {
                Console.WriteLine("Give me math or give me death.");

                var input = Console.ReadLine();

                Result output = calculator.Evaluate(input, prevResult);

                if (output.result.Equals("exit"))
                {
                    Console.WriteLine(output.message);
                    run = false;
                                 }

                else if(output.result.Equals("history"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(output.message);
                    Console.ResetColor();

                }

                else if (output.result.Equals("error"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(output.message);
                    Console.ResetColor();
                }

                else
                {
                    Console.WriteLine("Result: " + output.result);
                    prevResult = output.result;
                }
            }

        }
    }
}
