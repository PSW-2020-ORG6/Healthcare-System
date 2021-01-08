using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller.PatientControllers;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class FloorUserControlViewModel : BindableBase
    {
        public ResourceDictionary ResourceDictionary = new ResourceDictionary();
        public Dictionary<string, RoomButton> connections = new Dictionary<string, RoomButton>();
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
        private Floor floor;
        private string buildingStyle;
        private MainWindowViewModel parentViewModel;
        private BuildingUserControlViewModel myViewModel;

        public FloorUserControlViewModel(MainWindowViewModel _mapParent, BuildingUserControlViewModel _buildingParent, Grid grid, Floor floor)
        {
            mapParent = _mapParent;
            buildingParent = _buildingParent;
            buildingStyle = _buildingParent.Building.Style;
            RoomGrid = grid;
            FindFloorType();
            RoomInitialization(floor.SerialNumber);
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
            //set
            //{
            //    SetProperty(ref floorType, value);
            //}
        }

        public void RoomInitialization(string floorSerialNumber)
        {
            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            List<Room> floorRooms = roomController.GetByFloorSerialNumber(floorSerialNumber);
            foreach (Room room in floorRooms)
            {
                RoomButton button = new RoomButton(RoomGrid);
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
                Room r = new Room(room.Name, room.Id, room.FloorSerialNumber, room.RoomTypeSerialNumber,
                    room.Position, room.Style, equipmentController.GetByRoomSerialNumber(room.SerialNumber),
                    medicineController.GetByRoomSerialNumber(room.SerialNumber), roomTypeController.GetById(room.RoomTypeSerialNumber));
                room.Beds = bedController.GetByRoomSerialNumber(room.SerialNumber);
                foreach (Bed bed in room.Beds)
                {
                    if (bed.PatientSerialNumber != null) bed.Patient = patientController.GetById(bed.PatientSerialNumber);
                }

                RoomGrid.Children.Add(button);
                connections.Add(room.SerialNumber, button);
            }
            RoomGrid.UpdateLayout();
        }

    }
}
