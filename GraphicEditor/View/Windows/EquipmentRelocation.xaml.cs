using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for EquipmentRelocation.xaml
    /// </summary>
    public partial class EquipmentRelocation : Window
    {
        public EquipmentRelocation(Equipment equipment)
        {
            this.DataContext = new EquipmentRelocationViewModel(equipment, this);
            InitializeComponent();
        }
    }
}
