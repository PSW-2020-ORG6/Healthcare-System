using GraphicEditor.View.Windows;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    public partial class BuildingUserControl : UserControl
    {
        private MainWindowViewModel _viewModel;
        public BuildingUserControlViewModel myViewModel;

        public BuildingUserControl(MainWindowViewModel vm, Building building)
        {
            InitializeComponent();
            _viewModel = vm;
            myViewModel = new BuildingUserControlViewModel(this, vm, building);
            this.DataContext = myViewModel;
        }

        private void ShowRoomSearch(object sender, RoutedEventArgs e)
        {
            RoomSearch roomSearch = new RoomSearch(_viewModel);
            roomSearch.Show();
        }

        private void ShowEquipmentSearch(object sender, RoutedEventArgs e)
        {
            EquipmentSearch equipmentSearch = new EquipmentSearch(_viewModel);
            equipmentSearch.Show();
        }

        private void ShowMedicineSearch(object sender, RoutedEventArgs e)
        {
            MedicineSearch medicineSearch = new MedicineSearch(_viewModel);
            medicineSearch.Show();
        }
    }
}
