using System.Collections.Generic;
using System.Windows;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomSearch.xaml
    /// </summary>
    public partial class RoomSearch : Window
    {
        private IRoomRepository roomRepository = new RoomDatabaseSql();
        private IFloorRepository floorRepository = new FloorDatabaseSql();
        private IBuildingRepository buildingRepository = new BuildingDatabaseSql();

        public RoomSearch()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string roomName = RoomNameTextBox.Text;
            List<Room> rooms = roomRepository.GetByName(roomName);
            SearchedRoomsTextBlock.Text = ReportOnFoundRooms(roomName, rooms);
            RoomNameTextBox.Text = null;
        }

        public string ReportOnFoundRooms(string roomName, List<Room> rooms)
        {
            string resultOfSearch = roomName + " found at: ";
            if (rooms == null)
                return resultOfSearch += "nowhere.";
            int roomCounter = rooms.Count;
            if (roomCounter != 0)
            {
                int checkCounter = 0;
                foreach (Room room in rooms)
                {
                    resultOfSearch = PlaceOfFoundRooms(resultOfSearch, room);
                    if (++checkCounter == roomCounter)
                        return resultOfSearch += ".";
                    else
                        resultOfSearch += ",";
                }
            }

            return resultOfSearch += "nowhere.";
        }

        private string PlaceOfFoundRooms(string resultOfSearch, Room room)
        {
            Floor floor = floorRepository.GetById(room.FloorSerialNumber);
            Building building = buildingRepository.GetById(room.BuildingSerialNumber);
            resultOfSearch += floor.Name + " in " + building.Name;
            return resultOfSearch;
        }
    }
}