using GraphicEditor.View.Windows;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Util;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    public partial class HospitalMapUserControl : UserControl
    {
        private AppointmentController appointmentController = new AppointmentController();
        private EquipmentRelocationController equipmentRelocationController = new EquipmentRelocationController();
        private RenovationController renovationController = new RenovationController();
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

        private void EmergencyAppointment(object sender, RoutedEventArgs e)
        {
            if (MainWindow.TypeOfUser != TypeOfUser.Secretary)
            {
                new Warning().ShowDialog();
                return;
            }
            EmergencyAppointment appointment = new EmergencyAppointment(_viewModel);
            appointment.Show();
        }

        private void SchedulesClick(object sender, RoutedEventArgs e)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.NoUser || MainWindow.TypeOfUser == TypeOfUser.Patient)
            {
                new Warning().ShowDialog();
                return;
            }
            SchedulesWindow schedulesWindow = new SchedulesWindow(appointmentController.GetAll(),
                                                            equipmentRelocationController.GetAll(),
                                                            renovationController.GetAll());
            schedulesWindow.Show();
        }
    }
}
