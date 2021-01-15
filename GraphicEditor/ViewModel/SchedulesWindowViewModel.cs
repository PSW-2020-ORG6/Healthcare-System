using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel
{
    public class SchedulesWindowViewModel : BindableBase
    {
        private AppointmentController appointmentController = new AppointmentController();
        private SchedulesWindow _window;

        public SchedulesWindowViewModel(List<Appointment> appointments, SchedulesWindow window)
        {
            appointments = appointmentController.GetAll();
            _window = window;
        }
    }
}
