using System.Windows.Controls;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void findings_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            findingsScrollViewer.ScrollToVerticalOffset(findingsScrollViewer.VerticalOffset - e.Delta);
        }

        private void conditionsRichTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            conditionsScrollViewer.ScrollToVerticalOffset(conditionsScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
