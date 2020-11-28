using System;
using System.Windows;

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

        private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            GraphicEditor.MainWindow map = new GraphicEditor.MainWindow();
            this.Close();
            map.DataContext = GraphicEditor.ViewModel.MapContentUserControlViewModel.HospitalMap;
            map.Show();
        }
    }
}
