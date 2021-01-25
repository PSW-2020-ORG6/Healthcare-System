using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningRoomRenovationDeletion.xaml
    /// </summary>
    public partial class WarningRoomRenovationDeletion : Window
    {
        public WarningRoomRenovationDeletion()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
