using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Model.Util;

namespace GraphicEditor.ViewModel
{
    public class CardiologyFirstFloorMapUserControlViewModel : BindableBase
    {
        public MyICommand<string> ShowRoomCommand { get; private set; }

        public CardiologyFirstFloorMapUserControlViewModel()
        {
            ShowRoomCommand = new MyICommand<string>(ShowRoom);
        }

        private void ShowRoom(string roomName)
        {
            if (MainWindow.TypeOfUser != TypeOfUser.Patient)
            {
                new RoomInformation(roomName).Show();
            }
            else
            {
                new Warning().ShowDialog();
            }
        }
    }
}
