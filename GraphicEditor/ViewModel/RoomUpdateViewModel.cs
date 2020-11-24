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

            public RoomUpdateViewModel(Window window, Room _roomInfo)
            {
                _window = window;
                _room = _roomInfo;
                _roomOriginal = new Room(_room.SerialNumber, _room.Id, _room.RoomType);

                NavCommandExit = new MyICommand(exitInfo);
                NavCommandUpdate = new MyICommand(updateRoomInfo);
            }

            void updateRoomInfo()
            {
                _window.Close();
            }

            void exitInfo()
            {
                RoomInfo.SerialNumber = _roomOriginal.SerialNumber;
                RoomInfo.Id= _roomOriginal.Id;
                RoomInfo.RoomType = _roomOriginal.RoomType;
                OnPropertyChanged("BedInfo");
                _window.Close();
            }
    }
}
