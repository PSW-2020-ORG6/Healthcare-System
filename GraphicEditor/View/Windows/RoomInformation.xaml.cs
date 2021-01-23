using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class RoomInformation : Window
    {
        // Floor floor1, Border space, FloorUserControl view1, Room _renovatingRoom
        public RoomInformation(Room room)
        {
            InitializeComponent();
            this.DataContext = new RoomInformationViewModel(this, room);
        }
    }
}
