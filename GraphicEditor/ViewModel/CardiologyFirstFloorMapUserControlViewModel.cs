using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class CardiologyFirstFloorMapUserControlViewModel : BindableBase
    {
        public MyICommand<Room> ShowRoomCommand { get; private set; }

        RoomDatabaseSql roomRepository = new RoomDatabaseSql();
        BedDatabaseSql bedRepository = new BedDatabaseSql();
        EquipmentDatabaseSql equipmentRepository = new EquipmentDatabaseSql();
        RoomTypeDatabaseSql roomTypeRepository = new RoomTypeDatabaseSql();
        MedicineDatabaseSql medicineRepository = new MedicineDatabaseSql();
        PatientDatabaseSql patientRepository = new PatientDatabaseSql();

        MainWindowViewModel mapParent;
        CardiologyBuildingUserControlViewModel buildingParent;

        Grid RoomGrid;

        public ResourceDictionary ResourceDictionary = new ResourceDictionary();
        public Dictionary<string, Button> connections = new Dictionary<string, Button>();

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
            foreach (Room room in roomRepository.GetAll())
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
                room.Beds = bedRepository.GetByRoomSerialNumber(room.SerialNumber);
                foreach(Bed bed in room.Beds)
                {
                    if (bed.PatientSerialNumber != null) bed.Patient = patientRepository.GetBySerialNumber(bed.PatientSerialNumber);
                }
                room.RoomType = roomTypeRepository.GetBySerialNumber(room.RoomTypeSerialNumber);
                room.Equipment = equipmentRepository.GetByRoomSerialNumber(room.SerialNumber);
                room.Medinices = medicineRepository.GetByRoomSerialNumber(room.SerialNumber);

                RoomGrid.Children.Add(button);
                connections.Add(room.SerialNumber, button);
            }
            RoomGrid.UpdateLayout();
        }

        private void ShowRoom(Room room)
        {
            Button button = connections[room.SerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(0,0,0));
            if (MainWindow.TypeOfUser != TypeOfUser.Patient)
            {
                new RoomInformation(room).Show();
            }
            else
            {
                new Warning().ShowDialog();
            }
        }
    }
}
