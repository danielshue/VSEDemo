using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Haiku.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Haiku.Core.UnitTests
{
    /// <summary>
    /// Test to check that syllables can be determined from strings.
    /// The Syllabication rules to be used are: 
    /// V CV VC CVC CCV CCCV CVCC
    /// </summary>
    [TestClass]
    public class SyllabicationUnitTests
    {
        public SyllabicationUnitTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void VWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "a";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VWord2TestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "b";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VWord3TestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "c";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VWord4TestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "d";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VWord5TestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "e";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CVWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "no";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VCWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "an";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CVCWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "top";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CCVWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "bra";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CCCVWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "ntha";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CVCCWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "pect";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OneSylWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "theaskdj";
            int expected = 1;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoSylWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "dustbin";
            int expected = 2;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeSylWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "syllable";
            int expected = 3;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourSylWordTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "unbreakable";
            int expected = 4;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeSylLineOneSentenceTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "stony sand";
            int expected = 3;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FiveSylLineTwoSentenceTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "coming and going";
            int expected = 5;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeSylLineThreeSentenceTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "winter waves";
            int expected = 3;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FiveSylLineOneSentenceTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "The red blossom bends";
            int expected = 5;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SevenSylLineTwoSentenceTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "and drips its dew to the ground";
            int expected = 7;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FiveSylLineThreeSentenceTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "Like a tear it falls";
            int expected = 5;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WesternHaikuTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "beach pebble" + Environment.NewLine; // 3 syls
            theWord += "round with its years" + Environment.NewLine; // 4 syls
            theWord += "in the making"; //4 syls
            int expected = 11;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TraditionalHaikuTestMethod()
        {
            Syllabicator syl = new Syllabicator();
            string theWord = "Curving up, then down." + Environment.NewLine; // 5 syls
            theWord += "Meeting blue sky and green earth" + Environment.NewLine; // 7 syls
            theWord += "Melding sun and rain"; // 5 syls
            int expected = 17;
            int actual = syl.CountSyllables(theWord);
            Assert.AreEqual(expected, actual);
        }
    }
}
