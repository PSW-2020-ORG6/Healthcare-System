using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using Model.Hospital;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.ViewModel
{
    public class RoomInformationViewModel : BindableBase
    {
        private Window window;

        private List<Bed> beds = new List<Bed>();

        private Bed selectedBed;

        private string roomName;

        private Room room;

        public MyICommand<Bed> NavCommandBedUpdate { get; private set; }

        public MyICommand<Room> NavCommandRoomUpdate { get; private set; }

        public MyICommand NavCommandExit { get; private set; }

        public Bed BedInfo
        {
            get => selectedBed;
            set
            {
                if (value != null) SetProperty(ref selectedBed, value);
            }
        }

        public List<Bed> Beds
        {
            get => beds;
            set
            {
                SetProperty(ref beds, value);
            }
        }

        public string RoomName
        {
            get => roomName;
            set
            {
                SetProperty(ref roomName, value);
            }
        }

        public Room Room
        {
            get => room;
            set
            {
                SetProperty(ref room, value);
            }
        }

        public RoomInformationViewModel(Window _window, string _roomName)
        {
            NavCommandExit = new MyICommand(exitInfo);
            NavCommandBedUpdate = new MyICommand<Bed>(updateBedInfo);
            NavCommandRoomUpdate = new MyICommand<Room>(updateRoomInfo);

            window = _window;
            roomName = _roomName;
            room = new Room(_roomName, 100, new RoomType("Basic"));

            beds.Add(new Bed("Bed 1", "bed01"));
            beds.Add(new Bed("Bed 2", "bed02"));
            beds.Add(new Bed("Bed 3", "bed03"));
            beds.Add(new Bed("Bed 4", "bed04"));
            beds.Add(new Bed("Bed 5", "bed05"));

            selectedBed = beds[0];

        }

        void updateBedInfo(Bed bedInfo)
        {
            Bed p = new Bed(BedInfo.Name, BedInfo.Id);
            BedUpdate w = new BedUpdate(p);
            w.ShowDialog();
            BedInfo.Id = p.Id;
            BedInfo.Name = p.Name;
            OnPropertyChanged("BedInfo");
        }

        void updateRoomInfo(Room room)
        {
            Room rm = new Room(room.SerialNumber, room.Id, room.RoomType);
            RoomUpdate r = new RoomUpdate(rm);
            r.ShowDialog();
            RoomName = rm.SerialNumber;
            OnPropertyChanged("RoomName");
        }


        void exitInfo()
        {
            window.Close();
        }
    }
}
