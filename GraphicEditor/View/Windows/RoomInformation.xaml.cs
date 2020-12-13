using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomInformation.xaml
    /// </summary>
    public partial class RoomInformation : Window
    {
        public RoomInformation(Room room)
        {
            this.DataContext = new RoomInformationViewModel(this, room);
            InitializeComponent();
        }
    }
}
