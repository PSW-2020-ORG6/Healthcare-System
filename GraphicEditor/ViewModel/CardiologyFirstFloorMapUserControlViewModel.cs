using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using System;

namespace GraphicEditor.ViewModel
{
    public class CardiologyFirstFloorMapUserControlViewModel : BindableBase
    {
        public MyICommand<string> ShowRoomCommand { get; private set; }

        public CardiologyFirstFloorMapUserControlViewModel()
        {
            ShowRoomCommand = new MyICommand<string>(ShowRoom);
        }

        private void ShowRoom(string a)
        {
            (new RoomInformation()).Show();
        }

    }
}
