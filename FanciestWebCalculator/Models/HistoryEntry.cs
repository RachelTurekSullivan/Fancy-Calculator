using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanciestWebCalculator.Models
{
    public class HistoryEntry
    {
        public Expression Expression { get; }
        public string Result { get; }
        public string Message { get; }
        public bool UsedPrevResult { get; set; }

        public HistoryEntry(string result, string message, Expression expression, bool usedPR)
        {
            Result = result;
            Message = message;
            Expression = expression;
            UsedPrevResult = usedPR;
        }

            
    }
}
