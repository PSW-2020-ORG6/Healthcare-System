using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using health_clinic_class_diagram.Backend.Model.Util;

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
            if (MainWindow.TypeOfUser != TypeOfUser.PATIENT)
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
