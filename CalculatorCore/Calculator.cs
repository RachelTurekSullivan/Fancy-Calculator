using System;
using System.Collections.Generic;

namespace CalculatorCore
{
    public class Calculator
    {

        DataService dataService = new DataService();
        List<HistoryEntry> history = new List<HistoryEntry>();

        //private float prevExpression;
        public Result Evaluate(string input)
        {

            //later this can be sent in from test
            float prevExpression = 0;
           
            var verifiedInput = dataService.VerifyInput(prevExpression, input);

            if (verifiedInput[0].Equals("error")) {
                return new Result(verifiedInput[0], verifiedInput[1]);
            }
            else {

                Result result = new Result(dataService.Calculate(verifiedInput).ToString(), "success");
                //history.Add(new HistoryEntry(float.Parse(verifiedInput[0]), float.Parse(verifiedInput[2]), verifiedInput[1], result));
                //prevExpression = result;
                //Console.WriteLine("Result: " + result);

                return result;
            }
        }
    }
}
