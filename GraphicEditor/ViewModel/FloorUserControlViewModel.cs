using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Controller.PatientControllers;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Events.EventFloorChange;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace GraphicEditor.ViewModel
{
    public class FloorUserControlViewModel : BindableBase
    {
        public ResourceDictionary ResourceDictionary = new ResourceDictionary();
        public Dictionary<string, RoomButton> connections;  //= new Dictionary<string, RoomButton>();
        MainWindowViewModel mapParent;
        BuildingUserControlViewModel buildingParent;
        Grid RoomGrid;
        private GeometryGroup floorType;
        private RoomController roomController = new RoomController();
        private RoomTypeController roomTypeController = new RoomTypeController();
        private BedController bedController = new BedController();
        private EquipmentController equipmentController = new EquipmentController();
        private SuperintendentMedicineController medicineController = new SuperintendentMedicineController();
        private PatientController patientController = new PatientController();
        private RoomRenovationController roomRenovationController = new RoomRenovationController();
        private string floorSerialNumber;
        private string buildingStyle;
        private MainWindowViewModel parentViewModel;
        private BuildingUserControlViewModel myViewModel;
        private FloorChangeEventController floorChangeEventController = new FloorChangeEventController();

        public FloorUserControlViewModel(MainWindowViewModel _mapParent, BuildingUserControlViewModel _buildingParent, Grid grid, Floor floor, ref Dictionary<string, RoomButton> _connections)
        {
            mapParent = _mapParent;
            buildingParent = _buildingParent;
            buildingStyle = _buildingParent.Building.Style;
            connections = _connections;
            RoomGrid = grid;
            floorSerialNumber = floor.SerialNumber;
            RoomInitialization();
            FindFloorType();
            CreateFloorChangeEvent(floor);
        }

        public FloorUserControlViewModel(FloorUserControlViewModel viewModel)
        {
            mapParent = viewModel.mapParent;
            buildingParent = viewModel.buildingParent;
            buildingStyle = viewModel.buildingParent.Building.Style;
            RoomGrid = viewModel.RoomGrid;
            floorSerialNumber = viewModel.floorSerialNumber;
            connections = viewModel.connections;
            RoomInitialization();
            FindFloorType();
        }

        private void FindFloorType()
        {
            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/FloorClips.xaml", UriKind.RelativeOrAbsolute);
            switch (buildingParent.Building.Style)
            {
                case "RectangleBuildingButtonStyle":
                    floorType = (GeometryGroup)ResourceDictionary["RectangleFloor"];
                    break;
                case "SquareBuildingButtonStyle":
                    floorType = (GeometryGroup)ResourceDictionary["SquareFloor"];
                    break;
                case "TriangleBuildingButtonStyle":
                    floorType = (GeometryGroup)ResourceDictionary["TriangleFloor"];
                    break;
                case "UBuildingButtonStyle":
                    floorType = (GeometryGroup)ResourceDictionary["UFloor"];
                    break;
                case "HexagonBuildingButtonStyle":
                    floorType = (GeometryGroup)ResourceDictionary["HexagonFloor"];
                    break;
                case "HoleBuildingButtonStyle":
                    floorType = (GeometryGroup)ResourceDictionary["HoleFloor"];
                    break;
            }
        }

        public GeometryGroup FloorType
        {
            get => floorType;
        }

        public void RoomInitialization()
        {
            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            List<Room> floorRooms = roomController.GetByFloorSerialNumber(floorSerialNumber);
            RoomButton button1;
            foreach (Room room in floorRooms)
            {
                if (connections.ContainsKey(room.SerialNumber) && room.IsBeingRenovated && room.RoomRenovationSerialNumber != null)
                {
                    button1 = connections[room.SerialNumber];
                    connections.Remove(room.SerialNumber);
                    RoomGrid.Children.Remove(button1);
                    button1.Background = new SolidColorBrush(Color.FromRgb(252, 56, 56));
                    connections.Add(room.SerialNumber, button1);
                    RoomGrid.Children.Add(button1);
                    continue;
                }
                if (!connections.ContainsKey(room.SerialNumber) &&
                        (room.IsWaitingToBeRenovated || room.IsBeingRenovated) &&
                        room.RoomRenovationSerialNumber == null)
                {
                    continue;
                }
                if (connections.ContainsKey(room.SerialNumber)) continue;

                RoomButton button = new RoomButton(RoomGrid, connections);
                if (room.IsBeingRenovated) button.Background = new SolidColorBrush(Color.FromRgb(252, 56, 56));

                button.Style = (Style)ResourceDictionary[room.Style];
                button.Content = room.Name;
                button.TopDoor = (Visibility)room.TopDoorVisible;
                button.RightDoor = (Visibility)room.RightDoorVisible;
                button.BottomDoor = (Visibility)room.BottomDoorVisible;
                button.LeftDoor = (Visibility)room.LeftDoorVisible;
                button.Tag = room.SerialNumber;

                Grid.SetZIndex(button, 2);
                Position position = room.Position;
                Grid.SetColumnSpan(button, position.ColumnSpan);
                Grid.SetRowSpan(button, position.RowSpan);
                Grid.SetColumn(button, position.Column);
                Grid.SetRow(button, position.Row);
                room.Beds = bedController.GetByRoomSerialNumber(room.SerialNumber);
                foreach (Bed bed in room.Beds)
                {
                    if (bed.PatientSerialNumber != null) bed.Patient = patientController.GetById(bed.PatientSerialNumber);
                }

                RoomGrid.Children.Add(button);
                connections.Add(room.SerialNumber, button);

            }

            if (floorRooms.Count < connections.Count)
                foreach (string roomSerialNumber in connections.Keys)
                {
                    try
                    {
                        Room room = roomController.GetById(roomSerialNumber);
                        if (room == null) throw new Exception();
                    }
                    catch
                    {
                        RoomButton rb = connections[roomSerialNumber];
                        RoomGrid.Children.Remove(rb);
                        connections.Remove(roomSerialNumber);
                    }
                }
            RoomGrid.UpdateLayout();
        }

        private void TimeManaged()
        {
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(5);
            LiveTime.Tick += ExecuteRefresh;
            LiveTime.Start();
        }

        private void ExecuteRefresh(object sender, EventArgs e)
        {
            roomRenovationController.ExecuteRoomRenovation();
            RoomInitialization();
        }

        private void CreateFloorChangeEvent(Floor enteringFloor)
        {
            FloorChangeEventParams floor = new FloorChangeEventParams
            {
                UsernameSerialNbr = MainWindow.UserProfile.SerialNumber,
                BuildingSerialNbr = enteringFloor.BuildingSerialNumber,
                FloorSerialNbr = enteringFloor.SerialNumber
            };
            floorChangeEventController.LogEvent(floor);
        }
    }
}
