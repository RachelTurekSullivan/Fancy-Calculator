using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fancy_Calculator
{
    public class Entry
    {
        float Num1 { get; set; }
        float Num2 { get; set; }
        float Result { get; set; }
        string Operation { get; set; }

        public Entry(float num1, float num2, string operation, float result)
        {
            Num1 = num1;
            Num2 = num2;
            Operation = operation;
            Result = result;

        }

        override
        public string ToString()
        {
            return string.Concat(Num1, " ", Operation, " ",Num2, " ", "=", " ", Result);

        }
    }
}
