using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class RoomSchedulesWindow : Window
    {
        public RoomSchedulesWindow(List<Appointment> appointments, List<EquipmentRelocation> equipmentRelocations,
            List<Renovation> renovations)
        {
            this.DataContext = new RoomSchedulesWindowViewModel(appointments, equipmentRelocations, renovations, this);
            InitializeComponent();
        }
    }
}
