using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Result
    {
        public string result { get; set; }

        public string message { get; set; }

        public Result(string _result, string _message)
        {
            result = _result;
            message = _message;
        }
    }
}
