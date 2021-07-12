using System;

namespace Fancy_Calculator
{
    class Program
    {
       
        static void Main(string[] args)
        {
            bool run = true;
            DataService dataService = new DataService();

            Console.WriteLine("A Console Calculator");


            while (run)
            {
                string[] input = dataService.GetInput();

                if (input[0].Equals("exit"))
                {
                    run = false;
                }
                else
                {
                    var result = dataService.Calculate(input);

                    Console.WriteLine("Result: " + result);
                }
                
            }
        }
    }
}
