using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace Haiku.Core
{
    /// <summary>
    /// This class is responsible for counting the syllables in a given piece of text.
    /// </summary>
    public class Syllabicator
    {
        private char[] _vowels = {'a','e','i','o','u','y'}; // Found that I need to treat y as a vowel
        private char[] _consonants = {'b','c','d','e','f','g','h','j','k','l','m','n','p','q','r','s','t','v','w','x','z'};
        private string _vowelSymbol = "V";
        private string _consonantSymbol = "C";
        private Regex _V_Syllable = new Regex("[V]");
        private Regex _CV_Syllable = new Regex("[C][V]");
        private Regex _VC_Syllable = new Regex("[V][C]");
        private Regex _CVC_Syllable = new Regex("[C][V][C]");
        private Regex _CCV_Syllable = new Regex("[C][C][V]");
        private Regex _CCCV_Syllable = new Regex("[C][C][C][V]");
        private Regex _CVCC_Syllable = new Regex("[C][V][C][C]");
        private Regex _CCVV_Syllable = new Regex("[C][C][V][V]");
        private Regex _CVVC_Syllable = new Regex("[C][V][V][C]");
        private Regex _CVCV_Syllable = new Regex("[C][V][C][V]");
        private Regex _VVCCC_Syllable = new Regex("[V][V][C][C][C]");
        private Regex _VVV_Syllable = new Regex("[V][V][V]");
        
        /// <summary>
        /// Count the numnber of syllables in the provided text.
        /// </summary>
        /// <param name="text">The text to have it's syllables counted.</param>
        /// <returns>The number of syllables in the text.</returns>
        public int CountSyllables(string text)
        {
            // break out the words in the text
            ArrayList words = chunkIntoWords(text);
            // Count the syllables in each word
            int totalSyllables = 0;
            for (int i = 0; i < words.Count; i++)
            {
                totalSyllables += numSyllables((string)words[i]); 
            }

            return totalSyllables;
        }

        #region Private Methods

        /// <summary>
        /// Utility method to extract the words in the text so that the syllables are
        /// only counted for each word.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>An ArrayList of words.</returns>
        private ArrayList chunkIntoWords(string text)
        {
            ArrayList words = new ArrayList();

            // Convert to lowercase to avoid case issues
            text = text.ToLower();
            // Strip off whitespaces
            text = text.Trim();

            // First make sure we're not confused by any new lines
            string[] lines = Regex.Split(text, Environment.NewLine);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] theWords = Regex.Split(lines[i], " ");
                words.AddRange(theWords);    
            }

            return words; 
        }

        public void aMethod()
        {
            Console.WriteLine("");
        }

        /// <summary>
        /// Utility method to count the number of syllables in a single word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>The number of syllables in the word.</returns>
        private int numSyllables(string word)
        {
            int syllables = 0;
            // Easy one - if it's 1, 2 or 3 letters long, there's only one syllable
            int letters = word.Length;
            switch (letters)
            {
                case 0:             // should never happen
                    syllables = 0;
                    break;
                case 1:
                    syllables = 1;
                    break;
                case 2:
                    syllables = 1;
                    break;
                case 3:
                    syllables = 1;
                    break;
                default:
                    // A funny - need to look for words ending in "ing" - I haven't got an adequate pattern yet.
                    string suffix = word.Substring(word.Length - 3);
                    if (suffix.Equals("ing"))
                    {
                        // One syllable for the "ing"
                        syllables = 1;
                        int anint = 3;
                        // Find the remaining syllables
                        string prefix = word.Substring(0, word.Length - 3);
                        syllables += findSyllables(convertToSymbols(prefix));
                    }
                    else
                    {
                        syllables = findSyllables(convertToSymbols(word));
                    }
                    // A funny - if the word ends in an s, then if there is > 1 syllable, deduct 1
                    if ((word[word.Length - 1].Equals('s')) && (syllables > 1))
                    {
                        syllables = syllables - 1;
                    }
                    break;
            }
            return syllables;
            
        }

        /// <summary>
        /// Utility method to find the number of syllables given a symbolic string.
        /// </summary>
        /// <param name="symbolic">A string consisting of either Vs or Cs (Vowels or Consonents)</param>
        /// <returns>The number of syllables in the symbolic string.</returns>
        private int findSyllables(string symbolic)
        {
            //TO DO wider range of unit tests
            // V CV VC CVC CCV CCCV CVCC
            // Mine
            // CCVV CVVC (bear) CVCV (like) VVCCC (earth) VVV 
            int syllables = 0;
            // e.g. another = V CVCC VC
            // e.g. dustbin = CVCC CVC
            // e.g. unbreakable = VC CCVV CV CCV
            //coming and going
            //CVCVCC VCC CVVCC
            
            // Try the longest patterns first - more likely to be correct
            int syllableStart = 0;

            if (isSyllable(symbolic, syllableStart, 5, _VVCCC_Syllable)) // VVCCC Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 5;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            } 
            if (isSyllable(symbolic, syllableStart, 4, _CVCC_Syllable)) // CVCC Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 4;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 4, _CCCV_Syllable)) // CCCV Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 4;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 4, _CCVV_Syllable)) // CCVV Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 4;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 4, _CVVC_Syllable)) // CVVC Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 4;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 4, _CVCV_Syllable)) // CVCV Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 4;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 3, _CCV_Syllable)) // CCV Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 3;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 3, _CVC_Syllable)) // CVC Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 3;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 3, _VVV_Syllable)) // VVV Test, e.g. yea rs
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 3;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 2, _VC_Syllable)) // VC Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 2;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 2, _CV_Syllable)) // CV Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 2;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else if (isSyllable(symbolic, syllableStart, 1, _V_Syllable)) // V Test
            {
                // We've got a new syllable
                syllables++;
                // Reset the start of the next syllable
                syllableStart += 1;
                syllables += findSyllables(symbolic.Substring(syllableStart));
            }
            else
            {
                // No more valid syllables
            }

            // V is easy to find but may be an independent syllable or not - do last
            return syllables;
        }

        /// <summary>
        /// Utility method to determine if a given substring matches a syllable pattern.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="start">Start of a substring within the word.</param>
        /// <param name="length">The length of the substring within the word.</param>
        /// <param name="regex">The regular expression to match.</param>
        /// <returns></returns>
        private bool isSyllable(string word, int start, int length, Regex regex)
        {
            // If the looked for syllable expression is longer than the work then it must be false
            if ((start + length) > word.Length || length > word.Length)
            {
                return false;
            }
            string candidate = word.Substring(start, length);
            Match match = regex.Match(candidate);
            return match.Success;
        }

        /// <summary>
        /// Utility method to convert a normal word to symbols representing vowels and constonants.
        /// </summary>
        /// <param name="word">The word</param>
        /// <returns>The symbolic representation of the word.</returns>
        private string convertToSymbols(string word)
        {
            string pattern = "";

            for (int i = 0; i < word.Length; i++)
            {
                pattern += getSymbol(word[i]);
            }

            return pattern;
        }

        /// <summary>
        /// Utility method to convert an individual letter to a symbolic representation.
        /// </summary>
        /// <param name="letter">The letter.</param>
        /// <returns>The symoblic representation.</returns>
        private string getSymbol(char letter)
        {
            string symbol = "";
            if (_vowels.Contains(letter))
            {
                symbol = _vowelSymbol;
            }
            else
            {
                symbol = _consonantSymbol;
            }
            return symbol;
        }
        #endregion


    }
}
