using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Haiku.Core;

namespace Haiku.Utils.UnitTests
{
    [TestClass]
    public class UtilsUnitTests
    {
        [TestMethod]
        public void GetRuleNamesTest()
        {
            Proxy p = new Proxy();
            string[] actual = p.getRuleNames();
            string[] expected = { "Western Rules", "Traditional Rules", "Fibonacci Rules" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWesternRulesDescriptionTest()
        {
            Proxy p = new Proxy();
            Assert.AreEqual(p.getRuleDescription(0), new WesternRules().getDescription());
        }

        [TestMethod]
        public void GetTraditionalRulesDescriptionTest()
        {
            Proxy p = new Proxy();
            Assert.AreEqual(p.getRuleDescription(1), new TraditionalRules().getDescription());            
        }

        [TestMethod]
        public void GetFibonacciRulesDescriptionTest()
        {
            Proxy p = new Proxy();
            Assert.AreEqual(p.getRuleDescription(2), new FibonacciRules().getDescription());
        }

    }
}
