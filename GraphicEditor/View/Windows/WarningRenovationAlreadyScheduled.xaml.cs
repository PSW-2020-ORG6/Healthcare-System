using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningRenovationAlreadyScheduled.xaml
    /// </summary>
    public partial class WarningRenovationAlreadyScheduled : Window
    {
        public WarningRenovationAlreadyScheduled()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
