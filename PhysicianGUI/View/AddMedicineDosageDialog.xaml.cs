using System.Windows;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for AddMedicineDosageDialog.xaml
    /// </summary>
    public partial class AddMedicineDosageDialog : Window
    {
        public AddMedicineDosageDialog()
        {
            InitializeComponent();
        }

        private void SubmitMedicineDosageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelMedicineDosageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void notesRichTextBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            notesScrollViewer.ScrollToVerticalOffset(notesScrollViewer.VerticalOffset - e.Delta);
        }
    }
}
