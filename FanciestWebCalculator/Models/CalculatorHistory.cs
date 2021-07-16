using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanciestWebCalculator.Models
{
    public class CalculatorHistory
    {
        public List<HistoryEntry> Entries { get; set; }
        
        public CalculatorHistory(List<HistoryEntry> historyEntries)
        {
            Entries = historyEntries;
        }

    }
}
