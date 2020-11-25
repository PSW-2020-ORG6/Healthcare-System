using System;
using System.Windows;
using System.Windows.Controls;

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for AppointmentView.xaml
    /// </summary>
    public partial class AppointmentView : UserControl
    {
        public AppointmentView(String styleName)
        {
            InitializeComponent();
            Submit.IsEnabled = false;

            switch (styleName)
            {
                case "SkyBlue":
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["buttonStyle"] = Application.Current.Resources["MenuButton"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    Resources["textBlockStyle"] = Application.Current.Resources["TextBlockWhite"];
                    break;
                case "DarkPurple":
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["buttonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    Resources["textBlockStyle"] = Application.Current.Resources["TextBlockDark"];
                    break;

            }
        }

        private void ChoosePatientButton_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.MainWindow.Language

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PhysitianComboBox.SelectedItem == null || RoomComboBox.SelectedItem == null)
            {
                Submit.IsEnabled = true;
                return;
            }

            if (PhysitianComboBox.SelectedItem.ToString().Equals("Lekar ") || (RoomComboBox.SelectedItem.ToString().Equals("Soba")))
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
