using Backend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegisterPatientView.xaml
    /// </summary>
    public partial class RegisterPatientView : UserControl
    {

        public Regex rgxName = new Regex(@"^[A-Z][a-z]+$");
        public Regex rgxPhone = new Regex(@"^([0-9]|/|-)+$");
        public Regex rgxMail = new Regex(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.com$");
        public Regex rgxId = new Regex(@"^[0-9]+$");

        public RegisterPatientView(String styleName)
        {
            InitializeComponent();

            Submit.IsEnabled = false;

            switch (styleName)
            {
                case "SkyBlue":
                    Resources["buttonStyle"] = Application.Current.Resources["MenuButton"];
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    Resources["menuButtonSubmitStyle"] = Application.Current.Resources["MenuButtonSubmit"];
                    break;
                case "DarkPurple":
                    Resources["buttonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    Resources["menuButtonSubmitStyle"] = Application.Current.Resources["DarkMenuButtonSubmit"];
                    break;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuestCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ParentNameTextBox.IsEnabled = false;
            StateComboBox.IsEnabled = false;
            CityComboBox.IsEnabled = false;
            AddressTextBox.IsEnabled = false;
            EmailTextBox.IsEnabled = false;
            PasswordTextBox.IsEnabled = false;

        }

        private void GuestCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ParentNameTextBox.IsEnabled = true;
            StateComboBox.IsEnabled = true;
            CityComboBox.IsEnabled = true;
            AddressTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            PasswordTextBox.IsEnabled = true;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GuestCheckBox.IsChecked == false)
            {
                if (NameTextBox.Text == ""
                || SurnameTextBox.Text == ""
                || ParentNameTextBox.Text == ""
                || IdTextBox.Text == ""
                || AddressTextBox.Text == ""
                || PhoneNumberTextBox.Text == ""
                || EmailTextBox.Text == ""
                || PasswordTextBox.Text == ""
                || !rgxName.IsMatch(NameTextBox.Text)
                || !rgxName.IsMatch(SurnameTextBox.Text)
                || !rgxName.IsMatch(ParentNameTextBox.Text)
                || !rgxId.IsMatch(IdTextBox.Text)
                || !rgxPhone.IsMatch(PhoneNumberTextBox.Text)
                || !rgxMail.IsMatch(EmailTextBox.Text)
                || PasswordTextBox.Text.Length < 5)
                {
                    Submit.IsEnabled = false;
                }
                else
                {
                    Submit.IsEnabled = true;
                }
            } else
            {
                if (NameTextBox.Text == ""
               || SurnameTextBox.Text == ""
               || IdTextBox.Text == ""
               || PhoneNumberTextBox.Text == ""
               || !rgxName.IsMatch(NameTextBox.Text)
               || !rgxName.IsMatch(SurnameTextBox.Text)
               || !rgxId.IsMatch(IdTextBox.Text)
               || !rgxPhone.IsMatch(PhoneNumberTextBox.Text))
                {
                    Submit.IsEnabled = false;
                }
                else
                {
                    Submit.IsEnabled = true;
                }
            }
            
        }
    }
}
