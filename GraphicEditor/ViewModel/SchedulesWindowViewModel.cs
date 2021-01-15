using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel
{
    public class SchedulesWindowViewModel : BindableBase
    {
        public List<Appointment> allAppointments = new List<Appointment>();
        public RoomController roomController = new RoomController();
        private readonly SchedulesWindow window;
        private List<EquipmentRelocation> allEquipmentRelocations = new List<EquipmentRelocation>();

        public List<Appointment> AllAppointments
        {
            get { return allAppointments; }
            set
            {
                if (value != null)
                    SetProperty(ref allAppointments, value);
            }
        }

        public List<EquipmentRelocation> AllEquipmentRelocations
        {
            get { return allEquipmentRelocations; }
            set
            {
                if (value != null)
                    SetProperty(ref allEquipmentRelocations, value);
            }
        }

        public SchedulesWindowViewModel(List<Appointment> appointments,
            List<EquipmentRelocation> equipmentRelocations, SchedulesWindow window)
        {
            AllAppointments = appointments;
            AllEquipmentRelocations = equipmentRelocations;

            foreach (EquipmentRelocation equipmentRelocation in AllEquipmentRelocations)
            {
                equipmentRelocation.equipment.Room = roomController.GetBySerialNumber(equipmentRelocation.equipment.RoomSerialNumber);
                equipmentRelocation.roomToRelocateTo = roomController.GetBySerialNumber(equipmentRelocation.roomToRelocateToSerialNumber);
            }

            this.window = window;
        }
    }
}
