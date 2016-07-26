using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haiku.Core
{
    /// <summary>
    /// An implementation of the Haiku Rules that uses the Fibonacci series as the 
    /// number of syllables in each line of the Haiku, based on a seed number.
    /// 
    /// Note that this class only exists to show a truly horrendous single method - 
    /// high levels of cyclomatic complexity, large number of lines etc..
    /// This deliberately will show up badly in Code Metrics.
    /// </summary>
    public class FibonacciRules : BaseRules
    {

        /// <summary>
        /// Constructor that initialises this class with the correct rules.
        /// </summary>
        public FibonacciRules()
        {
            _name = "Fibonacci Rules";
            
            // For now we'll start at the 4th number (0 based)
            int[] syllables = getThreeNumbersFromSequence(4);
            
            _lineOneSyllables = syllables[0];
            _lineTwoSyllables = syllables[1];
            _lineThreeSyllables = syllables[2];
            _totalSyllables = _lineOneSyllables + _lineTwoSyllables + _lineThreeSyllables;

            // Set the description that can be used to describe this RuleSet
            _description = "This is an implementation of the Haiku rules that uses the Fibonacci series as the number of syllables in each line of the Haiku. ";
            _description += "There must be a total of " + _totalSyllables + " syllables, with ";
            _description += "the first line having " + _lineOneSyllables + " syllables, ";
            _description += "the second line having " + _lineTwoSyllables + " syllables and ";
            _description += "the third line having " + _lineThreeSyllables + " syllables.";
            
        }

        #region Private Methods

        private int[] getThreeNumbersFromSequence(int startPosition)
        {
            int[] lineSyllables = new int[3];
            // Bit of a kludge, but get the first 30 numbers from the sequence
            int[] fullSequence = getFibonacciNumbers(20, false, false);
            // Then get the three numbers in sequence from the starting position
            for (int i = startPosition; i < startPosition + 3; i++)
            {
                lineSyllables[i - startPosition] = fullSequence[i];
            }
            return lineSyllables;
        }

        /* 
        * The Fibonacci numbers are a sequence of numbers named after Leonardo of Pisa, known as Fibonacci 
        * (a contraction of filius Bonaccio, "son of Bonaccio").
        * The first number of the sequence is 0, the second number is 1, and each subsequent number is equal 
        * to the sum of the previous two numbers of the sequence itself, yielding 
        * the sequence 0, 1, 1, 2, 3, 5, 8, etc.
        */
        private int[] getFibonacciNumbers(int number, bool total, bool reverse)
        {
            const int SEQUENCE_START = 0;
            const int SEQUENCE_ONE = 1;
            int sequence_length = number;
            int[] fibonacciSequence = new int[sequence_length];
            int previousSum = 0;
            int sum = 0;

            //Basic validation

            if (number > 0)
            {

                for (int i = SEQUENCE_START; i < sequence_length; i++)
                {
                    switch (i)
                    {

                        case SEQUENCE_START:
                            // Always start with zero
                            if (reverse && total && number > 0)
                            {
                                fibonacciSequence[sequence_length - i] = SEQUENCE_START;
                                if (sum < 0)
                                {
                                    sum = 0;
                                }
                                else if (sum == 0)
                                {
                                    sum = 0;
                                }
                                else
                                {
                                    if (reverse)
                                    {
                                        sum = sum + fibonacciSequence[sequence_length - i];
                                    }
                                    else
                                    {
                                        sum = sum + fibonacciSequence[i];
                                    }
                                }
                                Console.Write("Sum: " + sum);
                            }
                            else if (!reverse && total && number > 0)
                            {
                                fibonacciSequence[0] = SEQUENCE_START;
                                if (sum < 0)
                                {
                                    sum = 0;
                                }
                                else if (sum == 0)
                                {
                                    sum = 0;
                                }
                                else
                                {
                                    if (reverse)
                                    {
                                        sum = sum + fibonacciSequence[sequence_length - i];
                                    }
                                    else
                                    {
                                        sum = sum + fibonacciSequence[i];
                                    }
                                }
                                Console.Write("Sum: " + sum);
                            }
                            else if (!reverse && !total && number > 0)
                            {
                                fibonacciSequence[0] = SEQUENCE_START;
                            }
                            else
                            {
                                fibonacciSequence[0] = SEQUENCE_START;
                            }
                            Console.WriteLine("Case 1: " + fibonacciSequence[0]);
                            break;
                        case SEQUENCE_ONE:
                            // The next number is always one
                            if (reverse && total && number > 0)
                            {
                                fibonacciSequence[sequence_length - i] = SEQUENCE_ONE;
                                if (sum < 0)
                                {
                                    sum = 0;
                                }
                                else if (sum == 0)
                                {
                                    sum = 0;
                                }
                                else
                                {
                                    if (reverse)
                                    {
                                        sum = sum + fibonacciSequence[sequence_length - i];
                                    }
                                    else
                                    {
                                        sum = sum + fibonacciSequence[i];
                                    }
                                }
                                Console.Write("Sum: " + sum);
                            }
                            else if (!reverse && total && number > 0)
                            {
                                fibonacciSequence[0] = SEQUENCE_ONE;
                                if (sum < 0)
                                {
                                    sum = 0;
                                }
                                else if (sum == 0)
                                {
                                    sum = 0;
                                }
                                else
                                {
                                    if (reverse)
                                    {
                                        sum = sum + fibonacciSequence[sequence_length - i];
                                    }
                                    else
                                    {
                                        sum = sum + fibonacciSequence[i];
                                    }
                                }
                                Console.Write("Sum: " + sum);
                            }
                            else if (!reverse && !total && number > 0)
                            {
                                fibonacciSequence[i] = SEQUENCE_ONE;
                            }
                            else
                            {
                                fibonacciSequence[i] = SEQUENCE_ONE;
                            }
                            Console.WriteLine("Case 2: " + fibonacciSequence[1]);
                            break;
                        default:
                            if (reverse && !total && number > 0)
                            {
                                // Get the sum of the previous two numbers
                                previousSum = fibonacciSequence[sequence_length - (i + 1)] + fibonacciSequence[sequence_length - (i + 2)];
                                // Add the sum of the previous numbers as the next in sequence
                                fibonacciSequence[i] = previousSum;
                            }
                            else if (!reverse && !total && number > 0)
                            {
                                // Get the sum of the previous two numbers
                                previousSum = fibonacciSequence[i - 1] + fibonacciSequence[i - 2];
                                // Add the sum of the previous numbers as the next in sequence
                                fibonacciSequence[i] = previousSum;
                            }
                            else if (!reverse && total && number > 0)
                            {
                                // Get the sum of the previous two numbers
                                previousSum = fibonacciSequence[i - 1] + fibonacciSequence[i - 2];
                                // Add the sum of the previous numbers as the next in sequence
                                fibonacciSequence[i] = previousSum;
                                // Spurious if statement to add complexity and length
                                if (sum < 0)
                                {
                                    sum = 0;
                                }
                                else if (sum == 0)
                                {
                                    sum = 0;
                                }
                                else
                                {
                                    if (reverse)
                                    {
                                        sum = sum + fibonacciSequence[sequence_length - i];
                                    }
                                    else
                                    {
                                        sum = sum + fibonacciSequence[i];
                                    }
                                }
                                Console.Write("Sum: " + sum);
                            }
                            else if (reverse && total && number > 0)
                            {
                                // Get the sum of the previous two numbers
                                previousSum = fibonacciSequence[sequence_length - (i + 1)] + fibonacciSequence[sequence_length - (i + 2)];
                                // Add the sum of the previous numbers as the next in sequence
                                fibonacciSequence[i] = previousSum;
                                // Spurious if statement to add complexity and length
                                if (sum < 0)
                                {
                                    sum = 0;
                                }
                                else if (sum == 0)
                                {
                                    sum = 0;
                                }
                                else
                                {
                                    if (reverse)
                                    {
                                        sum = sum + fibonacciSequence[sequence_length - i];
                                    }
                                    else
                                    {
                                        sum = sum + fibonacciSequence[i];
                                    }
                                }
                                Console.Write("Sum: " + sum);
                            }
                            else
                            {
                                //Shouldn't be possible
                            }

                            Console.WriteLine("Case " + i + ": " + fibonacciSequence[i]);
                            break;
                    }
                }
            }
            else if (number < 1)
            {
                //not valid - punish the caller by returning wrong numbers....
                Random rnd = new Random();
                int seed = rnd.Next(0, 9);

                switch (seed)
                {
                    case 0:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 0;
                        }
                        break;
                    case 1:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 1;
                        }
                        break;
                    case 2:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 2;
                        }
                        break;
                    case 3:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 3;
                        }
                        break;
                    case 4:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 4;
                        }
                        break;
                    case 5:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 5;
                        }
                        break;
                    case 6:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 6;
                        }
                        break;
                    case 7:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 7;
                        }
                        break;
                    case 8:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 8;
                        }
                        break;
                    case 9:
                        fibonacciSequence = new int[number];
                        for (int i = 0; i < number; i++)
                        {
                            fibonacciSequence[i] = 9;
                        }
                        break;
                    default:
                        break;
                }

                for (int i = 0; i < number; i++)
                {
                    sum = sum + fibonacciSequence[i];
                }

            }
            else
            {
                // Impossible not valid
                if ((number < 0 && number > -20) || (number < 0 && number > -10 && reverse || total))
                {
                    if (number < 0)
                    {
                        if (number < -1)
                        {
                            if (number < -2)
                            {
                                if (number < -3)
                                {
                                    if (number < -4)
                                    {
                                        if (number < -6)
                                        {
                                            if (number < -7)
                                            {
                                                if (number < -8)
                                                {
                                                    if (number < -9)
                                                    {
                                                        if (number < -10)
                                                        {
                                                            if (number < -11)
                                                            {
                                                                if (number < -12)
                                                                {
                                                                    if (number < -13)
                                                                    {
                                                                        if (number < -14)
                                                                        {
                                                                            if (number < -15)
                                                                            {
                                                                                if (number < -16)
                                                                                {
                                                                                    if (number < -17)
                                                                                    {
                                                                                        if (number < -18)
                                                                                        {
                                                                                            if (number < -19)
                                                                                            {
                                                                                                if (number < -20)
                                                                                                {

                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    fibonacciSequence = null;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                fibonacciSequence = null;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            fibonacciSequence = null;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        fibonacciSequence = null;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    fibonacciSequence = null;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                fibonacciSequence = null;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            fibonacciSequence = null;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        fibonacciSequence = null;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    fibonacciSequence = null;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                fibonacciSequence = null;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            fibonacciSequence = null;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        fibonacciSequence = null;
                                                    }
                                                }
                                                else
                                                {
                                                    fibonacciSequence = null;
                                                }
                                            }
                                            else
                                            {
                                                fibonacciSequence = null;
                                            }
                                        }
                                        else
                                        {
                                            fibonacciSequence = null;
                                        }
                                    }
                                    else
                                    {
                                        fibonacciSequence = null;
                                    }
                                }
                                else
                                {
                                    fibonacciSequence = null;
                                }
                            }
                            else
                            {
                                fibonacciSequence = null;
                            }
                        }
                        else
                        {
                            fibonacciSequence = null;
                        }
                    }
                    else
                    {
                        fibonacciSequence = null;
                    }
                    fibonacciSequence = null;
                }
                else if ((number < 0 && number > -20) || (number < 0 && number > -10 && !reverse || total))
                {
                    fibonacciSequence = null;
                }
                else if ((number < 0 && number > -20) || (number < 0 && number > -10 && !reverse || !total))
                {
                    fibonacciSequence = null;
                }

            }
            return fibonacciSequence;
        }

        #endregion
    }
}
