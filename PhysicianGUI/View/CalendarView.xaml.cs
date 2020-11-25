using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        private DateTime _currentDate;

        public DateTime CurrentDate { get => _currentDate; set => _currentDate = value; }

        public CalendarView()
        {
            InitializeComponent();
            CurrentDate = DateTime.Today;
        }

        private void RefreshCalendar()
        {
            Calendar.BuildCalendar(CurrentDate);
        }

        private void Calendar_DayChanged(object sender, DayChangedEventArgs e)
        {

        }

        private void nextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(1);
            RefreshCalendar();
        }

        private void prevMonthButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(-1);
            RefreshCalendar();
        }

        private void CalendarViewCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String calendarMode = (String)CalendarViewCB.SelectedItem;

            if (calendarMode.Equals("mesec"))
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
    }
}
