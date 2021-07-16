using CalculatorCore;
using FanciestWebCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FanciestWebCalculator.Services;

namespace FanciestWebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly Calculator _calculator;
        private readonly CalculatorServices _CalculatorService;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_calculator = new Calculator();
            _CalculatorService = new CalculatorServices();
        }

        public IActionResult Index()
        {

            var vm = new CalculatorStateModel();
            var history = HttpContext.Session.Get<CalculatorHistory>("History");
            var historyList = HttpContext.Session.Get<List<string>>("HistoryList");

            if (history != null)
            {

                vm.History = history;
                vm.PreviousEntry = vm.History.Entries.LastOrDefault();
                
            }
            if(historyList != null && historyList.Count>0)
            {
                vm.HistoryList = historyList;
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(string calcInput)
        {
            if(calcInput != null)
            {

                var tempHistory = _CalculatorService.Calculate(calcInput, HttpContext.Session.Get<CalculatorHistory>("History"));

                if (calcInput.Contains("history"))
                {
                    var lastChar = calcInput.LastOrDefault().ToString();

                    if (calcInput.Equals("history"))
                    {
                        var historyList = GetHistoryList();
                        HttpContext.Session.Set("HistoryList", historyList);
                    }
                    else if (_CalculatorService.IsOperation(lastChar))                
                    {
                        var historyList = GetFilteredHistoryList(lastChar);
                        HttpContext.Session.Set("HistoryList", historyList);
                    }
                }
                

                HttpContext.Session.Set("History", tempHistory);
               
                
            }



            //if (calcInput != null)
            //{

            //    var tempHistory = new List<Models.HistoryEntry>();
            //    string rawResult = "";
            //    string rawMessage = "";
            //    string[] rawExpression = Array.Empty<string>();
            //    if (HttpContext.Session.Get<CalculatorHistory>("History") == null)
            //    {
            //        HttpContext.Session.Set("History", tempHistory);
            //        rawResult = _calculator.Evaluate(calcInput, "0").result;
            //        rawMessage = _calculator.Evaluate(calcInput, "0").message;
            //        rawExpression = _calculator.DataService.ParseInput("0", calcInput);
            //    }
            //    else if (HttpContext.Session.Get<CalculatorHistory>("History").Entries != null)
            //    {
            //        var calcHistory = HttpContext.Session.Get<CalculatorHistory>("History");
            //        tempHistory = calcHistory.Entries;
            //        if (HttpContext.Session.Get<CalculatorHistory>("History").Entries != null && HttpContext.Session.Get<CalculatorHistory>("History").Entries.Count > 0)
            //        {
            //            var prevEntry = tempHistory.FirstOrDefault();
            //            rawResult = _calculator.Evaluate(calcInput, prevEntry.Result).result;
            //            rawMessage = _calculator.Evaluate(calcInput, prevEntry.Message).message;
            //            rawExpression = _calculator.DataService.ParseInput(prevEntry.Result, calcInput);
            //        }
            //    }

            //    var result = new Result(rawResult, rawMessage);


            //    if (result.result.ToLower().Equals("error") || result.result.ToLower().Equals("history"))
            //    {
            //        var expression = new Expression("", "", "");
            //        tempHistory.Add(new Models.HistoryEntry(result.result, result.message, expression, false));
            //    }

            //    else
            //    {
            //        var usedPrevExpression = false;
            //        if (rawExpression.Length == 2)
            //        {
            //            usedPrevExpression = true;
            //        }
            //        var expression = new Expression(rawExpression[0], rawExpression[2], rawExpression[1]);
            //        var currentEntry = new Models.HistoryEntry(result.result, result.message, expression, usedPrevExpression);
            //        tempHistory.Add(currentEntry);

            //        HttpContext.Session.Set("History", new CalculatorHistory(tempHistory));
                    
            //    }

            //}
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public List<String> GetHistoryList()
        {
            var History = HttpContext.Session.Get<CalculatorHistory>("History");
            var formattedHistory = new List<string>();

            foreach (var entry in History.Entries)
            {
                if (!entry.Result.Equals("history") && !entry.Result.Equals("error"))
                { 
                    formattedHistory.Add(entry.ToString());
                }
            }


            return formattedHistory;
        }

        public List<String> GetFilteredHistoryList(string operation)
        {
            var History = HttpContext.Session.Get<CalculatorHistory>("History");
            var formattedHistory = new List<string>();

            foreach (var entry in History.Entries)
            {
                if (entry.Expression.Operation.Equals(operation) && (!entry.Result.Equals("history") && !entry.Result.Equals("error")))
                {
                    formattedHistory.Add(entry.ToString());
                }
            }


            return formattedHistory;
        }
    }
}
