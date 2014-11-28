using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haiku.Utils;

namespace Haiku.Web
{
    public static class HaikuValidator
    {
        public static IHtmlString Button(string haiku, string rules)
        {
            // Generate the HTML
            string html = ValidationResults(haiku, rules);
            return new HtmlString(html);
        }

        private static string ValidationResults(string haiku, string rules)
        {
            //if (string.IsNullOrEmpty(haiku))
            //    throw new ArgumentException("Haiku cannot be null or empty", "haiku");

            //if (string.IsNullOrEmpty(rules))
            //    throw new ArgumentException("Rules cannot be null or empty", "rules");

            string validationResult = "";

            try
            {
                Proxy haikuProxy = new Proxy();
                // For now ignore ruleset and take default
                haikuProxy.Validate(haiku);
                validationResult = "Your Haiku is valid!";
            }
            catch (InvalidHaikuException ihException)
            {

                validationResult = "Your Haiku is invalid!" + Environment.NewLine;
                validationResult += ihException.Message;
            }

            return validationResult;
        }
    }
}