using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for WarningSplitStuffRelocation.xaml
    /// </summary>
    public partial class WarningSplitStuffRelocation : Window
    {
        public WarningSplitStuffRelocation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
