using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fancy_Calculator
{
    public class DataService
    {

        Calculator calculator = new Calculator();

        public string[] GetInput()
        {
            Console.WriteLine("Enter an binomial expression to evaluate:");
            string input = Console.ReadLine();

            if (input.ToLower().Equals("exit"))
            {
                return new string[] {input.ToLower()};
            }

            while (VerifyExpression(input) == false)
            {
                Console.WriteLine("The expression " + input + " was not valid. Please enter a valid expression: ");
                input = Console.ReadLine();
            }
            string[] verifiedInput;
            verifiedInput = ExpressionParser(input);
            return verifiedInput;
        }


        private bool VerifyNumericalInput(string input)
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

        private string[] ExpressionParser(String input)
        {
            
            string[] expressionInfo = input.Split(" ");

            return expressionInfo;
        }

        private bool IsOperation (string input)
        {
            string[] operations = { "+", "-", "*", "/"};
            bool isOperation = false;

            if (operations.Contains(input))
            {
                isOperation = true;
            }

            return isOperation;
        }

        private bool VerifyExpression(string input)
        {
            var expression = ExpressionParser(input);
            if (    expression.Length != 3                  || 
                    IsOperation(expression[1]) == false     ||
                    VerifyNumericalInput(expression[0])==false ||
                    VerifyNumericalInput(expression[2]) == false
                )
            {
                return false;
            }
            //checking for dividing by 0
            if(expression[1].Equals("/")&& !calculator.CanDivideBy(float.Parse(expression[2])))
            {
                return false;
            }

            else { return true; }
        }

        public float Calculate (string[] expressionInfo)
        {
            float result;
            string operation = expressionInfo[1];
            float num1 = float.Parse(expressionInfo[0]);
            float num2 = float.Parse(expressionInfo[2]);

            if (operation.Equals("+"))
            {
                result = calculator.Add(num1, num2);

            }
            else if (operation.Equals("-"))
            {
                result = calculator.Subtract(num1, num2);
            }
            else if (operation.Equals("*"))
            {
                result = calculator.Multiply(num1, num2);
            }
            else { result = calculator.Divide(num1, num2); };

            return result;
        }


    }
}
