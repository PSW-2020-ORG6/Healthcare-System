using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.intendentControllers;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for ComplexRoomRenovation.xaml
    /// </summary>
    public partial class ComplexRoomRenovation : Window
    {
        private Border roomSpace;
        private Floor floor;
        private FloorUserControl view;
        private RoomTypeController roomTypesController = new RoomTypeController();
        private RoomController roomController = new RoomController();
        private EquipmentController equipmentController = new EquipmentController();
        private SuperintendentMedicineController medicineController = new SuperintendentMedicineController();
        private BedController bedController = new BedController();
        private RoomRenovationController roomRenovationController = new RoomRenovationController();
        private List<Room> renovatingRooms;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public ComplexRoomRenovation(Floor floor1, Border space, FloorUserControl view1, List<Room> _renovatingRooms)
        {
            InitializeComponent();
            this.DataContext = this;
            roomSpace = space;
            floor = floor1;
            view = view1;
            renovatingRooms = _renovatingRooms;
            Start = DateTime.Now;
            End = DateTime.Now;
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

            string[] split = nameTextBox.Text.Split(" ");
            string number = split[split.Length - 1];
            int k;

            if (!Int32.TryParse(number, System.Globalization.NumberStyles.Integer, null, out k))
            {
                nameLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                return;
            }

            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);

            Room firstRoom = renovatingRooms[0];

            int column = firstRoom.Position.Column;
            int row = firstRoom.Position.Row;
            int rowSpan = firstRoom.Position.RowSpan;
            int columnSpan = firstRoom.Position.ColumnSpan;

            (int, int) topLeftCorner = (column, row);
            (int, int) bottomRightCorner = (column + columnSpan - 1, row + rowSpan - 1);

            (int, int) topLeftCorner2;
            (int, int) bottomRightCorner2;

            foreach (Room room in renovatingRooms)
            {
                if (room == renovatingRooms[0]) continue;
                topLeftCorner2 = (room.Position.Column, room.Position.Row);
                bottomRightCorner2 = (room.Position.Column + room.Position.ColumnSpan - 1, room.Position.Row + room.Position.RowSpan - 1);

                if (topLeftCorner.Item1 >= topLeftCorner2.Item1 && topLeftCorner.Item2 >= topLeftCorner2.Item2)
                    topLeftCorner = topLeftCorner2;

                if (bottomRightCorner.Item1 <= bottomRightCorner2.Item1 && bottomRightCorner.Item2 <= bottomRightCorner2.Item2)
                    bottomRightCorner = bottomRightCorner2;
            }

            column = topLeftCorner.Item1;
            row = topLeftCorner.Item2;
            columnSpan = bottomRightCorner.Item1 - topLeftCorner.Item1 + 1;
            rowSpan = bottomRightCorner.Item2 - topLeftCorner.Item2 + 1;

            Position position = new Position(row, column, rowSpan, columnSpan);

            // Ovo oko dugmeta prekopirati tamo isto

            //RoomButton newRoomButton = new RoomButton(view.Grid);
            Room newRoom = new Room(nameTextBox.Text, Int32.Parse(number), floor.SerialNumber,
                RoomTypes[SelectedRoomTypeIndex].SerialNumber, position, "RoomButtonStyle");
            newRoom.IsWaitingToBeRenovated = true;
            newRoom.IsBeingRenovated = false;
            SetVisibilities(newRoom);
            //newRoomButton.Content = nameTextBox.Text;
            //newRoomButton.Tag = newRoom.SerialNumber;
            


            TimeInterval timeInterval = new TimeInterval(Start, End);

            RoomRenovation roomRenovation = new RoomRenovation()
            {
                RenovatedRoomSerialNumber = newRoom.SerialNumber,
                RenovatedRoom = newRoom,
                TimeInterval = timeInterval,
                RenovatingRooms = renovatingRooms
            };

            foreach (Room room in renovatingRooms)
            {
                room.IsWaitingToBeRenovated = true;
                room.RoomRenovationSerialNumber = roomRenovation.SerialNumber;
                roomController.EditRoom(room);
            }

            roomController.NewRoom(newRoom);
            roomRenovationController.AddRoomRenovation(roomRenovation);

            // Ovo tamo u funkciji koju ce dispecer proveravati

            //Grid.SetColumn(newRoomButton, column);
            //Grid.SetRow(newRoomButton, row);
            //Grid.SetColumnSpan(newRoomButton, columnSpan);
            //Grid.SetRowSpan(newRoomButton, rowSpan);
            //Grid.SetZIndex(newRoomButton, 2);
            //view.Grid.Children.Add(newRoomButton);
            //view.Grid.UpdateLayout();

            //roomController.NewRoom(newRoom);

            //roomSpace.Visibility = Visibility.Collapsed;
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
