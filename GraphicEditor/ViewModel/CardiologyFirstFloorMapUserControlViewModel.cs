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

        public MyICommand<Room> ShowRoomCommand { get; private set; }

        public CardiologyFirstFloorMapUserControlViewModel(MainWindowViewModel _mapParent, CardiologyBuildingUserControlViewModel _buildingParent, Grid grid)
        {
            mapParent = _mapParent;
            buildingParent = _buildingParent;
            ShowRoomCommand = new MyICommand<Room>(ShowRoom);
            RoomGrid = grid;
            InitialGridRender();
        }

        public void InitialGridRender()
        {
            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            foreach (Room room in roomController.GetAll())
            {
                Button button = new Button();
                button.Style = (Style)ResourceDictionary[room.Style];
                button.Content = room.Name;
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

        private void ShowRoom(Room room)
        {
            ClearHighlightOnRoom(room);
            if (MainWindow.TypeOfUser != TypeOfUser.Patient)
            {
                new RoomInformation(room).Show();
            }
            else
            {
                new Warning().ShowDialog();
            }
        }

        private void ClearHighlightOnRoom(Room room)
        {
            Button button = connections[room.SerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
    }
}
