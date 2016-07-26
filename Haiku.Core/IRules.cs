using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haiku.Core
{
    /// <summary>
    /// The interface that all Haiku Rules classes must implement.
    /// </summary>
    public interface IRules
    {
        /// <summary>
        /// Validate the given Haiku based on the stats in the HaikuAnalysis
        /// </summary>
        /// <param name="analysis">The Haiku's stats.</param>
        /// <returns>The results after the rules have been applied.</returns>
        HaikuAnalysis validateHaiku(HaikuAnalysis analysis);
    }
}
