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
            MapContentUserControlViewModel.HospitalMap.HospitalMapGrid = hospitalMapGrid;
            this.DataContext = MapContentUserControlViewModel.HospitalMap;
            MapContentUserControlViewModel.HospitalMap.InitialGridRender();
        }

        private void ShowRoomSearch(object sender, RoutedEventArgs e)
        {
            RoomSearch roomSearch = new RoomSearch();
            roomSearch.Show();
        }

        private void ShowEquipmentSearch(object sender, RoutedEventArgs e)
        {
            EquipmentSearch equipmentSearch = new EquipmentSearch();
            equipmentSearch.Show();
        }
    }
}
