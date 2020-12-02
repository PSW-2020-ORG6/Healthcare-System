﻿using GraphicEditor.Repositories;
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

        public static string ReportOnFoundRooms(string roomName, List<Room> rooms)
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
                    resultOfSearch += room.FloorSerialNumber + " in " + room.BuildingSerialNumber;
                    if (++checkCounter == roomCounter)
                        return resultOfSearch += ".";
                    else
                        resultOfSearch += ",";
                }
            }
            return resultOfSearch += "nowhere.";
        }
    }
}
