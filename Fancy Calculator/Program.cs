using System;
using System.Collections.Generic;

namespace Fancy_Calculator
{
    class Program
    {
       
        static void Main(string[] args)
        {
            bool run = true;
            float prevExpression = 0;
            var history = new List<Entry>();
            DataService dataService = new DataService();

            Console.WriteLine("A Console Calculator");


            while (run)
            {
                string[] input = dataService.GetInput(prevExpression);

                if (input[0].Equals("exit"))
                {
                    run = false;
                    break;
                }

                if (input[0].Equals("history"))
                {
                    foreach (var entry in history) {
                        Console.WriteLine(entry.ToString());
                    }
                }

                else
                {
                    var result = dataService.Calculate(input);
                    history.Add(new Entry(float.Parse(input[0]), float.Parse(input[2]),input[1], result));
                    prevExpression = result;
                    Console.WriteLine("Result: " + result);
                }
                
            }
        }
    }
}
