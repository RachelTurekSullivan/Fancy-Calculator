using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanciestWebCalculator.Models
{
    public class CalculatorStateModel
    {
        public CalculatorHistory History { get; set; }
        public List<string> HistoryList { get; set; }
        public HistoryEntry PreviousEntry { get; set; }

        public bool HasHistory()
        {
            if (History != null && History.Entries != null)
            {
                return true;
            }
            else { return false; }
        }

        public bool HasHistoryList()
        {
            if(HistoryList !=null && HistoryList.Count > 1)
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
