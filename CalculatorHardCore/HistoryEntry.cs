using CalculatorHardCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanciestWebCalculator.Models
{
    public class HistoryEntry
    {
        public HistoryType type;
        public string Filter;
        public Expression Expression { get; }
        public List<Expression> HistoryList { get; }
        public string Result { get; }
        public string Message { get; }
        public bool UsedPrevResult { get; set; }

        public HistoryEntry(string result, string message)
        {
            Result = result;
            Message = message;
            type = HistoryType.error;
        }
        public HistoryEntry(string result, string message, List<Expression> historyList)
        {
            Result = result;
            Message = message;
            HistoryList = historyList;
            type = HistoryType.history;
        }

        public HistoryEntry(string result, string message, string filter, List<Expression> historyList)
        {
            Result = result;
            Message = message;
            Filter = filter; 
            HistoryList = historyList;
            type = HistoryType.filteredHistory;
        }

        public HistoryEntry(string result, string message, Expression expression, bool usedPR)
        {
            Result = result;
            Message = message;
            Expression = expression;
            UsedPrevResult = usedPR;
            type = HistoryType.equation;
        }

        override
        public string ToString()
        {
            var modNum1 = Expression.Num1;
            if (UsedPrevResult)
            {
                modNum1 = "_" + modNum1;
            }
            return string.Concat(modNum1 + " " + Expression.Operation+ " ", Expression.Num2, " ", "=", " ", Result);
        }



    }
}
