using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haiku.Core
{
    /// <summary>
    /// Represents the traditional Japanese rules for a Haiku. This only covers the 
    /// syllables per line and not other qualities such as the inclusion of a 
    /// seasonal word.
    /// </summary>
    public class TraditionalRules : BaseRules
    {
        /// <summary>
        /// Constructor that defines the traditional rules.
        /// </summary>
        public TraditionalRules()
        {
            _totalSyllables = 17;
            _lineOneSyllables = 5;
            _lineTwoSyllables = 7;
            _lineThreeSyllables = 5;

            _name = "Traditional Rules";

            // Set the description that can be used to describe this RuleSet
            _description = "The traditional Japanese rules for a Haiku. ";
            _description += "There must be a total of " + _totalSyllables + " syllables, with ";
            _description += "the first line having " + _lineOneSyllables + " syllables, ";
            _description += "the second line having " + _lineTwoSyllables + " syllables and ";
            _description += "the third line having " + _lineThreeSyllables + " syllables.";

        }
    }
}
