using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using Model.Accounts;
using System;
using System.Windows;
using System.Windows.Input;

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for PatientListDialog.xaml
    /// </summary>
    public partial class PatientListDialog : Window
    {
        public PatientListDialog(String styleName)
        {
            InitializeComponent();

            switch (styleName)
            {
                case "SkyBlue":
                    Resources["buttonStyle"] = Application.Current.Resources["MenuButton"];
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    Resources["tableStyle"] = Application.Current.Resources["tableWhite"];
                    break;
                case "DarkPurple":
                    Resources["buttonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    Resources["tableStyle"] = Application.Current.Resources["tableDark"];
                    break;
            }
        }

        private void DialogClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewerPatient.ScrollToVerticalOffset(scrollViewerPatient.VerticalOffset - e.Delta);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)patientsTable.SelectedItem;
            Messenger.Default.Send<ChoosePatientMessage>(new ChoosePatientMessage { patient = patient });
            this.Close();
        }
    }
}
