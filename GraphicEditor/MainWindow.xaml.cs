using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double SCREEN_FACTOR = 0.93;

        public static double MainScreenWidth = System.Windows.SystemParameters.PrimaryScreenWidth * SCREEN_FACTOR;
        public static double MainScreenHeight = System.Windows.SystemParameters.PrimaryScreenHeight * SCREEN_FACTOR;

        public MainWindow()
        {
            Application.Current.MainWindow.Width = MainScreenWidth;
            Application.Current.MainWindow.Height = MainScreenHeight;
            //this.DataContext = MainWindowViewModel;
            InitializeComponent();
        }
    }
}
