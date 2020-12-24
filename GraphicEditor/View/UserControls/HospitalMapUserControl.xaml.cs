using GraphicEditor.View.Windows;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Util;
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

        private void MakeAppointment(object sender, RoutedEventArgs e)
        {
            if (MainWindow.TypeOfUser != TypeOfUser.Secretary)
            {
                new Warning().ShowDialog();
                return;
            }
            Appointment appointment = new Appointment(_viewModel);
            appointment.Show();
        }
    }
}
