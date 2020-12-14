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
        private MainWindowViewModel _viewModel;
        public HospitalMapUserControl(MainWindowViewModel vm)
        {
            InitializeComponent();
            _viewModel = vm;
            this.DataContext = new HospitalMapUserControlViewModel(vm, this.hospitalMapGrid);
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
