using GalaSoft.MvvmLight.Messaging;
using HCI_SIMS_PROJEKAT.Messages;
using Model.Schedule;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HCI_SIMS_PROJEKAT.Views
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        public ScheduleView(String styleName)
        {
            InitializeComponent();
            PhysitianComboBox.SelectedItem = null;
            switch (styleName)
            {
                case "SkyBlue":
                    Resources["panelStyle"] = Application.Current.Resources["WhitePanel"];
                    Resources["buttonStyle"] = Application.Current.Resources["MenuButton"];
                    Resources["tableStyle"] = Application.Current.Resources["tableWhite"];
                    break;
                case "DarkPurple":
                    Resources["panelStyle"] = Application.Current.Resources["DarkPanel"];
                    Resources["buttonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    Resources["tableStyle"] = Application.Current.Resources["tableDark"];
                    break;
            }

            Messenger.Default.Register<ConfirmDeleteAppointmentMessage>(this, (confirmDeleteAppointmentMessage) =>
            {
                Appointment appointment = (Appointment)ScheduleTable.SelectedItem;
                Messenger.Default.Send<DeleteAppointmentMessage>(new DeleteAppointmentMessage { appointment = appointment });
            });

            DeleteAppointmentButton.IsEnabled = false;
            EditAppointmentButton.IsEnabled = false;
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewerAppointment.ScrollToVerticalOffset(scrollViewerAppointment.VerticalOffset - e.Delta);
        }

        private void DeleteAppointmentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScheduleTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointment appointment = (Appointment)ScheduleTable.SelectedItem;
            if (appointment == null)
            {
                DeleteAppointmentButton.IsEnabled = false;
                EditAppointmentButton.IsEnabled = false;
            }
            else
            {
                DeleteAppointmentButton.IsEnabled = true;
                EditAppointmentButton.IsEnabled = true;
            }
        }

        private void EditAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)ScheduleTable.SelectedItem;
            Messenger.Default.Send<EditAppointmentMessageViewModel>(new EditAppointmentMessageViewModel { appointment = appointment });
        }




    }
}
