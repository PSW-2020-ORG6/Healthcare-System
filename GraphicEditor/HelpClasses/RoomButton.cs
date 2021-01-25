using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.HelpClasses
{
    public class RoomButton : Button
    {
        public Visibility TopDoor { get; set; }
        public Visibility RightDoor { get; set; }
        public Visibility BottomDoor { get; set; }
        public Visibility LeftDoor { get; set; }
        public MyICommand<Button> ShowRoomCommand { get; set; }
        public MyICommand<RoomButton> DeleteCommand { get; set; }

        private RoomController roomController = new RoomController();
        private Grid roomGrid;
        public Dictionary<string, RoomButton> connections;

        public RoomButton(Grid _roomGrid, Dictionary<string, RoomButton> _connections) : base()
        {
            this.DataContext = this;
            connections = _connections;
            TopDoor = Visibility.Collapsed;
            RightDoor = Visibility.Collapsed;
            BottomDoor = Visibility.Collapsed;
            LeftDoor = Visibility.Collapsed;
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)rd["RoomButtonStyle"];

            ShowRoomCommand = new MyICommand<Button>(ShowRoom);
            DeleteCommand = new MyICommand<RoomButton>(DeleteRoom);
            roomGrid = _roomGrid;
        }

        private void ShowRoom(Button roomButton)
        {
            if (MainWindow.TypeOfUser != TypeOfUser.Superintendent && MainWindow.TypeOfUser != TypeOfUser.Secretary)
            {
                new Warning().ShowDialog();
                return;
            }
            string serialNumber = (String)roomButton.Tag;

            Room room = roomController.GetById(serialNumber);

            
            if (room.IsBeingRenovated)
            {
                new WarningRenovatingRoom().ShowDialog();
                return;
            }
            new RoomInformation(roomController.GetBySerialNumber(serialNumber)).Show();
        }

        private void DeleteRoom(RoomButton roomButton)
        {
            if (MainWindow.TypeOfUser != TypeOfUser.Superintendent)
            {
                new Warning().ShowDialog();
                return;
            }
            string serialNumber = (String)roomButton.Tag;

            Room room = roomController.GetById(serialNumber);

            if (room.IsBeingRenovated)
            {
                new WarningRoomRenovationDeletion().ShowDialog();
                return;
            }

            new DeleteRoom(roomButton, roomGrid).ShowDialog();
        }
    }
}
