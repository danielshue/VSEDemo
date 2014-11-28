using System;
using Haiku.Utils;
using Haiku.Core;
using NUnit.Framework;

namespace Haiku.Utils.UnitTests
{
    [TestFixture]
    public class ProxyTest
    {
        [Test]
        public void GetRuleNamesTest()
        {
            Proxy p = new Proxy();
            string[] actual = p.getRuleNames();
            string[] expected = {"Western Rules", "Traditional Rules","Fibonacci Rules"};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetRuleDescriptionTest()
        {
            Proxy p = new Proxy();
            Assert.That(p.getRuleDescription(0), Is.EqualTo(new WesternRules().getDescription()));
            Assert.That(p.getRuleDescription(1), Is.EqualTo(new TraditionalRules().getDescription()));
            Assert.That(p.getRuleDescription(2), Is.EqualTo(new FibonacciRules().getDescription()));
        }

        [Test]
        public void ValidateInvalidHaikuTest()
        {
            Proxy p = new Proxy();
            Assert.Throws<ArgumentOutOfRangeException>( () => p.Validate("Not a valid Haiku"));
            Assert.Throws<InvalidHaikuException>(() => p.Validate("Not" + Environment.NewLine + "valid" + Environment.NewLine + "Haiku"));
        }


    }
}
