using System.Windows.Controls;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for SpecialistReferralView.xaml
    /// </summary>
    public partial class SpecialistReferralView : UserControl
    {
        public SpecialistReferralView()
        {
            InitializeComponent();
        }

        private void specialistRefferalNotes_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            notesScrollViewer.ScrollToVerticalOffset(notesScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
