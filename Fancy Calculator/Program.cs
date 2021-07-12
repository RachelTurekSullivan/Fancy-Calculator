using System;

namespace Fancy_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1;
            string input2;
            float sum;
            float num1;
            float num2;


            Console.WriteLine("A Console Calculator");
            Console.WriteLine("Enter a number: ");
            input1 = Console.ReadLine();
            Console.WriteLine("Enter a second number, and I will add it to the first: ");
            input2 = Console.ReadLine();
            sum = float.Parse(input1) + float.Parse(input2);
            Console.WriteLine("Result: " + sum);
        }
    }
}
