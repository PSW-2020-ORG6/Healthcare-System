using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for EquipmentDetails.xaml
    /// </summary>
    public partial class EquipmentDetails : Window,INotifyPropertyChanged
    {
        private string _roomIdSerialNumber;
        public event PropertyChangedEventHandler PropertyChanged;
        private EquipmentDatabaseSql equipmentDatabaseSql = new EquipmentDatabaseSql();
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
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public string RoomSerialNumber
        {
            get { return _roomIdSerialNumber; }
            set
            {
                _roomIdSerialNumber = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public EquipmentDetails(string roomSerialNumber)
        {
            InitializeComponent();
            this.DataContext = this;
            _roomIdSerialNumber = roomSerialNumber;
            Equipments = equipmentDatabaseSql.GetAll().Where(r => r.RoomId.Equals(_roomIdSerialNumber)).ToList();
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
