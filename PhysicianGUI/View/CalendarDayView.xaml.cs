using GalaSoft.MvvmLight.Messaging;
using HealthClinic.Message;
using System;
using System.Collections.Generic;
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
