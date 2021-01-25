using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomRenovationTimeSuggestions.xaml
    /// </summary>
    public partial class RoomRenovationTimeSuggestions : Window
    {
        private RoomRenovation roomRenovation;
        private AppointmentController appointmentController = new AppointmentController();
        private EquipmentRelocationController equipmentRelocationController = new EquipmentRelocationController();
        public List<TimeInterval> ListOfTimeIntervals { get; set; }

        public RoomRenovationTimeSuggestions(RoomRenovation roomRenovation)
        {
            this.DataContext = this;
            InitializeComponent();

            this.roomRenovation = roomRenovation;

            ListOfTimeIntervals = new List<TimeInterval>();
            Initialization();
            MyListBox.ItemsSource = ListOfTimeIntervals;
        }

        private void Initialization()
        {
            for (int i = 1; i < 6; ++i)
            {
                TimeSpan ts = roomRenovation.TimeInterval.End - roomRenovation.TimeInterval.Start;
                DateTime startTime = roomRenovation.TimeInterval.Start.Subtract(TimeSpan.FromMinutes(ts.TotalMinutes * i));
                DateTime endTime = roomRenovation.TimeInterval.End.Subtract(TimeSpan.FromMinutes(ts.TotalMinutes * i));

                TimeInterval ti_b = new TimeInterval(startTime, endTime);


                startTime = roomRenovation.TimeInterval.Start.AddMinutes(ts.TotalMinutes * (i + 1));
                endTime = roomRenovation.TimeInterval.End.AddMinutes(ts.TotalMinutes * (i + 1));

                TimeInterval ti_a = new TimeInterval(startTime, endTime);


                ListOfTimeIntervals.Add(ti_b);
                ListOfTimeIntervals.Add(ti_a);
            }

            List<Appointment> roomAppointments = appointmentController.GetByRoomSerialNumber(roomRenovation.RenovatedRoomSerialNumber);

            List<TimeInterval> copyList = new List<TimeInterval>(ListOfTimeIntervals);

            foreach (TimeInterval ti in copyList)
            {
                foreach (Appointment app in roomAppointments)
                {
                    if (ti.IsOverLapping(app.TimeInterval))
                    {
                        ListOfTimeIntervals.Remove(ti);
                        break;
                    }
                }
            }

            List<EquipmentRelocation> ERList = equipmentRelocationController.GetAll();

            copyList = new List<TimeInterval>(ListOfTimeIntervals);

            foreach (TimeInterval ti in copyList)
            {
                foreach (EquipmentRelocation er in ERList)
                {
                    if (!er.roomToRelocateToSerialNumber.Equals(roomRenovation.RenovatedRoomSerialNumber)) continue;
                    if (ti.IsOverLapping(er.TimeInterval))
                    {
                        ListOfTimeIntervals.Remove(ti);
                        break;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            roomRenovation.TimeInterval = (TimeInterval)MyListBox.SelectedItem;
            this.Close();
        }
    }
}
