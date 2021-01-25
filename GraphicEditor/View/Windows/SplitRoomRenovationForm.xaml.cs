using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for SplitRoomRenovationForm.xaml
    /// </summary>
    public partial class SplitRoomRenovationForm : Window
    {
        private Floor floor;
        private Room room;
        private List<Border> newBorders;
        private List<Room> newRooms;
        private RoomController roomController = new RoomController();
        private RoomRenovationController roomRenovationController = new RoomRenovationController();
        private EquipmentController equipmentController = new EquipmentController();
        private BedController bedController = new BedController();
        private SuperintendentMedicineController medicineController = new SuperintendentMedicineController();
        private AppointmentController appointmentController = new AppointmentController();
        private EquipmentRelocationController equipmentRelocationController = new EquipmentRelocationController();
        private TimeInterval timeInterval;
        private string description;
        private Room MoveEverythingToThisRoom;

        public int GridHeight { get; set; }
        public int GridWidth { get; set; }
        public List<int> RowList { get; set; }
        public List<int> ColumnList { get; set; }
        public List<int> RowSpanList { get; set; }
        public List<int> ColumnSpanList { get; set; }

        public SplitRoomRenovationForm(Floor _floor, Room _renovatingRoom)
        {
            this.DataContext = this;
            InitializeComponent();
            floor = _floor;
            room = _renovatingRoom;

            RoomBorder.Height = 50 * room.Position.RowSpan;
            RoomBorder.Width = 50 * room.Position.ColumnSpan;

            for (int i = 0; i < room.Position.RowSpan; ++i)
                RoomGrid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < room.Position.ColumnSpan; ++i)
                RoomGrid.ColumnDefinitions.Add(new ColumnDefinition());

            RowList = new List<int>();
            ColumnList = new List<int>();
            RowSpanList = new List<int>();
            ColumnSpanList = new List<int>();

            for (int i = 0; i < room.Position.RowSpan; ++i) RowList.Add(i);
            for (int i = 0; i < room.Position.ColumnSpan; ++i) ColumnList.Add(i);
            for (int i = 1; i < room.Position.RowSpan + 1; ++i) RowSpanList.Add(i);
            for (int i = 1; i < room.Position.ColumnSpan + 1; ++i) ColumnSpanList.Add(i);

            RowComboBox.ItemsSource = RowList;
            ColumnComboBox.ItemsSource = ColumnList;
            RowSpanComboBox.ItemsSource = RowSpanList;
            ColumnSpanComboBox.ItemsSource = ColumnSpanList;

            timeIntervalStart.Value = DateTime.Now + TimeSpan.FromSeconds(120);
            timeIntervalEnd.Value = DateTime.Now + TimeSpan.FromSeconds(150);

            newBorders = new List<Border>();
            newRooms = new List<Room>();

            description = "Splitting room " + room.Id.ToString() + " into rooms: ";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (newBorders.Count != 0)
            {
                foreach (Border border in newBorders)
                {
                    if (IsOverlapping(border))
                    {
                        new WarningRoomOverlapping().ShowDialog();
                        return;
                    }
                }
            }

            Position position = new Position((int)RowComboBox.SelectedItem + room.Position.Row,
                                             (int)ColumnComboBox.SelectedItem + room.Position.Column,
                                             (int)RowSpanComboBox.SelectedItem,
                                             (int)ColumnSpanComboBox.SelectedItem);

            List<bool> moveStuffToThisRoom = new List<bool>();
            int before = newRooms.Count;
            new SplitRoomRenovation(floor, room, ref newRooms, position, moveStuffToThisRoom).ShowDialog();
            int after = newRooms.Count;
            if (before < after)
            {
                description += room.Id.ToString() + ", ";
                Border border = new Border();
                Random random = new Random();
                border.BorderThickness = new Thickness(3);
                border.BorderBrush = new SolidColorBrush(Colors.Black);
                border.Background = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                this.RoomGrid.Children.Add(border);
                Grid.SetRow(border, position.Row - room.Position.Row);
                Grid.SetColumn(border, position.Column - room.Position.Column);
                Grid.SetRowSpan(border, position.RowSpan);
                Grid.SetColumnSpan(border, position.ColumnSpan);
                newBorders.Add(border);
                if (moveStuffToThisRoom.Count != 0) MoveEverythingToThisRoom = newRooms[newRooms.Count - 1];

                Grid.SetRow(selectedGridCells, 0);
                Grid.SetColumn(selectedGridCells, 0);
                Grid.SetRowSpan(selectedGridCells, 1);
                Grid.SetColumnSpan(selectedGridCells, 1);

                RowComboBox.SelectedIndex = 0;
                ColumnComboBox.SelectedIndex = 0;
                RowSpanComboBox.SelectedIndex = 0;
                ColumnSpanComboBox.SelectedIndex = 0;
            }
        }

        private void LocationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RowComboBox.SelectedItem == null || RowSpanComboBox.SelectedItem == null || ColumnComboBox.SelectedItem == null || ColumnSpanComboBox.SelectedItem == null) return;
            if ((int)RowComboBox.SelectedItem + (int)RowSpanComboBox.SelectedItem >= room.Position.RowSpan)
                RowSpanComboBox.SelectedValue = room.Position.RowSpan - (int)RowComboBox.SelectedItem;

            if ((int)ColumnComboBox.SelectedItem + (int)ColumnSpanComboBox.SelectedItem >= room.Position.ColumnSpan)
                ColumnSpanComboBox.SelectedValue = room.Position.ColumnSpan - (int)ColumnComboBox.SelectedItem;

            Grid.SetColumn(selectedGridCells, (int)ColumnComboBox.SelectedItem);
            Grid.SetRow(selectedGridCells, (int)RowComboBox.SelectedItem);
            Grid.SetColumnSpan(selectedGridCells, (int)ColumnSpanComboBox.SelectedItem);
            Grid.SetRowSpan(selectedGridCells, (int)RowSpanComboBox.SelectedItem);
        }

        private bool IsOverlapping(Border border)
        {
            Border space = this.selectedGridCells;
            (int, int) topLeftCornerSpace = (Grid.GetColumn(space), Grid.GetRow(space));
            (int, int) bottomRightCornerSpace = (Grid.GetColumn(space) + Grid.GetColumnSpan(space) - 1, Grid.GetRow(space) + Grid.GetRowSpan(space) - 1);

            (int, int) topLeftCornerRoom = (Grid.GetColumn(border), Grid.GetRow(border));
            (int, int) bottomRightCornerRoom = (Grid.GetColumn(border) + Grid.GetColumnSpan(border) - 1, Grid.GetRow(border) + Grid.GetRowSpan(border) - 1);

            bool inside = false;
            List<(int, int)> roomCorners = new List<(int, int)>();

            for (int i = topLeftCornerRoom.Item1; i <= bottomRightCornerRoom.Item1; ++i)
                for (int j = topLeftCornerRoom.Item2; j <= bottomRightCornerRoom.Item2; ++j)
                    roomCorners.Add((i, j));

            foreach ((int, int) corner in roomCorners)
            {
                if (corner.Item1 >= topLeftCornerSpace.Item1 &&
                   corner.Item2 >= topLeftCornerSpace.Item2 &&
                   corner.Item1 <= bottomRightCornerSpace.Item1 &&
                   corner.Item2 <= bottomRightCornerSpace.Item2)
                {
                    inside = true;
                    break;
                }
            }

            return inside;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MoveEverythingToThisRoom == null)
            {

                return;
            }
            timeInterval = new TimeInterval((DateTime)timeIntervalStart.Value, (DateTime)timeIntervalEnd.Value);

            RoomRenovation roomRenovation = new RoomRenovation()
            {
                TimeInterval = timeInterval,
                RenovatedRoom = room,
                RenovatedRoomSerialNumber = room.SerialNumber,
                Description = description.Substring(0, description.Length - 2)
            };

            bool timeSet = false;

            foreach (Appointment appointment in appointmentController.GetByRoomSerialNumber(room.SerialNumber))
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

            roomRenovationController.AddRoomRenovation(roomRenovation);
            room.RoomRenovationSerialNumber = roomRenovation.SerialNumber;
            room.IsWaitingToBeRenovated = true;
            roomController.EditRoom(room);
            foreach (Room newRoom in newRooms)
            {
                roomController.NewRoom(newRoom);
            }

            foreach (Equipment equipment in equipmentController.GetByRoomSerialNumber(room.SerialNumber))
            {
                equipment.RoomSerialNumber = MoveEverythingToThisRoom.SerialNumber;
                equipmentController.EditEquipment(equipment);
            }
            foreach (Medicine medicine in medicineController.GetByRoomSerialNumber(room.SerialNumber))
            {
                medicine.RoomSerialNumber = MoveEverythingToThisRoom.SerialNumber;
                medicineController.EditWaitingMedicine(medicine);
            }
            foreach (Bed bed in bedController.GetByRoomSerialNumber(room.SerialNumber))
            {
                bed.RoomSerialNumber = MoveEverythingToThisRoom.SerialNumber;
                bedController.EditBed(bed);
            }

            this.Close();
        }
    }
}
