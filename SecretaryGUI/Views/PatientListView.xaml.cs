using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using Model.Accounts;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for PatientListView.xaml
    /// </summary>
    public partial class PatientListView : UserControl
    {

        public PatientListView(String styleName)
        {
            InitializeComponent();
            switch (styleName)
            {
                case "SkyBlue":
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["buttonStyle"] = Application.Current.Resources["MenuButton"];
                    Resources["tableStyle"] = Application.Current.Resources["tableWhite"];
                    Resources["textStyle"] = Application.Current.Resources["WhiteLabelForText"];
                    break;
                case "DarkPurple":
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["buttonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    Resources["tableStyle"] = Application.Current.Resources["tableDark"];
                    Resources["textStyle"] = Application.Current.Resources["DarkLabelForText"];
                    break;
            }

            Messenger.Default.Register<ConfirmDeletePatientMessage>(this, (ConfirmDeletePatientMessage) =>
            {
                Patient patient = (Patient)PatientTable.SelectedItem;
                Console.WriteLine(patient);
                Console.WriteLine("SALJEM PORUKU???");
                Messenger.Default.Send<DeletePatientMessage>(new DeletePatientMessage { patient = patient });
            });

            DeletePatientButton.IsEnabled = false;
            AddAppointmentButton.IsEnabled = false;
        }

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewerPatient.ScrollToVerticalOffset(scrollViewerPatient.VerticalOffset - e.Delta);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Patient patient = (Patient)PatientTable.SelectedItem;
            if (patient == null)
            {
                DeletePatientButton.IsEnabled = false;
                AddAppointmentButton.IsEnabled = false;
            }
            else
            {
                DeletePatientButton.IsEnabled = true;
                AddAppointmentButton.IsEnabled = true;
            }
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)PatientTable.SelectedItem;
            Messenger.Default.Send<AddAppointmentFromPatientViewModelMessage>(new AddAppointmentFromPatientViewModelMessage { patient = patient });
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Messenger.Default.Send<SearchPatientMessage>(new SearchPatientMessage { Pretraga = SearchText.Text });
        }
    }
}
