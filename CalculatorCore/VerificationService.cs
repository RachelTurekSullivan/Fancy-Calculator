using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class VerificationService
    {
        
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

        public bool IsOperation(string input)
        {
            string[] operations = { "+", "-", "*", "/" };
            bool isOperation = false;

            if (operations.Contains(input))
            {
                isOperation = true;
            }

            return isOperation;
        }

        public bool ContainsOperation(string input)
        {

            foreach (var c in input.ToArray())
            {
                if (IsOperation(c.ToString()))
                {
                    return true;
                }
            }
            return false;

        }

        public bool VerifyExpression(string[] expression)
        {
          
            if (expression.Length != 3 ||
                    IsOperation(expression[1]) == false ||
                    VerifyNumericalInput(expression[0]) == false ||
                    VerifyNumericalInput(expression[2]) == false
                )
            {
                //if the operation is using the previous result as num1
                if (IsOperation(expression[0]) && VerifyNumericalInput(expression[1]))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else { return true; }
        }
    }
}
