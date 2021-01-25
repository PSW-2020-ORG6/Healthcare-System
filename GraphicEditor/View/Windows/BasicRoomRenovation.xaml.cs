using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for ComplexRoomRenovation.xaml
    /// </summary>
    public partial class BasicRoomRenovation : Window
    {
        private Floor floor;
        private RoomTypeController roomTypesController = new RoomTypeController();
        private RoomController roomController = new RoomController();
        private EquipmentController equipmentController = new EquipmentController();
        private SuperintendentMedicineController medicineController = new SuperintendentMedicineController();
        private BedController bedController = new BedController();
        private RoomRenovationController roomRenovationController = new RoomRenovationController();
        private AppointmentController appointmentController = new AppointmentController();
        private EquipmentRelocationController equipmentRelocationController = new EquipmentRelocationController();
        private Room renovatingRoom;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public BasicRoomRenovation(Floor floor1, Room _renovatingRoom)
        {
            InitializeComponent();
            this.DataContext = this;
            floor = floor1;
            renovatingRoom = _renovatingRoom;
            Start = DateTime.Now + TimeSpan.FromSeconds(30);
            End = DateTime.Now + TimeSpan.FromSeconds(60);
            timeIntervalStart.CultureInfo = CultureInfo.DefaultThreadCurrentUICulture;
            timeIntervalEnd.CultureInfo = CultureInfo.DefaultThreadCurrentUICulture;

            RoomTypes = roomTypesController.GetAll();
            SelectedRoomTypeIndex = 0;
        }

        public int SelectedRoomTypeIndex { get; set; }
        public List<RoomType> RoomTypes { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)!topDoorButton.IsChecked && (bool)!bottomDoorButton.IsChecked && (bool)!rightDoorButton.IsChecked && (bool)!leftDoorButton.IsChecked)
            {
                topDoorButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                bottomDoorButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                rightDoorButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                leftDoorButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return;
            }

            topDoorButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            bottomDoorButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            rightDoorButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            leftDoorButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (nameTextBox.Text.Equals(""))
            {
                nameLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return;
            }

            nameLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            if (descriptionTextBox.Text.Equals(""))
            {
                descriptionLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return;
            }

            descriptionLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            string[] split = nameTextBox.Text.Split(" ");
            string number = split[split.Length - 1];
            int k;

            if (!Int32.TryParse(number, System.Globalization.NumberStyles.Integer, null, out k))
            {
                nameLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return;
            }
            Position position = new Position(renovatingRoom.Position.Row, renovatingRoom.Position.Column, renovatingRoom.Position.RowSpan, renovatingRoom.Position.ColumnSpan);

            Room newRoom = new Room(nameTextBox.Text, Int32.Parse(number), floor.SerialNumber, RoomTypes[SelectedRoomTypeIndex].SerialNumber, position, "RoomButtonStyle");

            newRoom.IsWaitingToBeRenovated = true;
            newRoom.IsBeingRenovated = false;
            SetVisibilities(newRoom);

            TimeInterval timeInterval = new TimeInterval(Start, End);

            RoomRenovation roomRenovation = new RoomRenovation()
            {
                RenovatedRoomSerialNumber = newRoom.SerialNumber,
                RenovatedRoom = newRoom,
                TimeInterval = timeInterval,
                Description = descriptionTextBox.Text
            };

            bool timeSet = false;

            foreach (HealthClinicBackend.Backend.Model.Schedule.Appointment appointment in appointmentController.GetByRoomSerialNumber(renovatingRoom.SerialNumber))
            {
                if (appointment.TimeInterval.IsOverLapping(timeInterval))
                {
                    new RoomRenovationTimeSuggestions(roomRenovation).ShowDialog();
                    timeSet = true;
                    break;
                }
            }

            if (!timeSet)
            {
                foreach (EquipmentRelocation er in equipmentRelocationController.GetAll())
                {
                    if (!er.roomToRelocateToSerialNumber.Equals(roomRenovation.RenovatedRoomSerialNumber)) continue;
                    if (er.TimeInterval.IsOverLapping(timeInterval))
                    {
                        new RoomRenovationTimeSuggestions(roomRenovation).ShowDialog();
                        timeSet = true;
                        break;
                    }
                }
            }

            renovatingRoom.IsWaitingToBeRenovated = true;
            renovatingRoom.RoomRenovationSerialNumber = roomRenovation.SerialNumber;
            roomController.EditRoom(renovatingRoom);

            roomController.NewRoom(newRoom);
            roomRenovationController.AddRoomRenovation(roomRenovation);
            this.Close();
        }

        private void SetVisibilities(Room newRoom)
        {
            if ((bool)topDoorButton.IsChecked)
            {
                newRoom.TopDoorVisible = (int)Visibility.Visible;
            }
            else
            {
                newRoom.TopDoorVisible = (int)Visibility.Collapsed;
            }
            if ((bool)rightDoorButton.IsChecked)
            {
                newRoom.RightDoorVisible = (int)Visibility.Visible;
            }
            else
            {
                newRoom.RightDoorVisible = (int)Visibility.Collapsed;
            }
            if ((bool)bottomDoorButton.IsChecked)
            {
                newRoom.BottomDoorVisible = (int)Visibility.Visible;
            }
            else
            {
                newRoom.BottomDoorVisible = (int)Visibility.Collapsed;
            }
            if ((bool)leftDoorButton.IsChecked)
            {
                newRoom.LeftDoorVisible = (int)Visibility.Visible;
            }
            else
            {
                newRoom.LeftDoorVisible = (int)Visibility.Collapsed;
            }
        }
    }
}
