using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomInformation.xaml
    /// </summary>
    public partial class RoomInformation : Window
    {
        public RoomInformation(string roomName)
        {
            this.DataContext = new RoomInformationViewModel(this, roomName);
            InitializeComponent();
        }
    }
}
