using Model.Accounts;
using Model.Util;
using HealthClinic.ViewModel;
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

namespace HealthClinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SideMenuOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            SideMenuOpenBtn.Visibility = Visibility.Collapsed;
        }

        private void SideMenuCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            SideMenuOpenBtn.Visibility = Visibility.Visible;
        }

        private void SideMenuOpenBtn_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(SideMenuOpenBtn.IsEnabled)
            {
                SideMenuOpenBtn.Visibility = Visibility.Visible;
            } else
            {
                SideMenuOpenBtn.Visibility = Visibility.Hidden;
            }
        }
    }
}
