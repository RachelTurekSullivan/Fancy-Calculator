using ConsoleTables;
using System;
using System.Collections.Generic;

namespace CalculatorCore
{
    public class Calculator
    {
        public readonly DataService DataService;
        public List<HistoryEntry> History;
        string PrevExpression;

        public Calculator()
        {
            DataService = new DataService();
            History = new List<HistoryEntry>();
            PrevExpression = "0";
        }

        //private float prevExpression;
        public Result Evaluate(string input, string prevEx)
        {

            //later this can be sent in from test
            if(null != prevEx && !prevEx.Equals(""))
            {
                PrevExpression = prevEx;
            }
            
            var verifiedInput = DataService.ParseInput(PrevExpression, input);

            if (verifiedInput[0].Equals("error")) {
                return new Result(verifiedInput[0], verifiedInput[1]);
            }

            if (verifiedInput[0].Equals("exit")){
                return new Result(verifiedInput[0], "Have a nice day!");
            }

            if (verifiedInput[0].Equals("history"))
            {
                var displayTable = new ConsoleTable( " ", " ", " ");
                var displayList = new List<HistoryEntry>();
                string operation;

                //history with operation filter
                if(verifiedInput.Length == 2)
                {
                    operation = verifiedInput[1];
                    foreach(var entry in History)
                    {
                        if (entry.Operation.Equals(operation))
                        {
                            displayList.Add(entry);
                            History.Add(entry);
                        }
                    }
                }
                //history with no filter
                else
                {
                    displayList = History;
                }


                foreach (var entry in displayList)
                {
                    var prefix = "";
                    if (entry.UsedPrevResult)
                    {
                        prefix = "_";
                    }
                    displayTable.AddRow(prefix+entry.Num1 + " " + entry.Operation + " " + entry.Num2, "=", entry.Result.result);
                }

                displayTable.Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.Minimal);

                History = displayList;
                return new Result(verifiedInput[0], "What do you mean you don't like math??? You have so much HISTORY!");
            }

            else {
                Result result = new Result(DataService.Calculate(verifiedInput).ToString(), "success");

                bool usedPreviousResult = DataService.verificationService.IsOperation(input.Substring(0,1));

                History.Add(new HistoryEntry(float.Parse(verifiedInput[0]), float.Parse(verifiedInput[2]), verifiedInput[1], result, usedPreviousResult));
                PrevExpression = result.result;
                return result;
            }
        }

        public List<HistoryEntry> GetHistory()
        {
            return History;
        }      

        public string GetPreviousResult()
        {
            return PrevExpression;
        }
        public void SetPreviousResult(string input)
        {
            this.PrevExpression = input;
        }
        
        
    }
}
