using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomUpdate.xaml
    /// </summary>
    public partial class RoomUpdate : Window
    {
        public RoomUpdate(Room room, DialogAnswerListener<Room> dialogAnswerListener)
        {
            this.DataContext = new RoomUpdateViewModel(this, room, dialogAnswerListener);
            InitializeComponent();
        }
    }
}
