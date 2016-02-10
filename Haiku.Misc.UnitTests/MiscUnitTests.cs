using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Haiku.Utils;

namespace Haiku.Misc.UnitTests
{
    [TestClass]
    public class MiscUnitTests
    {
        [TestMethod]
        public void GetRuleSetTest()
        {
            Preferences p = new Preferences();
            string expected = "Western Rules";
            string actual = p.getRuleSet();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionOnInvalidOneLineHaikuTest()
        {
            Proxy p = new Proxy();
            p.Validate("An invalid Haiku");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionOnInvalidTwoLineHaikuTest()
        {
            Proxy p = new Proxy();
            p.Validate("Invalid" + Environment.NewLine + "Haiku");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidHaikuException))]
        public void ExceptionOnInvalidThreeLineHaikuTest()
        {
            Proxy p = new Proxy();
            p.Validate("Another" + Environment.NewLine + "invalid" + Environment.NewLine + "Haiku");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionOnInvalidFourLineHaikuTest()
        {
            Proxy p = new Proxy();
            p.Validate("Another" + Environment.NewLine + "invalid" + Environment.NewLine + "Haiku" + Environment.NewLine + "Line4");
        }
    }
}
