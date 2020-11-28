using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomInformation.xaml
    /// </summary>
    public partial class RoomInformation : Window
    {
        public RoomInformation()
        {
            this.DataContext = new RoomInformationViewModel(this);
            InitializeComponent();
        }
    }
}
