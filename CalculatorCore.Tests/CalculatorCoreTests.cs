using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorCore;
using System.Collections.Generic;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        Calculator calc;
        List<HistoryEntry> history;

        [TestInitialize]
        public void InitializeTests()
        {
            calc = new Calculator();
            List<HistoryEntry> history = new List<HistoryEntry>();
        }
        

        [TestMethod]
        public void AddTwoNumbers()
        {
            Result results = calc.Evaluate("6 + 8", "");
            Assert.AreEqual("Result: 14", "Result: " + results.result);
        }

        [TestMethod]
        public void SubtractTwoNumbers()
        {
            Result results = calc.Evaluate("12.5 - 7","");
            Assert.AreEqual("Result: 5.5", "Result: " + results.result);
        }

        [TestMethod]
        public void MultiplyTwoNumbers()
        {
            Result results = calc.Evaluate("5 * 7","");
            Assert.AreEqual("Result: 35", "Result: " + results.result);
        }

        [TestMethod]
        public void DivideTwoNumbers()
        {
            Result results = calc.Evaluate("48 / 8","");
            Assert.AreEqual("Result: 6", "Result: " + results.result);
        }

        [TestMethod]
        public void BadInputGetsErrorMessage()
        {
            var input = "48 pl8";
            Result results = calc.Evaluate(input,"");
            Assert.AreEqual("error", results.result);
            Assert.AreEqual("The expression " + input + " was not valid. Please enter a valid binomial expression in the form '6.9 + 5': ", results.message);
        }
    }
}
