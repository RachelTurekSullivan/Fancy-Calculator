using CalculatorCore;
using FanciestWebCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace FanciestWebCalculator.Services
{
    public class CalculatorServices
    {
        private readonly Calculator _calculator;
        public readonly List<CalculatorCore.HistoryEntry> History;

        public CalculatorServices()
        {
            _calculator = new Calculator();
            History = new List<CalculatorCore.HistoryEntry>();
        }
        public CalculatorHistory Calculate(string calcInput, CalculatorHistory history)
        {

            //if Calculator History hasn't been initilized do that
            if (history == null)
            {
                var blankHistory = new List<Models.HistoryEntry>();
                history = new CalculatorHistory(blankHistory);
            }

            //if there is actual input
            if (calcInput != null)
            {

                var tempHistory = new List<Models.HistoryEntry>();
                string rawResult = "";
                string rawMessage = "";
                string[] rawExpression = Array.Empty<string>();

                //If there are  entries in the Calculator History, get them               
                if (history.Entries != null && history.Entries.Count>0)
                {
                    var calcHistory = history;
                    tempHistory = calcHistory.Entries;
                    if (history.Entries != null && history.Entries.Count > 0)
                    {
                        var prevEntry = tempHistory.FirstOrDefault();
                        rawResult = _calculator.Evaluate(calcInput, prevEntry.Result).result;
                        rawMessage = _calculator.Evaluate(calcInput, prevEntry.Result).message;
                        rawExpression = _calculator.DataService.ParseInput(prevEntry.Result, calcInput);
                    }
                }
                //if the entries list is null initilize it
                //use 0 for previous result
                else
                {
                    history.Entries = new List<Models.HistoryEntry>();
                    rawResult = _calculator.Evaluate(calcInput, "0").result;
                    rawMessage = _calculator.Evaluate(calcInput, "0").message;
                    rawExpression = _calculator.DataService.ParseInput("0", calcInput);
                }
                
                               

                var result = new Models.Result(rawResult, rawMessage);


                if (result.result.ToLower().Equals("error") )
                {
                    var expression = new Expression("", "", "");
                    tempHistory.Add(new Models.HistoryEntry(result.result, result.message, expression, false));
                }
                else if (result.result.ToLower().Equals("history")){
                    var expression = new Expression("", "", "");

                    var historyList = _calculator.GetHistory();
                    //need to convert this to something I can iterate through to display the lines of history

                    if(historyList.Count > 0)
                    {

                    }


                    tempHistory.Add(new Models.HistoryEntry(result.result, result.message, expression, false));
                }

                else
                {
                    var usedPrevExpression = false;
                    if (rawExpression.Length == 2)
                    {
                        usedPrevExpression = true;
                    }
                    var expression = new Expression(rawExpression[0], rawExpression[2], rawExpression[1]);
                    var currentEntry = new Models.HistoryEntry(result.result, result.message, expression, usedPrevExpression);
                    tempHistory.Add(currentEntry);
                }

                history.Entries = tempHistory;
              
            }
            return history;
        } 
        
        public bool IsOperation(string input)
        {
            if (_calculator.DataService.verificationService.IsOperation(input))
            {
                return true;
            }
            return false;
        }

        
    }
}
