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
    public class CardiologyFirstFloorMapUserControlViewModel : BindableBase
    {
        public ResourceDictionary ResourceDictionary = new ResourceDictionary();
        public Dictionary<string, Button> connections = new Dictionary<string, Button>();
        MainWindowViewModel mapParent;
        CardiologyBuildingUserControlViewModel buildingParent;
        Grid RoomGrid;
        private RoomController roomController = new RoomController();
        private RoomTypeController roomTypeController = new RoomTypeController();
        private BedController bedController = new BedController();
        private EquipmentController equipmentController = new EquipmentController();
        private SuperintendentMedicineController medicineController = new SuperintendentMedicineController();
        private PatientController patientController = new PatientController();
        private Floor floor;
        private string buildingStyle;

        public MyICommand<Button> ShowRoomCommand { get; private set; }
        public MyICommand<Button> DeleteCommand { get; private set; }

        public CardiologyFirstFloorMapUserControlViewModel(MainWindowViewModel _mapParent, CardiologyBuildingUserControlViewModel _buildingParent, Grid grid, Floor floor)
        {
            mapParent = _mapParent;
            buildingParent = _buildingParent;
            buildingStyle = _buildingParent.Building.Style;
            ShowRoomCommand = new MyICommand<Button>(ShowRoom);
            DeleteCommand = new MyICommand<Button>(DeleteRoom);
            RoomGrid = grid;
            RoomInitialization(floor.SerialNumber);
        }

        public void RoomInitialization(string floorSerialNumber)
        {
            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            List<Room> floorRooms = roomController.GetByFloorSerialNumber(floorSerialNumber);
            foreach (Room room in floorRooms)
            {
                Button button = new Button();
                button.Style = (Style)ResourceDictionary[room.Style];
                button.Content = room.Name;
                button.Tag = room.SerialNumber;
                Grid.SetZIndex(button, 2);
                Grid.SetColumnSpan(button, room.ColumnSpan);
                Grid.SetRowSpan(button, room.RowSpan);
                Grid.SetColumn(button, room.Column);
                Grid.SetRow(button, room.Row);
                button.Command = ShowRoomCommand;
                button.CommandParameter = room;
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

        private void ShowRoom(Button roomButton)
        {
            string[] split = roomButton.Content.ToString().Split(" ");

            if (MainWindow.TypeOfUser != TypeOfUser.Patient)
            {
                new RoomInformation(roomController.GetById(split[split.Length - 1])).Show();
            }
            else
            {
                new Warning().ShowDialog();
            }
        }

        private void DeleteRoom(Button roomButton)
        {
            new DeleteRoom(roomButton, RoomGrid).ShowDialog();
        }

        private void ClearHighlightOnRoom(Room room)
        {
            Button button = connections[room.SerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
    }
}
