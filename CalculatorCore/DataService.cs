using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class DataService
    {
        public VerificationService verificationService;
        //CalculatorService calculator = new CalculatorService();
        public DataService()
        {
            verificationService = new VerificationService();
        }

        public string[] ParseInput(string prevExpression, string calcInput)
        {
            //Console.WriteLine("Enter an binomial expression to evaluate:");
            string input = calcInput;

            if (input.ToLower().Equals("exit"))
            {
                return new string[] {input.ToLower()};
            }
            if (input.ToLower().Contains("history ") && verificationService.ContainsOperation(input))
            {
                return ExpressionParser(input);
            }
            if (input.ToLower().Equals("history"))
            {
                return new string[] { input.ToLower() };   
            }

            string[] parsedInput;
            parsedInput = ExpressionParser(input);

            //Error Messages
            if (verificationService.VerifyExpression(parsedInput) == false)
            {
                if (verificationService.VerifyNumericalInput(parsedInput[0]) == false)
                {
                    return new string[] { "error", parsedInput[0] + " is not a valid number. Please enter a valid expression in the form '6.9 + 5' or - 8: " };
                }
                if (parsedInput.Length>2 && verificationService.VerifyNumericalInput(parsedInput[2]) == false)
                {
                    return new string[] { "error", parsedInput[2] + " is not a valid number. Please enter a valid expression in the form '6.9 + 5' or - 8: " };
                }

                if (parsedInput.Length > 2 && verificationService.IsOperation(parsedInput[1]) == false)
                {
                    return new string[] { "error", parsedInput[1] + " is not a valid operation. Valid operators are { + - * / }. Please enter a valid expression in the form '6.9 + 5' or - 8: " };
                }
                if (parsedInput[1].Equals("/") && !CalculatorService.CanDivideBy(float.Parse(parsedInput[2])))
                {

                    return new string[] { "error", "Cannot divide by zero. Please enter a valid expression in the form '6.9 + 5' or - 8: " };

                }
                else { 
                return new string[] { "error", "The expression " + input + " was not valid. Please enter a valid expression in the form '6.9 + 5' or - 8: " };
                }
            }


            //this will only happen if the first input is an operator and the second is a number becuase it's been verified already
            if (parsedInput.Length == 2 && verificationService.IsOperation(parsedInput[0]) && verificationService.VerifyNumericalInput(parsedInput[1])) 
            { 
                var tempList = new List<String>();

                tempList.Add(prevExpression);
                tempList.Add(parsedInput[0]);
                tempList.Add(parsedInput[1]);
                parsedInput = tempList.ToArray();
            }


            return parsedInput;
        }


       
        private string[] ExpressionParser(String input)
        {
            
            string[] expressionInfo = input.Split(" ");

            return expressionInfo;
        }


        public float Calculate (string[] expressionInfo)
        {
            float result;
            string operation = expressionInfo[1];
            float num1 = float.Parse(expressionInfo[0]);
            float num2 = float.Parse(expressionInfo[2]);

            if (operation.Equals("+"))
            {
                result = CalculatorService.Add(num1, num2);

            }
            else if (operation.Equals("-"))
            {
                result = CalculatorService.Subtract(num1, num2);
            }
            else if (operation.Equals("*"))
            {
                result = CalculatorService.Multiply(num1, num2);
            }
            else { result = CalculatorService.Divide(num1, num2); };

            return result;
        }


    }
}
