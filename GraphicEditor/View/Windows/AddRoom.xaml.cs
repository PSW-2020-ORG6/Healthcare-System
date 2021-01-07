using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        private Border roomSpace;
        private Floor floor;
        private FloorUserControl view;
        private RoomTypeController roomTypesController = new RoomTypeController();
        private RoomController roomController = new RoomController();

        public AddRoom(Floor floor1, Border space, FloorUserControl view1)
        {
            InitializeComponent();
            this.DataContext = this;
            roomSpace = space;
            floor = floor1;
            view = view1;

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

            int column = view.SelectedCellsColumn;
            int row = view.SelectedCellsRow;
            int rowSpan = view.SelectedCellsRowSpan;
            int columnSpan = view.SelectedCellsColumnSpan;
            Position position = new Position(row, column, rowSpan, columnSpan);

            RoomButton newRoomButton = new RoomButton(view.Grid);
            Room newRoom = new Room(nameTextBox.Text, Int32.Parse(number), floor.SerialNumber,
                RoomTypes[SelectedRoomTypeIndex].SerialNumber, position.SerialNumber, "RoomButtonStyle");

            newRoomButton.Content = nameTextBox.Text;
            newRoomButton.Tag = newRoom.SerialNumber;
            SetVisibilities(newRoomButton, newRoom);

            Grid.SetColumn(newRoomButton, column);
            Grid.SetRow(newRoomButton, row);
            Grid.SetColumnSpan(newRoomButton, columnSpan);
            Grid.SetRowSpan(newRoomButton, rowSpan);
            Grid.SetZIndex(newRoomButton, 2);
            view.Grid.Children.Add(newRoomButton);
            view.Grid.UpdateLayout();

            roomController.NewRoom(newRoom);

            roomSpace.Visibility = Visibility.Collapsed;
            this.Close();
        }

        private void SetVisibilities(RoomButton newRoomButton, Room newRoom)
        {
            if ((bool)topDoorButton.IsChecked)
            {
                newRoomButton.TopDoor = Visibility.Visible;
                newRoom.TopDoorVisible = (int)Visibility.Visible;
            }
            else
            {
                newRoomButton.TopDoor = Visibility.Collapsed;
                newRoom.TopDoorVisible = (int)Visibility.Collapsed;
            }
            if ((bool)rightDoorButton.IsChecked)
            {
                newRoomButton.RightDoor = Visibility.Visible;
                newRoom.RightDoorVisible = (int)Visibility.Visible;
            }
            else
            {
                newRoomButton.RightDoor = Visibility.Collapsed;
                newRoom.RightDoorVisible = (int)Visibility.Collapsed;
            }
            if ((bool)bottomDoorButton.IsChecked)
            {
                newRoomButton.BottomDoor = Visibility.Visible;
                newRoom.BottomDoorVisible = (int)Visibility.Visible;
            }
            else
            {
                newRoomButton.BottomDoor = Visibility.Collapsed;
                newRoom.BottomDoorVisible = (int)Visibility.Collapsed;
            }
            if ((bool)leftDoorButton.IsChecked)
            {
                newRoomButton.LeftDoor = Visibility.Visible;
                newRoom.LeftDoorVisible = (int)Visibility.Visible;
            }
            else
            {
                newRoomButton.LeftDoor = Visibility.Collapsed;
                newRoom.LeftDoorVisible = (int)Visibility.Collapsed;
            }
        }
    }
}
