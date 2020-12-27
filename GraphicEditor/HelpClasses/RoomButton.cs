using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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

        public RoomButton(Grid _roomGrid) : base()
        {
            this.DataContext = this;
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
            string serialNumber = (String)roomButton.Tag;

            if (MainWindow.TypeOfUser != TypeOfUser.Patient)
            {
                new RoomInformation(roomController.GetBySerialNumber(serialNumber)).Show();
            }
            else
            {
                new Warning().ShowDialog();
            }
        }

        private void DeleteRoom(RoomButton roomButton)
        {
            new DeleteRoom(roomButton, roomGrid).ShowDialog();
        }
    }
}
