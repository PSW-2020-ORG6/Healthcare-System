using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    public partial class RoomSearch : Window
    {
        public RoomSearch(MainWindowViewModel vm)
        {
            InitializeComponent();
            this.DataContext = new RoomSearchViewModel(vm);  
        }
    }
}
