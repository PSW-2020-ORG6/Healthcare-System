using HealthClinicBackend.Backend.Controller.SecretaryControllers;
using HealthClinicBackend.Backend.Dto;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for AppointmentRellocation.xaml
    /// </summary>
    public partial class AppointmentRellocation : Window
    {
        private SecretaryScheduleController secretaryScheduleController = new SecretaryScheduleController();
        public List<KeyValuePair<Appointment, AppointmentDto>> Options { get; set; }
        public AppointmentRellocation(Dictionary<Appointment, AppointmentDto> prefferedChoices)
        {
            Options = prefferedChoices.ToList();

            this.DataContext = this;
            InitializeComponent();
        }

        private void Rellocate_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<Appointment, AppointmentDto> pair = (KeyValuePair<Appointment, AppointmentDto>)optionsListBox.SelectedItem;
            secretaryScheduleController.DeleteAppointment(pair.Key);
            secretaryScheduleController.NewAppointment(pair.Value);
            this.Close();
        }
    }
}
