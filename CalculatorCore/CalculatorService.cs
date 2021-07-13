using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public static class CalculatorService
    {
        public static float Add(float num1, float num2)
        {
            return num1 + num2;
        }
        public static float Subtract(float num1, float num2)
        {
            return num1 - num2;
        }
        public static float Multiply (float num1, float num2)
        {
            return num1 * num2;
        }
        public static float Divide (float num1, float num2)
        {
            return num1 / num2;   
        }

        public static bool CanDivideBy(float num)
        {
            if (num != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
 
    }
}
