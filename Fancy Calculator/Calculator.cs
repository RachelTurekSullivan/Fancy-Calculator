using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fancy_Calculator
{
    public class Calculator
    {
        public float Add(float num1, float num2)
        {
            return num1 + num2;
        }
        public float Subtract(float num1, float num2)
        {
            return num1 - num2;
        }
        public float Multiply (float num1, float num2)
        {
            return num1 * num2;
        }
        public float Divide (float num1, float num2)
        {
            return num1 / num2;   
        }

        public bool CanDivideBy(float num)
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
