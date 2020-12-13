using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.ViewModel
{
    public class RoomInformationViewModel : BindableBase, DialogAnswerListener<Bed>, DialogAnswerListener<Room>
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

        public RoomInformationViewModel(Window _window, Room _room)
        {
            NavCommandExit = new MyICommand(exitInfo);
            NavCommandBedUpdate = new MyICommand<Bed>(updateBedInfo);
            NavCommandRoomUpdate = new MyICommand<Room>(updateRoomInfo);

            window = _window;
            roomName = _room.Name;
            room = _room;
            beds = _room.Beds;
            selectedBed = beds[0];
        }

        void updateBedInfo(Bed bedInfo)
        {
            Bed p = new Bed(BedInfo.Name, BedInfo.Id);
            BedUpdate w = new BedUpdate(p, this);
            w.ShowDialog();
        }

        void updateRoomInfo(Room room)
        {
            Room rm = new Room(room.SerialNumber, room.Id, room.RoomType);
            RoomUpdate r = new RoomUpdate(rm, this);
            r.ShowDialog();
        }

        void exitInfo()
        {
            window.Close();
        }

        public void onConfirmUpdate(Bed b)
        {
            BedInfo.Id = b.Id;
            BedInfo.Name = b.Name;
            BedInfo.SerialNumber = b.SerialNumber;
            OnPropertyChanged("BedInfo");
            OnPropertyChanged("Beds");
        }

        public void onConfirmUpdate(Room room)
        {
            RoomName = room.SerialNumber;
            OnPropertyChanged("RoomName");
        }
    }
}
