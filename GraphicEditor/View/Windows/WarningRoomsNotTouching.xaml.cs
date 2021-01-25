using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningRoomsNotTouching.xaml
    /// </summary>
    public partial class WarningRoomsNotTouching : Window
    {
        public WarningRoomsNotTouching()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
