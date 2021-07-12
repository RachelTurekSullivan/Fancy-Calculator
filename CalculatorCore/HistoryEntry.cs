using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class HistoryEntry
    {
        float Num1 { get; set; }
        float Num2 { get; set; }
        Result Result { get; set; }
        string Operation { get; set; }
    
        public HistoryEntry(float num1, float num2, string operation, Result result)
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
