using System.Windows;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for InpatientCareHistoryDialog.xaml
    /// </summary>
    public partial class InpatientCareHistoryDialog : Window
    {
        public InpatientCareHistoryDialog()
        {
            InitializeComponent();
        }

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            inpatientHistoryScrollViewer.ScrollToVerticalOffset(inpatientHistoryScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
