using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fancy_Calculator
{
    public class DataService
    {
        public float GetInput()
        {

            string input = Console.ReadLine();
            float verifiedInput;

            while (VerifyNumericalInput(input) == false)
            {
                Console.WriteLine("The value " + input + " was not a valid number. Please enter a number: ");
                input = Console.ReadLine();
            }

            verifiedInput = float.Parse(input);

            return verifiedInput;

        }
        public bool VerifyNumericalInput(string input)
        {
            if (input.Equals('0'))
            {
                return true;
            }
            else 
            { 
                var isNumber = float.TryParse(input, out _);
                if (isNumber == true)
                {
                    return true;
                }
                else { return false; }
            }
        }

    }
}
