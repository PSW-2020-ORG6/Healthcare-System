using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for ComplexRoomRenovation.xaml
    /// </summary>
    public partial class SplitRoomRenovation : Window
    {
        private Floor floor;
        private RoomTypeController roomTypesController = new RoomTypeController();
        private RoomController roomController = new RoomController();
        private EquipmentController equipmentController = new EquipmentController();
        private SuperintendentMedicineController medicineController = new SuperintendentMedicineController();
        private BedController bedController = new BedController();
        private RoomRenovationController roomRenovationController = new RoomRenovationController();
        private Room renovatingRoom;
        private List<Room> listOfNewRooms;
        private Position position;
        private List<bool> moveStuffToThisRoom;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public SplitRoomRenovation(Floor floor1, Room _renovatingRoom)
        {
            InitializeComponent();
            this.DataContext = this;
            floor = floor1;
            renovatingRoom = _renovatingRoom;
            Start = DateTime.Now;
            End = DateTime.Now;

            RoomTypes = roomTypesController.GetAll();
            SelectedRoomTypeIndex = 0;
        }

        public SplitRoomRenovation(Floor floor1, Room _renovatingRoom, ref List<Room> listOfRooms, Position position, List<bool> moveStuffToThisRoom) : this(floor1, _renovatingRoom)
        {
            this.listOfNewRooms = listOfRooms;
            this.position = position;
            this.moveStuffToThisRoom = moveStuffToThisRoom;
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

            string[] split = nameTextBox.Text.Split(" ");
            string number = split[split.Length - 1];
            int k;

            if (!Int32.TryParse(number, System.Globalization.NumberStyles.Integer, null, out k))
            {
                nameLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return;
            }

            Room newRoom = new Room(nameTextBox.Text, Int32.Parse(number), floor.SerialNumber, RoomTypes[SelectedRoomTypeIndex].SerialNumber, position, "RoomButtonStyle");
            newRoom.IsWaitingToBeRenovated = true;
            newRoom.IsBeingRenovated = false;
            SetVisibilities(newRoom);

            listOfNewRooms.Add(newRoom);

            if ((bool)relocationCheckBox.IsChecked) moveStuffToThisRoom.Add(true);

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
