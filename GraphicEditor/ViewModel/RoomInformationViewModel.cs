using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.ViewModel
{
    public class RoomInformationViewModel : BindableBase, DialogAnswerListener<Bed>, DialogAnswerListener<Room>
    {
        private RoomInformation window;
        private List<Bed> beds = new List<Bed>();
        private Bed selectedBed;
        private List<Equipment> equipment = new List<Equipment>();
        private Equipment selectedEquipment;
        private List<Medicine> medicines = new List<Medicine>();
        private Medicine selectedMedicine;
        /* TODO add this without causing errors
        private List<Object> items = new List<Object>();
        private Object selectedItem;*/
        private string roomName;
        private Room room;
        private string[] categories = { "Equipment", "Medicines", "Beds" };
        private string selectedCategory;
        private Visibility bedVisibility;
        private Visibility equipmentVisibility;
        private Visibility medicineVisibility;

        public MyICommand<Bed> NavCommandBedUpdate { get; private set; }

        public MyICommand EquipmentRelocationCommand { get; private set; }

        public MyICommand SchedulesCommand { get; private set; }

        public MyICommand<Room> NavCommandRoomUpdate { get; private set; }

        public MyICommand ChangeCaterogyCommand { get; private set; }

        public MyICommand NavCommandExit { get; private set; }

        public List<string> Categories
        {
            get { return new List<string>(categories); }
        }

        public string SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (value != null)
                {
                    SetProperty(ref selectedCategory, value);
                    ChangeCaterogy();
                }
            }
        }

        public Visibility BedVisibility
        {
            get => bedVisibility;
            set
            {
                SetProperty(ref bedVisibility, value);
            }
        }

        public Visibility EquipmentVisibility
        {
            get => equipmentVisibility;
            set
            {
                SetProperty(ref equipmentVisibility, value);
            }
        }

        public Visibility MedicineVisibility
        {
            get => medicineVisibility;
            set
            {
                SetProperty(ref medicineVisibility, value);
            }
        }

        public Bed SelectedBed
        {
            get => selectedBed;
            set
            {
                if (value != null) SetProperty(ref selectedBed, value);
            }
        }

        public List<Bed> Beds
        {
            get => beds;
            set
            {
                SetProperty(ref beds, value);
            }
        }

        public Equipment SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                if (value != null) SetProperty(ref selectedEquipment, value);
                //EquipmentRelocationWindow equipmentRelocationWindow = new EquipmentRelocationWindow(selectedEquipment);
                //equipmentRelocationWindow.Show();
            }
        }

        public List<Equipment> Equipment
        {
            get => equipment;
            set
            {
                SetProperty(ref equipment, value);
            }
        }

        public Medicine SelectedMedicine
        {
            get => selectedMedicine;
            set
            {
                if (value != null) SetProperty(ref selectedMedicine, value);
            }
        }

        public List<Medicine> Medicines
        {
            get => medicines;
            set
            {
                SetProperty(ref medicines, value);
            }
        }

        /* TODO add this without causing errors
        public string roomname
        {
            get => roomname;
            set
            {
                setproperty(ref roomname, value);
            }
        }*/

        public Room Room
        {
            get => room;
            set
            {
                SetProperty(ref room, value);
            }
        }

        private AppointmentController appointmentController = new AppointmentController();
        private BedController bedController = new BedController();
        private EquipmentController equipmentController = new EquipmentController();
        private SuperintendentMedicineController medicineController = new SuperintendentMedicineController();

        public RoomInformationViewModel(RoomInformation _window, Room _room)
        {
            NavCommandExit = new MyICommand(exitInfo);
            NavCommandBedUpdate = new MyICommand<Bed>(updateBedInfo);
            NavCommandRoomUpdate = new MyICommand<Room>(updateRoomInfo);
            ChangeCaterogyCommand = new MyICommand(ChangeCaterogy);
            EquipmentRelocationCommand = new MyICommand(EnterEquipmentRelocationWindow);
            SchedulesCommand = new MyICommand(SchedulesWindow);

            window = _window;
            roomName = _room.Name;
            room = _room;
            equipment = equipmentController.GetByRoomSerialNumber(room.SerialNumber);
            medicines = medicineController.GetByRoomSerialNumber(room.SerialNumber);
            beds = bedController.GetByRoomSerialNumber(room.SerialNumber);

            selectedCategory = categories[0];
            window.equipmentListBox.Visibility = Visibility.Visible;
            window.medicineListBox.Visibility = Visibility.Hidden;
            window.bedsListBox.Visibility = Visibility.Hidden;
            equipmentVisibility = Visibility.Visible;
            medicineVisibility = Visibility.Hidden;
            bedVisibility = Visibility.Hidden;

            if (beds == null) beds = new List<Bed>();
            if (medicines == null) medicines = new List<Medicine>();
            if (equipment == null) equipment = new List<Equipment>();

            if (beds != null & beds.Count != 0)
                selectedBed = beds[0];

            if (medicines != null & medicines.Count != 0)
                selectedMedicine = medicines[0];

            if (equipment != null & equipment.Count != 0)
                selectedEquipment = equipment[0];
        }

        void EnterEquipmentRelocationWindow()
        {
            EquipmentRelocationWindow equipmentRelocationWindow = new EquipmentRelocationWindow(selectedEquipment);
            equipmentRelocationWindow.Show();
        }

        void SchedulesWindow()
        {
            SchedulesWindow schedulesWindow = new SchedulesWindow(appointmentController.GetAll());
            schedulesWindow.Show();
        }

        void ChangeCaterogy()
        {
            switch (selectedCategory)
            {
                case Constants.EQUIPMENT:
                    EquipmentVisibility = Visibility.Visible;
                    MedicineVisibility = Visibility.Hidden;
                    BedVisibility = Visibility.Hidden;
                    break;
                case Constants.MEDICINES:
                    EquipmentVisibility = Visibility.Hidden;
                    MedicineVisibility = Visibility.Visible;
                    BedVisibility = Visibility.Hidden;
                    break;
                case Constants.BEDS:
                    EquipmentVisibility = Visibility.Hidden;
                    MedicineVisibility = Visibility.Hidden;
                    BedVisibility = Visibility.Visible;
                    break;
            }
        }

        void updateBedInfo(Bed bedInfo)
        {
            if (selectedBed != null)
            {
                BedUpdate w = new BedUpdate(selectedBed, this);
                w.ShowDialog();
            }
        }

        void updateRoomInfo(Room room)
        {
            RoomUpdate r = new RoomUpdate(room, this);
            r.ShowDialog();
        }

        void exitInfo()
        {
            window.Close();
        }

        public void onConfirmUpdate(Bed b)
        {
            /* TODO add this without causing errors
            BedInfo.Id = b.Id;
            BedInfo.Name = b.Name;
            BedInfo.SerialNumber = b.SerialNumber;
            OnPropertyChanged("BedInfo");
            OnPropertyChanged("Beds");*/
        }

        public void onConfirmUpdate(Room room)
        {
            /* TODO add this without causing errors
            RoomName = room.SerialNumber;
            OnPropertyChanged("RoomName");*/
        }
    }
}
