using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class EquipmentRelocationWindow : Window
    {
        public EquipmentRelocationWindow(Equipment equipment)
        {
            this.DataContext = new EquipmentRelocationWindowViewModel(equipment, this);
            InitializeComponent();
        }
    }
}
