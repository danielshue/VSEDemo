using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace Haiku.Core
{
	/// <summary>
	/// Validator validates a specified Haiku using the specified rules.
	/// Hard coded to support 3 lines only.
	/// </summary>
	public class Validator
	{
		// Really need to consider this - is it always 3?
		private string _incorrectNumLines = "The Haiku must consist of three lines. ";
		private int _correctNumLines = 3;

		public enum HaikuRules { Traditional, Western, Fibonnaci };
		public struct HaikuSummary
		{
			public string name;
			public string description;
			public HaikuRules ruleset;
		}
	   
		// aaaa

		#region Public Methods

		/// <summary>
		/// Returns the available Haiku rule sets
		/// </summary>
		/// <returns>A list of HaikuSummary rule sets</returns>
		public ArrayList getRuleSets()
		{
			ArrayList ruleSets = new ArrayList();

			// Change this to use a factory?
			HaikuSummary westernRuleSet = new HaikuSummary();
			WesternRules wRules = new WesternRules();
			westernRuleSet.name = wRules.getName();
			westernRuleSet.description = wRules.getDescription();
			westernRuleSet.ruleset = HaikuRules.Western;
			ruleSets.Add(westernRuleSet);

			HaikuSummary traditionalRuleSet = new HaikuSummary();
			TraditionalRules tRules = new TraditionalRules();
			traditionalRuleSet.name = tRules.getName();
			traditionalRuleSet.description = tRules.getDescription();
			traditionalRuleSet.ruleset = HaikuRules.Traditional;
			ruleSets.Add(traditionalRuleSet);

			HaikuSummary fibRuleSet = new HaikuSummary();
			FibonacciRules fRules = new FibonacciRules();
			fibRuleSet.name = fRules.getName();
			fibRuleSet.description = fRules.getDescription();
			fibRuleSet.ruleset = HaikuRules.Fibonnaci;
			ruleSets.Add(fibRuleSet);

			return ruleSets;
		}

		/// <summary>
		/// Validates the given Haiku using default rules.
		/// </summary>
		/// <param name="haiku">THe Haiku.</param>
		/// <returns>The results of the validation.</returns>
		public HaikuAnalysis validateHaiku(string haiku)
		{
			return validateHaiku(haiku, HaikuRules.Western);
		}

		/// <summary>
		/// Validates the given Haiku using specified rules.
		/// </summary>
		/// <param name="haiku">The Haiku</param>
		/// <param name="rules">The rules, as specified in the HaikuRules enum</param>
		/// <returns>The results of the validation.</returns>
		public HaikuAnalysis validateHaiku(string haiku, HaikuRules rules)
		{
			// FInd the number of lines
			string[] lines = Regex.Split(haiku, Environment.NewLine);
			if (lines.Length != _correctNumLines)
			{
				throw new ArgumentOutOfRangeException(_incorrectNumLines);
			}
			// Pass the three lines to validate
			return validateHaiku(lines[0], lines[1], lines[2], rules);
		}

		/// <summary>
		/// Validates the given Haiku using default rules.
		/// </summary>
		/// <param name="haikuLineOne">The first line of the Haiku.</param>
		/// <param name="haikuLineTwo">The second line of the Haiku.</param>
		/// <param name="haikuLineThree">The third line of the Haiku.</param>
		/// <returns>The results of the validation.</returns>
		public HaikuAnalysis validateHaiku(string haikuLineOne, string haikuLineTwo, string haikuLineThree)
		{
			return validateHaiku(haikuLineOne, haikuLineTwo, haikuLineThree, HaikuRules.Western);
		}

		/// <summary>
		/// Validates the given Haiku using specified rules.
		/// </summary>
		/// <param name="haikuLineOne">The first line of the Haiku.</param>
		/// <param name="haikuLineTwo">The second line of the Haiku.</param>
		/// <param name="haikuLineThree">The third line of the Haiku.</param>
		/// <param name="rules">The rules, as specified in the HaikuRules enum</param>
		/// <returns>The results of the validation.</returns>
		public HaikuAnalysis validateHaiku(string haikuLineOne, string haikuLineTwo, string haikuLineThree, HaikuRules rules)
		{
			// Get the syllables for each line
			Syllabicator syllabicator = new Syllabicator();
			// Prepare the results
			HaikuAnalysis analysis = new HaikuAnalysis();
			HaikuLineAnalysis[] lines = new HaikuLineAnalysis[_correctNumLines];
			// Count the syllables per line
			analysis.lineDetails = lines;
			lines[0].lineSyllables = syllabicator.CountSyllables(haikuLineOne);
			lines[1].lineSyllables = syllabicator.CountSyllables(haikuLineTwo);
			lines[2].lineSyllables = syllabicator.CountSyllables(haikuLineThree);

			analysis.totalSyllables = lines[0].lineSyllables + lines[1].lineSyllables + lines[2].lineSyllables;

			// Analyse the haiku
			IRules ruleset = null;
			switch (rules)
			{
				case HaikuRules.Traditional:
					ruleset = new TraditionalRules();
					break;
				case HaikuRules.Western:
					ruleset = new WesternRules();
					break;
				case HaikuRules.Fibonnaci:
					ruleset = new FibonacciRules();
					break;
				default:
					// Unlikely to get here but being good
					ruleset = new WesternRules();
					break;
			}

			return ruleset.validateHaiku(analysis);
		}
		#endregion

	}

	#region Structs

	public struct HaikuAnalysis
	{
		public bool valid;
		public int totalSyllables;
		public int totalSyllablesRequired;
		public HaikuLineAnalysis[] lineDetails;     
	}

	public struct HaikuLineAnalysis
	{
		public bool lineValid;
		public int lineSyllables;
		public int lineSyllablesRequired;
	}

	#endregion

}
