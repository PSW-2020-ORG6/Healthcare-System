using GraphicEditor.ViewModel;
using System.Windows;

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
