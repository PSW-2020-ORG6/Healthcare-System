using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Windows;
using EquipmentRelocation = HealthClinicBackend.Backend.Model.Schedule.EquipmentRelocation;
namespace GraphicEditor.ViewModel
{
    public class EquipmentRelocationWindowViewModel : BindableBase
    {
        public Equipment equipment;
        public List<Room> rooms = new List<Room>();
        public int roomIndex;
        public RoomController roomController = new RoomController();
        public DateTime datePicker = DateTime.Now;
        public int timeIndexFrom;
        public int timeIndexTo;
        public int quantityIndex;
        public List<string> myTimeFrom = new List<string>();
        public List<string> myTimeTo = new List<string>();
        public List<uint> quantityList = new List<uint>();
        public Window Window;
        private EquipmentRelocationController EquipmentRelocationController = new EquipmentRelocationController();
        private AppointmentController AppointmentController = new AppointmentController();
        private EquipmentController EquipmentController = new EquipmentController();
        public MyICommand<object> Relocate { get; private set; }
        public int QuantityIndex
        {
            get { return quantityIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref quantityIndex, value);
            }
        }
        public int RoomIndex
        {
            get { return roomIndex; }
            set
            {
                if (value != null)
                    SetProperty(ref roomIndex, value);
            }
        }
        public List<uint> QuantityList
        {
            get { return quantityList; }
            set
            {
                if (value != null)
                    SetProperty(ref quantityList, value);
            }
        }
        public List<string> MyTimeFrom
        {
            get { return myTimeFrom; }
            set
            {
                if (value != null)
                    SetProperty(ref myTimeFrom, value);
            }
        }
        public List<string> MyTimeTo
        {
            get { return myTimeTo; }
            set
            {
                if (value != null)
                    SetProperty(ref myTimeTo, value);
            }
        }
        public int TimeIndexFrom
        {
            get { return timeIndexFrom; }
            set
            {
                if (value != null)
                    SetProperty(ref timeIndexFrom, value);
            }
        }
        public int TimeIndexTo
        {
            get { return timeIndexTo; }
            set
            {
                if (value != null)
                    SetProperty(ref timeIndexTo, value);
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
                MyTimeFrom.Add(i.ToString() + ":" + "00");
                MyTimeFrom.Add(i.ToString() + ":" + "30");
            }
            MyTimeTo.AddRange(myTimeFrom);
        }
        public EquipmentRelocationWindowViewModel(Equipment equipment, Window window)
        {
            Equipment = equipment;
            Rooms.AddRange(roomController.GetAll());
            RemoveRoomEquipemntIsInTo();
            createTimeForDropBox();
            createQuantityListForDropBox();
            Relocate = new MyICommand<object>(RelocateEquipment);
            Window = window;
        }

        private void createQuantityListForDropBox()
        {
            for (uint i = 1; i <= Equipment.Quantity; i++)
            {
                QuantityList.Add(i);
            }
        }

