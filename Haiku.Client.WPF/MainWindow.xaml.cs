using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using Haiku.Utils;

namespace HaikuCheckInPolicyUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Proxy haikuProxy = null;

        public MainWindow()
        {
            InitializeComponent();
            setRuleSets();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            haikuProxy.setSelectedRuleSet(rulesList.SelectedIndex);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void setRuleSets()
        {
            haikuProxy = new Proxy();
            string[] ruleNames = haikuProxy.getRuleNames();

            for (int i = 0; i < ruleNames.Length; i++)
            {
                rulesList.Items.Add(ruleNames[i]);
            }

            if (ruleNames != null && ruleNames.Length >= 0)
            {
                rulesList.SelectedIndex = haikuProxy.getSelectedRuleSet();
            }

        }

        /// <summary>
        /// Set the description for the selected rule set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rulesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = rulesList.SelectedIndex;
            if (selected >= 0)
            {
                ruleSetDescription.Text = haikuProxy.getRuleDescription(selected);
            }
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            int selected = rulesList.SelectedIndex;
            
            if (selected >= 0)
            {
                try
                {
                    haikuProxy.Validate(haiku.Text, selected);
                    result.Content = "Valid";
                }
                catch (InvalidHaikuException ihException)
                {

                    result.Content = "Invalid";
                    result.ToolTip = ihException.Message;
                }
            }
        }
    }
}
