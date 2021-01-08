using HealthClinicBackend.Backend.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
