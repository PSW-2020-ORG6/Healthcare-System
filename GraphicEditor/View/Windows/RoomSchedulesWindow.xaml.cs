using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class RoomSchedulesWindow : Window
    {
        public RoomSchedulesWindow(List<Appointment> appointments, List<EquipmentRelocation> equipmentRelocations)
        {
            this.DataContext = new RoomSchedulesWindowViewModel(appointments, equipmentRelocations, this);
            InitializeComponent();
        }
    }
}
