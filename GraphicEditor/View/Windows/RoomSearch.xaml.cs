using GraphicEditor.Repositories;
using health_clinic_class_diagram.Backend.Model.Hospital;
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

        public RoomSearch()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string roomName = RoomNameTextBox.Text;
            List<RoomGEA> rooms = roomRepository.GetRoomsByName(roomName);
            SearchedRoomsTextBlock.Text = ReportOnFoundRooms(roomName, rooms);
            RoomNameTextBox.Text = null;
        }

        private string ReportOnFoundRooms(string roomName, List<RoomGEA> rooms)
        {
            string resultOfSearch = roomName + " found at: ";
            int roomCounter = rooms.Count;
            if (roomCounter != 0)
            {
                int checkCounter = 0;
                foreach (RoomGEA room in rooms)
                {
                    resultOfSearch += room.FloorName + " in " + room.BuildingName;
                    if (++checkCounter == roomCounter)
                        return resultOfSearch += ".";
                    else
                        resultOfSearch += ",";
                }
            }
            return resultOfSearch += "nowhere.";
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new RoomSearch().Show();
        }
    }
}
