using HealthClinicBackend.Backend.Dto;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EmergencyScheduleResult.xaml
    /// </summary>
    public partial class EmergencyScheduleResult : Window
    {
        public AppointmentDto Appointment { get; set; }
        public EmergencyScheduleResult(AppointmentDto appointmentDto, Window parent)
        {
            this.DataContext = this;
            Appointment = appointmentDto;
            InitializeComponent();
        }
    }
}
