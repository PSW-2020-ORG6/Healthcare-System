using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.PatientControllers;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
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
            RoomInitialization(floor.SerialNumber);
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
                Grid.SetColumnSpan(button, room.ColumnSpan);
                Grid.SetRowSpan(button, room.RowSpan);
                Grid.SetColumn(button, room.Column);
                Grid.SetRow(button, room.Row);
                room.Beds = bedController.GetByRoomSerialNumber(room.SerialNumber);
                foreach (Bed bed in room.Beds)
                {
                    if (bed.PatientSerialNumber != null) bed.Patient = patientController.GetById(bed.PatientSerialNumber);
                }
                room.RoomType = roomTypeController.GetById(room.RoomTypeSerialNumber);
                room.Equipment = equipmentController.GetByRoomSerialNumber(room.SerialNumber);
                room.Medinices = medicineController.GetByRoomSerialNumber(room.SerialNumber);

                RoomGrid.Children.Add(button);
                connections.Add(room.SerialNumber, button);
            }
            RoomGrid.UpdateLayout();
        }

    }
}
