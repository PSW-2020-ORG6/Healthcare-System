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
        public CardiologyBuildingUserControl(MainWindowViewModel vm)
        {
            InitializeComponent();
            this.DataContext = new CardiologyBuildingUserControlViewModel(this, vm);
           
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

        private void ShowMedicineSearch(object sender, RoutedEventArgs e)
        {
            MedicineSearch medicineSearch = new MedicineSearch();
            medicineSearch.Show();
        }
    }
}
