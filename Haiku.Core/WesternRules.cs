using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haiku.Core
{
    /// <summary>
    /// Rules based on the accepted Western number of syllables, judged to be equivalent to the 
    /// traditional Japanese number of syllables.
    /// </summary>
    public class WesternRules : BaseRules
    {

        /// <summary>
        /// Constructor to define the Western rules.
        /// </summary>
        public WesternRules()
        {
            _totalSyllables = 11;
            _lineOneSyllables = 3;
            _lineTwoSyllables = 5;
            _lineThreeSyllables = 3;

            _name = "Western Rules";

            // Set the description that can be used to describe this RuleSet
            _description = "The accepted Western number of syllables, judged to be equivalent to the traditional Japanese number of syllables. ";
            _description += "There must be a total of " + _totalSyllables + " syllables, with ";
            _description += "the first line having " + _lineOneSyllables + " syllables, ";
            _description += "the second line having " + _lineTwoSyllables + " syllables and ";
            _description += "the third line having " + _lineThreeSyllables + " syllables.";
 
        }
    }
}
