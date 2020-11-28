using GraphicEditor.HelpClasses;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphicEditor.ViewModel
{
    public class RoomUpdateViewModel : BindableBase
    {
            private Window _window;
            private Room _room;
            private Room _roomOriginal;
            private DialogAnswerListener<Room> _dialogAnswerListener;

            public MyICommand NavCommandUpdate { get; private set; }

            public MyICommand NavCommandExit { get; private set; }

            public Room RoomInfo
            {
                get => _room;
                set
                {
                    if (value != null)
                        SetProperty(ref _room, value);
                }
            }

            public RoomUpdateViewModel(Window window, Room _roomInfo, DialogAnswerListener<Room> dialogAnswerListener)
            {
                _window = window;
                _room = _roomInfo;
                _roomOriginal = new Room(_room.SerialNumber, _room.Id, _room.RoomType);
                _dialogAnswerListener = dialogAnswerListener;

                NavCommandExit = new MyICommand(exitInfo);
                NavCommandUpdate = new MyICommand(updateRoomInfo);
            }

            void updateRoomInfo()
            {
                _dialogAnswerListener.onConfirmUpdate(RoomInfo);
                _window.Close();
            }

            void exitInfo()
            {
                _window.Close();
            }
    }
}
