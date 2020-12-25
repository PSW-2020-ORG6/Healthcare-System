using HealthClinicBackend.Backend.Dto;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class AppointmentList : Window, INotifyPropertyChanged
    {

        List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();
        public event PropertyChangedEventHandler PropertyChanged;

        public List<AppointmentDto> AppointmentDtos
        {
            get { return appointmentDtos; }
            set
            {
                appointmentDtos = value;
                OnPropertyChanged();
            }
        }
        public AppointmentList()
        {
            InitializeComponent();
        }
        public AppointmentList(List<AppointmentDto> listOfAppointments)
        {
            InitializeComponent();
            this.DataContext = this;
            appointmentDtos = listOfAppointments;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void showEquipmentDetails(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int index = appointmentListBox.SelectedIndex;
            string serialNumber = appointmentDtos[index].Room.SerialNumber;
            EquipmentDetails win = new EquipmentDetails(serialNumber);
            win.Show();
        }
    }
}
