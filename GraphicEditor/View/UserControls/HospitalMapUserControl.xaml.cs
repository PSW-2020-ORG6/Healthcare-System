using GraphicEditor.View.Windows;
using GraphicEditor.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for HospitalMapUserControl.xaml
    /// </summary>
    public partial class HospitalMapUserControl : UserControl
    {
        public HospitalMapUserControl()
        {
            InitializeComponent();
            this.DataContext = MapContentUserControlViewModel.HospitalMap;
        }

        private void ShowRoomSearch(object sender, RoutedEventArgs e)
        {
            RoomSearch roomSearch = new RoomSearch();
            roomSearch.Show();
        }
    }
}
