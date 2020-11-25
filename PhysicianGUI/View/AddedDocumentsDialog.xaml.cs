using System.Windows;
using System.Windows.Input;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for AddedDocumentsDialog.xaml
    /// </summary>
    public partial class AddedDocumentsDialog : Window
    {
        public AddedDocumentsDialog()
        {
            InitializeComponent();
        }

        private void documentsDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            documentsTableScrollViewer.ScrollToVerticalOffset(documentsTableScrollViewer.VerticalOffset - e.Delta);
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
