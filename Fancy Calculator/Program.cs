using System;

namespace Fancy_Calculator
{
    class Program
    {
       
        static void Main(string[] args)
        {

            float sum;
            float num1;
            float num2;
            DataService dataService = new DataService();

            Console.WriteLine("A Console Calculator");
            Console.WriteLine("Enter a number: ");

           num1 = dataService.GetInput();

            Console.WriteLine("Enter a second number, and I will add it to the first: ");

            num2 = dataService.GetInput();

            sum = num1+num2;
            Console.WriteLine("Result: " + sum);
        }
    }
}
