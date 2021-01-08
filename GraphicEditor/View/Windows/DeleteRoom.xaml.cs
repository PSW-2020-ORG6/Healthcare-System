using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for DeleteRoom.xaml
    /// </summary>
    public partial class DeleteRoom : Window
    {
        private RoomButton roomButton;
        private Grid grid;
        private RoomController roomController = new RoomController();
        public DeleteRoom(RoomButton _roomButton, Grid _grid)
        {
            InitializeComponent();
            roomButton = _roomButton;
            grid = _grid;
        }

        private void Cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            string roomSerialNumber = (string)roomButton.Tag;
            Room room = roomController.GetBySerialNumber(roomSerialNumber);
            roomController.DeleteRoom(room);
            grid.Children.Remove(roomButton);
            grid.UpdateLayout();
            this.Close();
        }
    }
}
