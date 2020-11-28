using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using System;
using System.Windows.Controls;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for PhysitianView.xaml
    /// </summary>
    public partial class PhysitianView : UserControl
    {
        public PhysitianView()
        {
            InitializeComponent();
        }

        private void examsDataGrid_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            examsTableScrollViewer.ScrollToVerticalOffset(examsTableScrollViewer.VerticalOffset - e.Delta);
        }

        private void appointmentsDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send<DateChangedMessage>(new DateChangedMessage { date = (DateTime)appointmentsDatePicker.SelectedDate });
        }
    }
}
