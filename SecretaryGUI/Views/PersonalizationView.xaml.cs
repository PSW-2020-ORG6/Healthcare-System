using HCI_SIMS_PROJEKAT.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for PersonalizationView.xaml
    /// </summary>
    public partial class PersonalizationView : UserControl
    {
        public PersonalizationView(String styleName, CultureInfo currLanguage)
        {
            InitializeComponent();

            switch (styleName)
            {
                case "SkyBlue":
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    StyleComboBox.SelectedIndex = 0;
                    break;
                case "DarkPurple":
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    StyleComboBox.SelectedIndex = 1;
                    break;
            }

            switch (currLanguage.Name)
            {
                case "en-US":
                    LanguageComboBox.SelectedIndex = 1;
                    break;
                default:
                    LanguageComboBox.SelectedIndex = 0;
                    break;
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(LanguageComboBox.SelectedValue == null))
            {
                if (LanguageComboBox.SelectedValue.ToString().Equals("Serbian"))
                {
                    PersonalizationViewModel.Language = CultureInfo.GetCultureInfo("sr-Latn-RS");
                }
                else if (LanguageComboBox.SelectedValue.ToString().Equals("English"))
                {
                    PersonalizationViewModel.Language = CultureInfo.GetCultureInfo("en-US");
                }
            }
        }

        private void StyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(StyleComboBox.SelectedValue == null))
            {
                if (StyleComboBox.SelectedValue.ToString().Equals("DarkPurple"))
                {
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    PersonalizationViewModel.StyleName = "DarkPurple";

                }
                else if (StyleComboBox.SelectedValue.ToString().Equals("SkyBlue"))
                {
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    PersonalizationViewModel.StyleName = "SkyBlue";
                }
            }


        }
    }
}
