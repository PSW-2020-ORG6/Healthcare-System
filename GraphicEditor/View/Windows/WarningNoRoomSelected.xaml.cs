using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningNoRoomSelected.xaml
    /// </summary>
    public partial class WarningNoRoomSelected : Window
    {
        public WarningNoRoomSelected()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
