using System.Windows;

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
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            if (SideMenuOpenBtn.IsEnabled)
            {
                SideMenuOpenBtn.Visibility = Visibility.Visible;
            }
            else
            {
                SideMenuOpenBtn.Visibility = Visibility.Hidden;
            }
        }

        private void MapOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            GraphicEditor.MainWindow map = new GraphicEditor.MainWindow();
            this.Close();
            map.DataContext = GraphicEditor.ViewModel.MapContentUserControlViewModel.HospitalMap;
            map.Show();
        }
    }
}
