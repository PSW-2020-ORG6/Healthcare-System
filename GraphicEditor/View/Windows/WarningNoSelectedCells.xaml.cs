using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningNoSelectedCells.xaml
    /// </summary>
    public partial class WarningNoSelectedCells : Window
    {
        public WarningNoSelectedCells()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
