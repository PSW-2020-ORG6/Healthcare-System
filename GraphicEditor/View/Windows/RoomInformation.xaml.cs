using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class RoomInformation : Window
    {
        public RoomInformation(Room room)
        {
            InitializeComponent();
            this.DataContext = new RoomInformationViewModel(this, room);
        }
    }
}