        private void RelocateEquipment(Object obj)
        {
            string[] s = myTimeFrom[timeIndexFrom].Split(":");
            int hours = Int32.Parse(s[0]);
            int min = Int32.Parse(s[1]);
            string[] s2 = MyTimeTo[timeIndexTo].Split(":");
            int hours2 = Int32.Parse(s2[0]);
            int min2 = Int32.Parse(s2[1]);
            if (hours > hours2 || (hours == hours2 && min >= min2))
            {
                MessageBox.Show("Time FROM must be less then TO !!!");
                return;
            }

            EquipmentRelocation equipmentRelocation = new EquipmentRelocation();
            equipmentRelocation.quantity = quantityList[QuantityIndex];
            equipmentRelocation.TimeInterval = new TimeInterval(new DateTime(DatePicker.Year, DatePicker.Month, DatePicker.Day, hours, min, 0),
                                                                new DateTime(DatePicker.Year, DatePicker.Month, DatePicker.Day, hours2, min2, 0));
            equipmentRelocation.roomToRelocateToSerialNumber = rooms[roomIndex].SerialNumber;
            equipmentRelocation.equipmentSerialNumber = Equipment.SerialNumber;
            equipmentRelocation.equipment = EquipmentController.GetById(equipmentRelocation.equipmentSerialNumber);

            Boolean overlapping = false;
            foreach(Appointment app in AppointmentController.GetByRoomSerialNumber(equipmentRelocation.roomToRelocateToSerialNumber))
            {
                if(equipmentRelocation.TimeInterval.IsOverLapping(app.TimeInterval))
                {
                    overlapping = true;
                    break;
                }
            }
            if (!overlapping)
            {
                foreach (EquipmentRelocation er2 in EquipmentRelocationController.GetAll())
                {
                    if (equipmentRelocation.TimeInterval.IsOverLapping(er2.TimeInterval) && equipmentRelocation.roomToRelocateToSerialNumber.Equals(er2.roomToRelocateToSerialNumber))
                    {
                        overlapping = true;
                    }
                }
            }
            

            if (!overlapping) EquipmentRelocationController.AddEquipmentRelocation(equipmentRelocation);
            else
            {
                List<EquipmentRelocation> listInitialER = new List<EquipmentRelocation>();
                for(int i = 1; i < 6; ++i)
                {
                    DateTime startTime = equipmentRelocation.TimeInterval.Start.Subtract(TimeSpan.FromMinutes(30 * (i + 1)));
                    DateTime endTime = equipmentRelocation.TimeInterval.End.Subtract(TimeSpan.FromMinutes(30 * (i + 1)));
                    EquipmentRelocation suggestedBeforeER = new EquipmentRelocation
                    {
                        TimeInterval = new TimeInterval(startTime, endTime),
                        equipmentSerialNumber = equipmentRelocation.equipmentSerialNumber,
                        quantity = equipmentRelocation.quantity,
                        roomToRelocateToSerialNumber = equipmentRelocation.roomToRelocateToSerialNumber,
                        equipment = equipmentRelocation.equipment
                    };

                    startTime = equipmentRelocation.TimeInterval.Start.AddMinutes(30 * (i + 1));
                    endTime = equipmentRelocation.TimeInterval.End.AddMinutes(30 * (i + 1));
                    EquipmentRelocation suggestedAfterER = new EquipmentRelocation
                    {
                        TimeInterval = new TimeInterval(startTime, endTime),
                        equipmentSerialNumber = equipmentRelocation.equipmentSerialNumber,
                        quantity = equipmentRelocation.quantity,
                        roomToRelocateToSerialNumber = equipmentRelocation.roomToRelocateToSerialNumber,
                        equipment = equipmentRelocation.equipment
                    };

                    listInitialER.Add(suggestedBeforeER);
                    listInitialER.Add(suggestedAfterER);
                }

                List<EquipmentRelocation> listFinalER = new List<EquipmentRelocation>();

                List<Appointment> roomAppointments = AppointmentController.GetByRoomSerialNumber(equipmentRelocation.roomToRelocateToSerialNumber);

                foreach (EquipmentRelocation er in listInitialER)
                {
                    foreach (EquipmentRelocation er2 in EquipmentRelocationController.GetAll())
                    {
                        if (er.TimeInterval.IsOverLapping(er2.TimeInterval))
                        {
                            listInitialER.Remove(er);
                            break;
                        }
                    }
                }

                foreach (EquipmentRelocation er in listInitialER)
                {
                    listFinalER.Add(er);
                    foreach (Appointment app in roomAppointments)
                    {
                        if (!(er.TimeInterval.IsOverLapping(app.TimeInterval)))
                        {
                            listFinalER.Remove(er);
                            break;
                        }
                    }
                }

                new EquipmentRelocationSuggestions(listFinalER).Show();
            }
            Window.Close();
        }

        private void RemoveRoomEquipemntIsInTo()
        {
            foreach (Room room in rooms)
            {
                if (room.SerialNumber.Equals(Equipment.RoomSerialNumber))
                {
                    rooms.Remove(room);
                    break;
                }
            }
        }
    }
}
