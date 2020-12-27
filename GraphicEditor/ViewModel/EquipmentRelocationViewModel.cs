using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel
{
    public class EquipmentRelocationViewModel : BindableBase
    {
        public Equipment equipment;
        public List<Room> rooms = new List<Room>();
        public RoomController roomController = new RoomController();
        public DateTime datePicker = DateTime.Now;
        public int timeIndex;
        public List<string> myTime = new List<string>();
        public MyICommand<object> Relocate { get; private set; }

        public List<string> MyTime
        {
            get { return myTime; }
            set
            {
                if (value != null)
                    SetProperty(ref myTime, value);
            }
        }
        public int TimeIndex
        {
            get { return timeIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref timeIndex, value);
            }
        }
        public DateTime DatePicker
        {
            get { return datePicker; }
            set
            {
                if (value != null)
                    SetProperty(ref datePicker, value);
            }
        }
        public List<Room> Rooms
        {
            get => rooms;
            set
            {
                if (value != null) SetProperty(ref rooms, value);
            }
        }
        public Equipment Equipment
        {
            get => equipment;
            set
            {
                if (value != null) SetProperty(ref equipment, value);
            }
        }
        private void createTimeForDropBox()
        {
            for (int i = 0; i < 24; i++)
            {
                MyTime.Add(i.ToString() + ":" + "00");
                MyTime.Add(i.ToString() + ":" + "30");
            }
        }
        public EquipmentRelocationViewModel(Equipment equipment)
        {
            Equipment = equipment;
            Rooms.AddRange(roomController.GetAll());
            RemoveRoomEquipemntIsInTo();
            createTimeForDropBox();
            Relocate = new MyICommand<object>(RelocateEquipment);
        }

        private void RelocateEquipment(Object obj)
        {
            //To do
        }

        private void RemoveRoomEquipemntIsInTo()
        {
            foreach (Room room in rooms)
            {
                if (room.SerialNumber.Equals(room.SerialNumber))
                {
                    rooms.Remove(room);
                    break;
                }
            }
        }
    }
}
