using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haiku.Core
{
    /// <summary>
    /// This class provides the base class for all Haiku rules. It provides a virtual method that implements
    /// the validation of a Haiku based on the numbers of syllables defined in the specific rules.
    /// </summary>
    public class BaseRules : IRules
    {
        /// <summary>
        /// These properties are intended to be overridden in the specific Rules implementation
        /// </summary>
        protected int _totalSyllables, _lineOneSyllables, _lineTwoSyllables, _lineThreeSyllables;
        protected string _description, _name;

        /// <summary>
        /// Validates the provided Haiku according to the rules of this class
        /// </summary>
        /// <param name="analysis">The HaikuAnalysis populated with the stats for the Haiku.</param>
        /// <returns>The HaikuAnalysis populated with the results of the rules applied to the stats.</returns>
        public virtual HaikuAnalysis validateHaiku(HaikuAnalysis analysis)
        {
            // Set the number of syllables found in each line
            analysis.lineDetails[0].lineSyllablesRequired = _lineOneSyllables;
            analysis.lineDetails[1].lineSyllablesRequired = _lineTwoSyllables;
            analysis.lineDetails[2].lineSyllablesRequired = _lineThreeSyllables;
            
            // Assume the Haiku is valid
            analysis.valid = true;

            // For each line
            for (int i = 0; i < analysis.lineDetails.Length; i++)
            {
                // It's valid if the number of syllables equals the required number
                analysis.lineDetails[i].lineValid = (analysis.lineDetails[i].lineSyllablesRequired == analysis.lineDetails[i].lineSyllables);
                // If this line is invalid, the whole Haiku is invalid
                if (analysis.lineDetails[i].lineValid == false)
                {
                    analysis.valid = false;
                }
            }

            analysis.totalSyllablesRequired = _totalSyllables;
            
            return analysis;
        }

        /// <summary>
        /// Returns the textual name of this ruleset (set in the inheriting class)
        /// </summary>
        /// <returns>The name of the ruleset</returns>
        public string getName()
        {
            return _name;
        }

        /// <summary>
        /// Returns the descirption of this ruleset (set in the inheriting class)
        /// </summary>
        /// <returns>The description of the ruleset</returns>
        public string getDescription()
        {
            return _description;
        }


    }
}
