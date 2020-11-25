using System.Windows.Controls;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for PatientDetailView.xaml
    /// </summary>
    public partial class PatientDetailView : UserControl
    {
        public PatientDetailView()
        {
            InitializeComponent();
        }

        private void reportsDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            reportsTableScrollViewer.ScrollToVerticalOffset(reportsTableScrollViewer.VerticalOffset - e.Delta);
        }

        private void conditionsRichTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            conditionsScrollViewer.ScrollToVerticalOffset(conditionsScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
