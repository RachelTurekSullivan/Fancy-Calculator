﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanciestWebCalculator.Models
{
    public class CalculatorStateModel
    {
        public CalculatorHistory History { get; set; }
        public HistoryEntry CurrentEntry { get; set; }
        public HistoryEntry PreviousEntry { get; set; }

    }
}