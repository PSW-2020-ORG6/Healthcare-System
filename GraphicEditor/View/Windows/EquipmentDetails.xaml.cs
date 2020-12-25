using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class EquipmentDetails : Window, INotifyPropertyChanged
    {
        private string _roomIdSerialNumber;
        public event PropertyChangedEventHandler PropertyChanged;
        private EquipmentController equipmentController = new EquipmentController();
        List<Equipment> _equipments = new List<Equipment>();

        public EquipmentDetails()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public List<Equipment> Equipments
        {
            get { return _equipments; }
            set
            {
                _equipments = value;
                OnPropertyChanged();
            }
        }
        public string RoomSerialNumber
        {
            get { return _roomIdSerialNumber; }
            set
            {
                _roomIdSerialNumber = value;
                OnPropertyChanged();
            }
        }

        public EquipmentDetails(string roomSerialNumber)
        {
            InitializeComponent();
            this.DataContext = this;
            _roomIdSerialNumber = roomSerialNumber;
            Equipments = equipmentController.GetByRoomSerialNumber(roomSerialNumber);
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
