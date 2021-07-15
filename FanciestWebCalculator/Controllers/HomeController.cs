using FanciestWebCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FanciestWebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = new CalculatorStateModel();

            if (HttpContext.Session.Get<CalculatorHistory>("Entries") != null)
            {
                vm.History = HttpContext.Session.Get<CalculatorHistory>("Entries");
                vm.PreviousEntry = HttpContext.Session.Get<HistoryEntry>("PreviousEntry");
            }
            else {
                vm.History = new CalculatorHistory();
                vm.PreviousEntry = new HistoryEntry("0","",new Expression("","",""));
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(string input)
        {
            //if input is valid
                //need a boolean in Calculator that generally checks this and sends message
            //create expression
            //evaluate expression
            //create history entry
            //add history entry to list
            //update history and previous entry in session
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
