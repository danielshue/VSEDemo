using System;
using Haiku.Utils;
using Xunit;

namespace Haiku.Misc.UnitTests
{
    
    public class MiscTests
    {
        [Fact]
        public void GetRuleSetTest()
        {
            Preferences p = new Preferences();
            string expected = "Western Rules";
            string actual = p.getRuleSet();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExceptionOnInvalidHaikuTest()
        {
            Proxy p = new Proxy();
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Validate("An invalid Haiku"));
            Assert.Throws<InvalidHaikuException>(() => p.Validate("Another" + Environment.NewLine + "invalid" + Environment.NewLine + "Haiku"));
        }
    }
}
