using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class SchedulesWindow : Window
    {
        public SchedulesWindow(List<Appointment> appointments)
        {
            this.DataContext = new SchedulesWindowViewModel(appointments, this);
            InitializeComponent();
            appointmentsListView.ItemsSource = appointments;
        }
    }
}
