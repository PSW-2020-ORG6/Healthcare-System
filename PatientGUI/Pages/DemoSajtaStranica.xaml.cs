using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
