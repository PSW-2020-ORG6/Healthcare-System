using GraphicEditor.Repositories;
using health_clinic_class_diagram.Backend.Model.Hospital;
using Model.Hospital;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomSearch.xaml
    /// </summary>
    public partial class RoomSearch : Window
    {
        private RoomRepository roomRepository = new RoomRepository();
        private FloorRepository floorRepository = new FloorRepository();
        private BuildingRepository buildingRepository = new BuildingRepository();

        public RoomSearch()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string roomName = RoomNameTextBox.Text;
            List<Room> rooms = roomRepository.GetRoomsByName(roomName);
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
            Floor floor = floorRepository.GetFloorBySerialNumber(room.FloorSerialNumber);
            Building building = buildingRepository.GetBuildingBySerialNumber(room.BuildingSerialNumber);
            resultOfSearch += floor.Name + " in " + building.Name;
            return resultOfSearch;
        }
    }
}
