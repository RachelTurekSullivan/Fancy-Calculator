using ConsoleTables;
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

            if (verifiedInput[0].Equals("exit")){
                return new Result(verifiedInput[0], "Have a nice day!");
            }

            if (verifiedInput[0].Equals("history"))
            {
                var displayTable = new ConsoleTable(" ", " " , " ", " ", " ");
                foreach (var entry in history)
                {
                    Console.WriteLine(entry.ToString());
                    displayTable.AddRow(entry.Num1, entry.Operation, entry.Num2, "=", entry.Result.result);
                   
                }
                Console.WriteLine(displayTable);
                displayTable.Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.Minimal);
                return new Result(verifiedInput[0], "What do you mean you don't like math??? You have so much HISTORY!");
            }

            else {

                Result result = new Result(dataService.Calculate(verifiedInput).ToString(), "success");
                history.Add(new HistoryEntry(float.Parse(verifiedInput[0]), float.Parse(verifiedInput[2]), verifiedInput[1], result));
                prevExpression = float.Parse(result.result);
                return result;
            }
        }
    }
}
