using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using System;

namespace GraphicEditor.ViewModel
{
    public class CardiologyFirstFloorMapUserControlViewModel : BindableBase
    {
        public MyICommand<string> ShowRoomCommand { get; private set; }

        public CardiologyFirstFloorMapUserControlViewModel()
        {
            ShowRoomCommand = new MyICommand<string>(showRoom);
        }

        private void showRoom(string a)
        {
            (new RoomInformation()).Show();
        }

    }
}
