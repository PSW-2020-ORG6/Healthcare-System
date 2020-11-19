using HCI_SIMS_PROJEKAT.ViewModels;
using HCI_SIMS_PROJEKAT.Views;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HCI_SIMS_PROJEKAT
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

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AppointmentButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ScheduleButtonFromMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ChangeStyle(String styleName)
        {
            switch (styleName)
            {
                case "DarkPurple":
                    Resources["menuButtonStyle"] = Application.Current.Resources["DarkMenuButton"];
                    break;
                case "SkyBlue":
                    Resources["menuButtonStyle"] = Application.Current.Resources["MenuButton"];
                    break;
            }
        }

    }
}
