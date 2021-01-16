using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;
namespace GraphicEditor.ViewModel
{
    public class RoomSchedulesWindowViewModel : BindableBase
    {
        public List<Appointment> allAppointments = new List<Appointment>();
        public RoomController roomController = new RoomController();
        private readonly RoomSchedulesWindow window;
        private List<EquipmentRelocation> allEquipmentRelocations = new List<EquipmentRelocation>();
        private EquipmentRelocationController equipmentRelocationController = new EquipmentRelocationController();

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

        public EquipmentRelocation SelectedEquipmentRelocation { get; set; }

        public MyICommand CancelOfRelocation { get; private set; }

        public RoomSchedulesWindowViewModel(List<Appointment> appointments,
            List<EquipmentRelocation> equipmentRelocations, RoomSchedulesWindow window)
        {
            AllAppointments = appointments;
            AllEquipmentRelocations = equipmentRelocations;

            foreach (EquipmentRelocation equipmentRelocation in AllEquipmentRelocations)
            {
                equipmentRelocation.equipment.Room = roomController.GetBySerialNumber(equipmentRelocation.equipment.RoomSerialNumber);
                equipmentRelocation.roomToRelocateTo = roomController.GetBySerialNumber(equipmentRelocation.roomToRelocateToSerialNumber);
            }

            CancelOfRelocation = new MyICommand(CancelEquipmentRelocation);
            this.window = window;
        }

        private void CancelEquipmentRelocation()
        {
            if (SelectedEquipmentRelocation != null)
            {
                equipmentRelocationController.DeleteEquipmentRelocation(SelectedEquipmentRelocation);
                window.Close();
            }
        }
    }
}

