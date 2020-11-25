using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for CalendarDayView.xaml
    /// </summary>
    public partial class CalendarDayView : UserControl
    {
        public CalendarDayView()
        {
            InitializeComponent();
        }

        private void CalendarViewCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String calendarMode = (String)CalendarViewCB.SelectedItem;

            if (calendarMode.Equals("dan"))
            {
                return;
            }

            String message = "";

            switch (calendarMode)
            {
                case "dan":
                    message = "CalendarDayView";
                    break;
                case "mesec":
                    message = "CalendarView";
                    break;
            }

            Messenger.Default.Send<SwitchViewMessage>(new SwitchViewMessage { ViewName = message });
        }

        private void examsDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            examsTableScrollViewer.ScrollToVerticalOffset(examsTableScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
