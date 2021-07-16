using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanciestWebCalculator.Models
{
    public class Expression
    {
        public string Num1 { get; }
        public string Num2 { get; }
        public string Operation { get; }

        public Expression(string num1, string num2, string operation)
        {
            Num1 = num1;
            Num2 = num2;
            Operation = operation;
        }

        public override string ToString()
        {
            return Num1 + " " + Operation + " " + Num2;
        }
    }
}
