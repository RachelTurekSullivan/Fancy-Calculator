using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class HistoryEntry
    {
        public float Num1 { get; set; }
        public float Num2 { get; set; }
        public Result Result { get; set; }
        public string Operation { get; set; }
        public bool UsedPrevResult { get; set; }
    
        public HistoryEntry(float num1, float num2, string operation, Result result, bool usedPrevResult)
        {
            Num1 = num1;
            Num2 = num2;
            Operation = operation;
            Result = result;
            UsedPrevResult = usedPrevResult;
        }

        override
        public string ToString()
        {
            return string.Concat(Num1, " ", Operation, " ", Num2, " ", "=", " ", Result.result);
        }

    
    }
}
