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
        private CardiologyFirstFloorMapUserControl view;
        private RoomTypeController roomTypesController = new RoomTypeController();
        private RoomController roomController = new RoomController();

        public AddRoom(Floor floor1, Border space, CardiologyFirstFloorMapUserControl view1)
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
            if ((bool)!topDoorButton.IsChecked && (bool)!bottomDoorButton.IsChecked && (bool)!rightDoorButton.IsChecked && (bool)!leftDoorButton.IsChecked )
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
                nameLabel.Foreground  = new SolidColorBrush(Color.FromRgb(255, 0, 0));
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
            int columnSpan = view.SelectedCellsColumnSpan;
            int rowSpan = view.SelectedCellsRowSpan;

            Room newRoom = new Room()
            {
                FloorSerialNumber = floor.SerialNumber,
                RoomTypeSerialNumber = RoomTypes[SelectedRoomTypeIndex].SerialNumber,
                Id = Int32.Parse(number),
                Style = "RoomButtonStyle",
                Column = column,
                Row = row,
                ColumnSpan = columnSpan,
                RowSpan = rowSpan,
                Name = nameTextBox.Text
            };

            roomController.NewRoom(newRoom);

            Button newRoomButton = new Button()
            {
                Style = (Style)resourceDictionary["RoomButtonStyle"],
                Content = nameTextBox.Text,
                Tag = newRoom.SerialNumber 
            };
            Grid.SetColumn(newRoomButton, column);
            Grid.SetRow(newRoomButton, row);
            Grid.SetColumnSpan(newRoomButton, columnSpan);
            Grid.SetRowSpan(newRoomButton, rowSpan);
            Grid.SetZIndex(newRoomButton, 2);
            view.Grid.Children.Add(newRoomButton);
            view.Grid.UpdateLayout();

            roomSpace.Visibility = Visibility.Collapsed;
            this.Close();
        }
    }
}
