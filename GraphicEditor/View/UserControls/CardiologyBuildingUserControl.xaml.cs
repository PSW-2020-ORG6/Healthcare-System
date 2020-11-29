using GraphicEditor.View.Windows;
using GraphicEditor.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for CardiologyBuildingUserControl.xaml
    /// </summary>
    public partial class CardiologyBuildingUserControl : UserControl
    {
        public CardiologyBuildingUserControl()
        {
            this.DataContext = MapContentUserControlViewModel.CardiologyBuilding;
            InitializeComponent();
        }

        private void ShowRoomSearch(object sender, RoutedEventArgs e)
        {
            RoomSearch roomSearch = new RoomSearch();
            roomSearch.Show();
        }

        private void SearchEquipment(object sender, RoutedEventArgs e)
        {
            EquipmentSearch equipmentSearch = new EquipmentSearch();
            equipmentSearch.Show();
        }
    }
}
