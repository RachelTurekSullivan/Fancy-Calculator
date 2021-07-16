﻿using CalculatorCore;
using FanciestWebCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FanciestWebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Calculator _calculator;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _calculator = new Calculator();
            
        }

        public IActionResult Index()
        {
            var vm = new CalculatorStateModel();
            var history = HttpContext.Session.Get<CalculatorHistory>("History");

            if (history != null)
            {

                vm.History = history;
                vm.PreviousEntry = vm.History.Entries.LastOrDefault();
            }
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(string calcInput)
        {
            if (calcInput != null)
            {

                var tempHistory = new List<Models.HistoryEntry>();
                string rawResult = "";
                string rawMessage = "";
                string[] rawExpression = Array.Empty<string>();
                if (HttpContext.Session.Get<CalculatorHistory>("History") == null)
                {
                    HttpContext.Session.Set("History", tempHistory);
                    rawResult = _calculator.Evaluate(calcInput, "0").result;
                    rawMessage = _calculator.Evaluate(calcInput, "0").message;
                    rawExpression = _calculator.DataService.ParseInput("0", calcInput);
                }
                else if (HttpContext.Session.Get<CalculatorHistory>("History").Entries != null)
                {
                    var calcHistory = HttpContext.Session.Get<CalculatorHistory>("History");
                    tempHistory = calcHistory.Entries;
                    if (HttpContext.Session.Get<CalculatorHistory>("History").Entries != null && HttpContext.Session.Get<CalculatorHistory>("History").Entries.Count > 0)
                    {
                        var prevEntry = tempHistory.FirstOrDefault();
                        rawResult = _calculator.Evaluate(calcInput, prevEntry.Result).result;
                        rawMessage = _calculator.Evaluate(calcInput, prevEntry.Message).message;
                        rawExpression = _calculator.DataService.ParseInput(prevEntry.Result, calcInput);
                    }
                }

                var result = new Result(rawResult, rawMessage);


                if (result.result.ToLower().Equals("error") || result.result.ToLower().Equals("history"))
                {
                    var expression = new Expression("", "", "");
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

                    HttpContext.Session.Set("History", new CalculatorHistory(tempHistory));
                    
                }

            }
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
    }
}
