using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.ViewModel
{
    public class CardiologyFirstFloorMapUserControlViewModel : BindableBase
    {
        public MyICommand<Room> ShowRoomCommand { get; private set; }

        RoomDatabaseSql roomRepository = new RoomDatabaseSql();
        BedDatabaseSql bedRepository = new BedDatabaseSql();
        EquipmentDatabaseSql equipmentRepository = new EquipmentDatabaseSql();
        RoomTypeDatabaseSql roomTypeRepository = new RoomTypeDatabaseSql();

        public ResourceDictionary ResourceDictionary = new ResourceDictionary();

        public CardiologyFirstFloorMapUserControlViewModel()
        {
            ShowRoomCommand = new MyICommand<Room>(ShowRoom);
        }

        public void InitialGridRender()
        {
            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            foreach (Room room in roomRepository.GetAll())
            {
                Button button = new Button();
                button.Style = (Style)ResourceDictionary[room.Style];
                button.Name = room.Name;
                Grid.SetColumnSpan(button, room.ColumnSpan);
                Grid.SetRowSpan(button, room.RowSpan);
                Grid.SetColumn(button, room.Column);
                Grid.SetRow(button, room.Row);
                button.Command = ShowRoomCommand;
                button.CommandParameter = room;
                room.Beds = bedRepository.GetByRoomSerialNumber(room.SerialNumber);
                room.RoomType = roomTypeRepository.GetBySerialNumber(room.RoomTypeSerialNumber);
                room.Equipment = equipmentRepository.GetByRoomSerialNumber(room.SerialNumber);

                //HospitalMapGrid.Children.Add(button);
                //HospitalMapGrid.UpdateLayout();
            }
        }

        private void ShowRoom(Room room)
        {
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
