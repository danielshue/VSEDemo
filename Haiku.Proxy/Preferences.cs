using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Haiku.Utils
{
    public class Preferences
    {

        // Need to set HKEY_CURRENT_USER\Software\GD\HaikuCheckInPolicy before use

        private string REG_ROOT_SUBKEY = "Software\\GD\\HaikuCheckInPolicy";
        private string REG_KEY_RULE_SET = "RuleSet";
        private string DEFAULT_RULE_SET = "Western Rules";

        // Retrieve the saved rule set
        public string getRuleSet()
        {
            RegistryKey RegKeyRead = null;
            string ruleSet = null;

            //try
            //{
            //    RegKeyRead = Registry.CurrentUser.OpenSubKey(REG_ROOT_SUBKEY);
            //    ruleSet = (string)RegKeyRead.GetValue(REG_KEY_RULE_SET);
                
            //}
            //catch (Exception ex)
            //{
            //    // if the key can't be read, create it
            //    createDefaultRuleSet();
            //    ruleSet = DEFAULT_RULE_SET;
            //}
            //finally
            //{
            //    if (RegKeyRead != null)
            //    {
            //        RegKeyRead.Close();
            //    }
            //}

            // For now don't use the registry until tested on Windows 8
            ruleSet = DEFAULT_RULE_SET;

            return ruleSet;
        }

        // Store the chosen rule set.
        public void setRuleSet(string ruleset)
        {
            // For now don't use the registry until tested on Windows 8
            
            //RegistryKey RegKeyWrite = Registry.CurrentUser;
            //// Delete the subkey to remove all values prior to writing the new values
            //RegKeyWrite.DeleteSubKeyTree(REG_ROOT_SUBKEY);
            //// Recreate the key
            //RegKeyWrite = RegKeyWrite.CreateSubKey(REG_ROOT_SUBKEY);

            //RegKeyWrite.SetValue(REG_KEY_RULE_SET, ruleset);

            //RegKeyWrite.Close();
        }

        // Store the chosen rule set.
        public void createDefaultRuleSet()
        {
            // For now don't use the registry until tested on Windows 8
            
            //RegistryKey RegKeyWrite = Registry.CurrentUser;
            
            //RegKeyWrite = RegKeyWrite.CreateSubKey(REG_ROOT_SUBKEY);

            //RegKeyWrite.SetValue(REG_KEY_RULE_SET, DEFAULT_RULE_SET);

            //RegKeyWrite.Close();
        }

    }
}
