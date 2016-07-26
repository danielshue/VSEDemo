using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Haiku.Core;
using System.Collections;

namespace Haiku.Utils
{

    [Serializable()]
    public class InvalidHaikuException : System.Exception
    {
        public InvalidHaikuException() : base() { }
        public InvalidHaikuException(string message) : base(message) { }
        public InvalidHaikuException(string message, System.Exception inner) : base(message, inner) { }

        // Constructor needed for serialization 
        // when exception propagates from a remoting server to the client. 
        protected InvalidHaikuException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }


    public class Proxy
    {
        public Proxy()
        {
            setRuleSets();
        }
        
        private ArrayList theRuleSets = null;
        private string selectedRuleSet = null;

        private void setRuleSets()
        {
            Validator val = new Validator();
            theRuleSets = val.getRuleSets();

            for (int i = 0; i < theRuleSets.Count; i++)
            {
                Validator.HaikuSummary summary = (Validator.HaikuSummary)theRuleSets[i];
            }
            selectedRuleSet = new Preferences().getRuleSet();
        }

        public string[] getRuleNames()
        {
            string[] names = new string[theRuleSets.Count];
            for (int i = 0; i < theRuleSets.Count; i++)
            {
                Validator.HaikuSummary summary = (Validator.HaikuSummary)theRuleSets[i];
                names[i] = summary.name;
            }
            return names;
        }

        public string getRuleDescription(int rule)
        {
            Validator.HaikuSummary summary = (Validator.HaikuSummary)theRuleSets[rule];
            return summary.description;
        }

        public int getSelectedRuleSet()
        {
            int rule = 0;

            for (int i = 0; i < theRuleSets.Count; i++)
            {
                Validator.HaikuSummary summary = (Validator.HaikuSummary)theRuleSets[i];
                if (summary.name.Equals(selectedRuleSet))
                {
                    rule = i;
                }
            }
            return rule;
        }

        public void setSelectedRuleSet(int rule)
        {
            Validator.HaikuSummary summary = (Validator.HaikuSummary)theRuleSets[rule];
            new Preferences().setRuleSet(summary.name);
        }
        
        /// <summary>
        /// Validates a string as a Haiku.
        /// </summary>
        /// <param name="candidateHaiku">The string to be evaluated as a Haiku</param>
        /// <returns></returns>
        // To Do: Throw exception for invalid Haiku
        public string Validate(string candidateHaiku)
        {
            // Determine the rule set type. For now we assume the Western rules
            // To Do: Determine rules as set in settings
            return this.Validate(candidateHaiku, Validator.HaikuRules.Western);
        }

        /// <summary>
        /// Validates a string as a Haiku.
        /// </summary>
        /// <param name="candidateHaiku">The string to be evaluated as a Haiku</param>
        /// <param name="rule">The index of the selected rule </param>
        /// <returns></returns>
        // To Do: Throw exception for invalid Haiku
        public string Validate(string candidateHaiku, int rule)
        {
            Validator.HaikuSummary summary = (Validator.HaikuSummary)theRuleSets[rule];
            return this.Validate(candidateHaiku, summary.ruleset);
        }

        /// <summary>
        /// Validates a string as a Haiku.
        /// </summary>
        /// <param name="candidateHaiku">The string to be evaluated as a Haiku</param>
        /// <param name="rule">The rule set to be used for the evaluation </param>
        /// <returns></returns>
        // To Do: Throw exception for invalid Haiku
        private string Validate(string candidateHaiku, Validator.HaikuRules rule)
        {
            string linePrefix = "Line ";
            string lineValid = " is valid. " + Environment.NewLine;
            string lineInvalid = " is invalid with ";
            string lineSyllables = " syllables instead of ";
            string explanation = "Valid." + Environment.NewLine;

            // Validate the comment
            // To Do: Determine rules as set in settings
            HaikuAnalysis analysis = new Validator().validateHaiku(candidateHaiku, rule);

            // Examine the results
            if (analysis.valid == false)
            {

                explanation = "Invalid." + Environment.NewLine;
                for (int i = 0; i < analysis.lineDetails.Length; i++)
                {
                    if (analysis.lineDetails[i].lineValid)
                    {
                        explanation += linePrefix + (i + 1) + lineValid;
                    }
                    else
                    {
                        explanation += linePrefix + (i + 1) + lineInvalid + analysis.lineDetails[i].lineSyllables + lineSyllables + analysis.lineDetails[i].lineSyllablesRequired + ". " + Environment.NewLine;
                    }
                }
                throw new InvalidHaikuException(explanation);
            }

            return explanation;
        }
    }
}
