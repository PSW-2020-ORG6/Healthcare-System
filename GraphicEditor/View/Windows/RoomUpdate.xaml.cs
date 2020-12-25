using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class RoomUpdate : Window
    {
        public RoomUpdate(Room room, DialogAnswerListener<Room> dialogAnswerListener)
        {
            this.DataContext = new RoomUpdateViewModel(this, room, dialogAnswerListener);
            InitializeComponent();
        }
    }
}
