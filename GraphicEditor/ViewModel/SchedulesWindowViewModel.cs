using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel
{
    public class SchedulesWindowViewModel : BindableBase
    {
        public RoomController roomController = new RoomController();
        private readonly SchedulesWindow window;
        private List<Appointment> allAppointments = new List<Appointment>();
        private List<EquipmentRelocation> allEquipmentRelocations = new List<EquipmentRelocation>();
        private List<Renovation> allRenovations = new List<Renovation>();
        private AppointmentController appointmentController = new AppointmentController();
        private EquipmentRelocationController equipmentRelocationController = new EquipmentRelocationController();
        private RenovationController renovationController = new RenovationController();

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

        public List<Renovation> AllRenovations
        {
            get { return allRenovations; }
            set
            {
                if (value != null)
                    SetProperty(ref allRenovations, value);
            }
        }

        public Appointment SelectedAppointment { get; set; }
        public EquipmentRelocation SelectedEquipmentRelocation { get; set; }
        public Renovation SelectedRenovation { get; set; }
        public MyICommand CancelOfAppointment { get; private set; }
        public MyICommand CancelOfRelocation { get; private set; }
        public MyICommand CancelOfRenovation { get; private set; }

        public SchedulesWindowViewModel(List<Appointment> appointments,
            List<EquipmentRelocation> equipmentRelocations, List<Renovation> renovations,
            SchedulesWindow window)
        {
            AllAppointments = appointments;
            AllEquipmentRelocations = equipmentRelocations;
            AllRenovations = renovations;

            foreach (EquipmentRelocation equipmentRelocation in AllEquipmentRelocations)
            {
                equipmentRelocation.equipment.Room = roomController.GetBySerialNumber(equipmentRelocation.equipment.RoomSerialNumber);
                equipmentRelocation.roomToRelocateTo = roomController.GetBySerialNumber(equipmentRelocation.roomToRelocateToSerialNumber);
            }

            CancelOfAppointment = new MyICommand(CancelAppointment);
            CancelOfRelocation = new MyICommand(CancelEquipmentRelocation);
            CancelOfRenovation = new MyICommand(CancelRenovation);
            this.window = window;
        }

        private void CancelAppointment()
        {
            if (SelectedAppointment != null)
            {
                appointmentController.DeleteAppointment(SelectedAppointment);
                window.Close();
            }
        }


        private void CancelEquipmentRelocation()
        {
            if (SelectedEquipmentRelocation != null)
            {
                equipmentRelocationController.DeleteEquipmentRelocation(SelectedEquipmentRelocation);
                window.Close();
            }
        }

        private void CancelRenovation()
        {
            if (SelectedRenovation != null)
            {
                renovationController.DeleteRenovation(SelectedRenovation);
                window.Close();
            }
        }
    }
}
