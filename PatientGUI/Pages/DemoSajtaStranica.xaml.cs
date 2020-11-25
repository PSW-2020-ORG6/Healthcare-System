using System.Windows;
using System.Windows.Controls;

namespace klinika_zdravo.Pages
{
    /// <summary>
    /// Interaction logic for DemoSajtaStranica.xaml
    /// </summary>
    public partial class DemoSajtaStranica : Page
    {
        public DemoSajtaStranica()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }
    }
}
