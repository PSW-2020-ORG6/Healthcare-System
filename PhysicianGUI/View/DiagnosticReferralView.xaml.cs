using System.Windows.Controls;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for DiagnosticReferralView.xaml
    /// </summary>
    public partial class DiagnosticReferralView : UserControl
    {
        public DiagnosticReferralView()
        {
            InitializeComponent();
        }

        private void notesRichTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            notesScrollViewer.ScrollToVerticalOffset(notesScrollViewer.VerticalOffset - e.Delta);
        }


    }
}
