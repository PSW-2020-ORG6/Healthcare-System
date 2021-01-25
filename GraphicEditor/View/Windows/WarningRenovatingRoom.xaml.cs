using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningRenovatingRoom.xaml
    /// </summary>
    public partial class WarningRenovatingRoom : Window
    {
        public WarningRenovatingRoom()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
