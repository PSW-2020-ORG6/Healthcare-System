using GraphicEditor.ViewModel;
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
    public partial class EquipmentDetails : Window
    {
        public EquipmentDetails(string roomSerialNumber)
        {
            this.DataContext = new EquipmentViewModel(roomSerialNumber);
            InitializeComponent();
        }
    }
}
