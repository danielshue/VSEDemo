using Haiku.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Haiku.Core.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for ValidatorTest and is intended
    ///to contain all ValidatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ValidatorUnitTests
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for vaildateHaiku
        ///</summary>
        [TestMethod()]
        public void vaildateHaikuTest()
        {
            Validator target = new Validator();
            string haiku = "Many people" + Environment.NewLine;
            haiku += "in the big office" + Environment.NewLine;
            haiku += "to learn tfs";
            HaikuAnalysis expected = new HaikuAnalysis();
            HaikuLineAnalysis[] linesExpected = new HaikuLineAnalysis[3];
            linesExpected[0].lineSyllables = 3;
            linesExpected[0].lineSyllablesRequired = 3;
            linesExpected[0].lineValid = true;
            linesExpected[1].lineSyllables = 5;
            linesExpected[1].lineSyllablesRequired = 5;
            linesExpected[1].lineValid = true;
            linesExpected[2].lineSyllables = 3;
            linesExpected[2].lineSyllablesRequired = 3;
            linesExpected[2].lineValid = true;
            expected.lineDetails = linesExpected;
            expected.totalSyllables = 11;
            expected.totalSyllablesRequired = 11;
            expected.valid = true;

            HaikuAnalysis actual;
            actual = target.validateHaiku(haiku);
            Assert.AreEqual(expected.valid, actual.valid);
            Assert.AreEqual(expected.totalSyllables, actual.totalSyllables);
            Assert.AreEqual(expected.totalSyllablesRequired, actual.totalSyllablesRequired);
            CollectionAssert.AreEqual(expected.lineDetails, actual.lineDetails);
        }

        /// <summary>
        ///A test for validateHaiku
        ///</summary>
        [TestMethod()]
        public void validateHaikuLinesTest()
        {
            Validator target = new Validator();
            string haikuLineOne = "Many people";
            string haikuLineTwo = "in the big office";
            string haikuLineThree = "to learn tfs";
            HaikuAnalysis expected = new HaikuAnalysis();
            HaikuLineAnalysis[] linesExpected = new HaikuLineAnalysis[3];
            linesExpected[0].lineSyllables = 3;
            linesExpected[0].lineSyllablesRequired = 3;
            linesExpected[0].lineValid = true;
            linesExpected[1].lineSyllables = 5;
            linesExpected[1].lineSyllablesRequired = 5;
            linesExpected[1].lineValid = true;
            linesExpected[2].lineSyllables = 3;
            linesExpected[2].lineSyllablesRequired = 3;
            linesExpected[2].lineValid = true;
            expected.lineDetails = linesExpected;
            expected.totalSyllables = 11;
            expected.totalSyllablesRequired = 11;
            expected.valid = true;

            HaikuAnalysis actual;
            actual = target.validateHaiku(haikuLineOne, haikuLineTwo, haikuLineThree);
            Assert.AreEqual(expected.valid, actual.valid);
            Assert.AreEqual(expected.totalSyllables, actual.totalSyllables);
            Assert.AreEqual(expected.totalSyllablesRequired, actual.totalSyllablesRequired);
            CollectionAssert.AreEqual(expected.lineDetails, actual.lineDetails);
        }

        /// <summary>
        ///A test for validateHaiku
        ///</summary>
        [TestMethod()]
        public void validateHaikuLinesAndRulesTest()
        {
            Validator target = new Validator();
            string haikuLineOne = "Many people";
            string haikuLineTwo = "in the big office";
            string haikuLineThree = "to learn tfs";
            Validator.HaikuRules rules = Validator.HaikuRules.Western;
            HaikuAnalysis expected = new HaikuAnalysis();
            HaikuLineAnalysis[] linesExpected = new HaikuLineAnalysis[3];
            linesExpected[0].lineSyllables = 3;
            linesExpected[0].lineSyllablesRequired = 3;
            linesExpected[0].lineValid = true;
            linesExpected[1].lineSyllables = 5;
            linesExpected[1].lineSyllablesRequired = 5;
            linesExpected[1].lineValid = true;
            linesExpected[2].lineSyllables = 3;
            linesExpected[2].lineSyllablesRequired = 3;
            linesExpected[2].lineValid = true;
            expected.lineDetails = linesExpected;
            expected.totalSyllables = 11;
            expected.totalSyllablesRequired = 11;
            expected.valid = true;
            
            HaikuAnalysis actual;
            actual = target.validateHaiku(haikuLineOne, haikuLineTwo, haikuLineThree, rules);
            Assert.AreEqual(expected.valid, actual.valid);
            Assert.AreEqual(expected.totalSyllables, actual.totalSyllables);
            Assert.AreEqual(expected.totalSyllablesRequired, actual.totalSyllablesRequired);
            CollectionAssert.AreEqual(expected.lineDetails, actual.lineDetails);
        }

        /// <summary>
        ///A test for validateHaiku
        ///</summary>
        [TestMethod()]
        public void validateHaikuNoLinesAndRulesTest()
        {
            Validator target = new Validator();
            string haiku = "Many people" + Environment.NewLine;
            haiku += "in the big office" + Environment.NewLine;
            haiku += "to learn tfs";
            Validator.HaikuRules rules = Validator.HaikuRules.Western;
            HaikuAnalysis expected = new HaikuAnalysis();
            HaikuLineAnalysis[] linesExpected = new HaikuLineAnalysis[3];
            linesExpected[0].lineSyllables = 3;
            linesExpected[0].lineSyllablesRequired = 3;
            linesExpected[0].lineValid = true;
            linesExpected[1].lineSyllables = 5;
            linesExpected[1].lineSyllablesRequired = 5;
            linesExpected[1].lineValid = true;
            linesExpected[2].lineSyllables = 3;
            linesExpected[2].lineSyllablesRequired = 3;
            linesExpected[2].lineValid = true;
            expected.lineDetails = linesExpected;
            expected.totalSyllables = 11;
            expected.totalSyllablesRequired = 11;
            expected.valid = true;

            HaikuAnalysis actual;
            actual = target.validateHaiku(haiku, rules);
            Assert.AreEqual(expected.valid, actual.valid);
            Assert.AreEqual(expected.totalSyllables, actual.totalSyllables);
            Assert.AreEqual(expected.totalSyllablesRequired, actual.totalSyllablesRequired);
            CollectionAssert.AreEqual(expected.lineDetails, actual.lineDetails);
        }

        /// <summary>
        ///A test for validateHaiku
        ///</summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ValidHaikus.csv", "ValidHaikus#csv", DataAccessMethod.Sequential), DeploymentItem("Haiku.Core.UnitTests\\ValidHaikus.csv"), TestMethod()]
        public void dataDrivenWesternHaikuLinesAndRulesTest()
        {
            Validator target = new Validator();
            string haikuLineOne = System.Convert.ToString(TestContext.DataRow["Line1"]);
            string haikuLineTwo = System.Convert.ToString(TestContext.DataRow["Line2"]);
            string haikuLineThree = System.Convert.ToString(TestContext.DataRow["Line3"]);
            Validator.HaikuRules rules = Validator.HaikuRules.Western;
            HaikuAnalysis expected = new HaikuAnalysis();
            HaikuLineAnalysis[] linesExpected = new HaikuLineAnalysis[3];
            linesExpected[0].lineSyllables = 3;
            linesExpected[0].lineSyllablesRequired = 3;
            linesExpected[0].lineValid = true;
            linesExpected[1].lineSyllables = 5;
            linesExpected[1].lineSyllablesRequired = 5;
            linesExpected[1].lineValid = true;
            linesExpected[2].lineSyllables = 3;
            linesExpected[2].lineSyllablesRequired = 3;
            linesExpected[2].lineValid = true;
            expected.lineDetails = linesExpected;
            expected.totalSyllables = 11;
            expected.totalSyllablesRequired = 11;
            expected.valid = true;

            HaikuAnalysis actual;
            actual = target.validateHaiku(haikuLineOne, haikuLineTwo, haikuLineThree, rules);
            Assert.AreEqual(expected.valid, actual.valid);
            Assert.AreEqual(expected.totalSyllables, actual.totalSyllables);
            Assert.AreEqual(expected.totalSyllablesRequired, actual.totalSyllablesRequired);
            CollectionAssert.AreEqual(expected.lineDetails, actual.lineDetails);
        }

        /// <summary>
        ///A test for validateHaiku
        ///</summary>
        [DeploymentItem("Haiku.Core.UnitTests\\ValidTraditionalHaikus.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ValidTraditionalHaikus.csv", "ValidTraditionalHaikus#csv", DataAccessMethod.Sequential), TestMethod()]
        public void dataDrivenTraditionalHaikuLinesAndRulesTest()
        {
            Validator target = new Validator();
            string haikuLineOne = System.Convert.ToString(TestContext.DataRow["Line1"]);
            string haikuLineTwo = System.Convert.ToString(TestContext.DataRow["Line2"]);
            string haikuLineThree = System.Convert.ToString(TestContext.DataRow["Line3"]);
            Validator.HaikuRules rules = Validator.HaikuRules.Traditional;
            HaikuAnalysis expected = new HaikuAnalysis();
            HaikuLineAnalysis[] linesExpected = new HaikuLineAnalysis[3];
            linesExpected[0].lineSyllables = 5;
            linesExpected[0].lineSyllablesRequired = 5;
            linesExpected[0].lineValid = true;
            linesExpected[1].lineSyllables = 7;
            linesExpected[1].lineSyllablesRequired = 7;
            linesExpected[1].lineValid = true;
            linesExpected[2].lineSyllables = 5;
            linesExpected[2].lineSyllablesRequired = 5;
            linesExpected[2].lineValid = true;
            expected.lineDetails = linesExpected;
            expected.totalSyllables = 17;
            expected.totalSyllablesRequired = 17;
            expected.valid = true;

            HaikuAnalysis actual;
            actual = target.validateHaiku(haikuLineOne, haikuLineTwo, haikuLineThree, rules);
            Assert.AreEqual(expected.valid, actual.valid);
            Assert.AreEqual(expected.totalSyllables, actual.totalSyllables);
            Assert.AreEqual(expected.totalSyllablesRequired, actual.totalSyllablesRequired);
            CollectionAssert.AreEqual(expected.lineDetails, actual.lineDetails);
        }

        /// <summary>
        ///A test for validateHaiku
        ///</summary>
        [DeploymentItem("Haiku.Core.UnitTests\\ValidFibonacciHaikus.csv"), DeploymentItem("HaikuTestProject\\ValidTraditionalHaikus.csv"), DeploymentItem("HaikuTestProject\\ValidHaikus.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\ValidFibonacciHaikus.csv", "ValidFibonacciHaikus#csv", DataAccessMethod.Sequential), TestMethod()]
        public void dataDrivenFibonnaciHaikuLinesAndRulesTest()
        {
            Validator target = new Validator();
            string haikuLineOne = System.Convert.ToString(TestContext.DataRow["Line1"]);
            string haikuLineTwo = System.Convert.ToString(TestContext.DataRow["Line2"]);
            string haikuLineThree = System.Convert.ToString(TestContext.DataRow["Line3"]);
            Validator.HaikuRules rules = Validator.HaikuRules.Fibonnaci;
            HaikuAnalysis expected = new HaikuAnalysis();
            HaikuLineAnalysis[] linesExpected = new HaikuLineAnalysis[3];
            linesExpected[0].lineSyllables = 3;
            linesExpected[0].lineSyllablesRequired = 3;
            linesExpected[0].lineValid = true;
            linesExpected[1].lineSyllables = 5;
            linesExpected[1].lineSyllablesRequired = 5;
            linesExpected[1].lineValid = true;
            linesExpected[2].lineSyllables = 8;
            linesExpected[2].lineSyllablesRequired = 8;
            linesExpected[2].lineValid = true;
            expected.lineDetails = linesExpected;
            expected.totalSyllables = 16;
            expected.totalSyllablesRequired = 16;
            expected.valid = true;

            HaikuAnalysis actual;
            actual = target.validateHaiku(haikuLineOne, haikuLineTwo, haikuLineThree, rules);
            Assert.AreEqual(expected.valid, actual.valid);
            Assert.AreEqual(expected.totalSyllables, actual.totalSyllables);
            Assert.AreEqual(expected.totalSyllablesRequired, actual.totalSyllablesRequired);
            CollectionAssert.AreEqual(expected.lineDetails, actual.lineDetails);
        }


        /// <summary>
        ///A test for validateHaiku
        ///</summary>
        [TestMethod()]
        public void validateHaikuNoLinesAndFibonacciRulesTest()
        {
            Validator target = new Validator();
            string haiku = "Check code in" + Environment.NewLine; //3
            haiku += "version control" + Environment.NewLine; //5
            haiku += "project is now safe and secure"; //8
            Validator.HaikuRules rules = Validator.HaikuRules.Fibonnaci;
            HaikuAnalysis expected = new HaikuAnalysis();
            HaikuLineAnalysis[] linesExpected = new HaikuLineAnalysis[3];
            linesExpected[0].lineSyllables = 3;
            linesExpected[0].lineSyllablesRequired = 3;
            linesExpected[0].lineValid = true;
            linesExpected[1].lineSyllables = 5;
            linesExpected[1].lineSyllablesRequired = 5;
            linesExpected[1].lineValid = true;
            linesExpected[2].lineSyllables = 8;
            linesExpected[2].lineSyllablesRequired = 8;
            linesExpected[2].lineValid = true;
            expected.lineDetails = linesExpected;
            expected.totalSyllables = 16;
            expected.totalSyllablesRequired = 16;
            expected.valid = true;

            HaikuAnalysis actual;
            actual = target.validateHaiku(haiku, rules);
            Assert.AreEqual(expected.valid, actual.valid);
            Assert.AreEqual(expected.totalSyllables, actual.totalSyllables);
            Assert.AreEqual(expected.totalSyllablesRequired, actual.totalSyllablesRequired);
            CollectionAssert.AreEqual(expected.lineDetails, actual.lineDetails);
        }

    }
}
