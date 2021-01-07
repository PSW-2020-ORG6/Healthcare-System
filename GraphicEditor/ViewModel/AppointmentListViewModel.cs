using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SecretaryControllers;
using HealthClinicBackend.Backend.Dto;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class AppointmentListViewModel : BindableBase
    {
        public List<AppointmentDto> listOfAppointments = new List<AppointmentDto>();
        public Window windowParent;
        public Window window;
        public MainWindowViewModel parentViewModel;
        public int appointmentIndex;
        public SecretaryScheduleController secretaryScheduleController = new SecretaryScheduleController();
        public MyICommand<object> CreateAppointment { get; private set; }
        public MyICommand<object> ShowEquipments { get; private set; }
        public MyICommand<object> GoTo { get; private set; }
        public AppointmentListViewModel(List<AppointmentDto> listOfAppointments, Window windowParent, MainWindowViewModel viewModel, Window window)
        {
            this.ListOfAppointments = listOfAppointments;
            this.windowParent = windowParent;
            this.parentViewModel = viewModel;
            this.window = window;
            CreateAppointment = new MyICommand<object>(createAppointment);
            ShowEquipments = new MyICommand<object>(showEquipmentButton);
            GoTo = new MyICommand<object>(goToButtonClick);
        }
        public List<AppointmentDto> ListOfAppointments
        {
            get { return listOfAppointments; }
            set
            {
                if (value != null)
                    SetProperty(ref listOfAppointments, value);
            }
        }

        public int AppointmentIndex
        {
            get { return appointmentIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref appointmentIndex, value);
            }
        }
        private void createAppointment(object obj)
        {
            secretaryScheduleController.NewAppointment(listOfAppointments[AppointmentIndex]);
            MessageBox.Show("You created appointment");
            this.windowParent.Close();
            this.window.Close();
        }
        private void showEquipmentButton(object obj)
        {
            string serialNumber = listOfAppointments[AppointmentIndex].Room.SerialNumber;
            EquipmentDetails win = new EquipmentDetails(serialNumber);
            win.Show();
        }
        private void goToButtonClick(object obj)
        {
            AppointmentDto appointmentDto = listOfAppointments[AppointmentIndex];
            parentViewModel.CurrentUserControl = parentViewModel.CardiologyBuilding;
            FloorUserControlViewModel floorViewModel = parentViewModel.CardiologyBuilding.myViewModel.FirstFloor.Viewmodel;
            Button button = floorViewModel.connections[appointmentDto.Room.SerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(150, 0, 255));

            CommonUtil.Run(() =>
            {
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }, TimeSpan.FromMilliseconds(5000));
        }
    }
}
