using System.Windows;
using System.Windows.Controls;

namespace klinika_zdravo.Pages
{
    /// <summary>
    /// Interaction logic for BlogStranica.xaml
    /// </summary>
    public partial class BlogStranica : Page
    {
        public BlogStranica()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialog1.IsOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dialog1.IsOpen = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dialog1.IsOpen = true;
        }
    }
}
