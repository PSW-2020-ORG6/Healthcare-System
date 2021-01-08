using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningRoomOverlaping.xaml
    /// </summary>
    public partial class WarningRoomOverlapping : Window
    {
        public WarningRoomOverlapping()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
