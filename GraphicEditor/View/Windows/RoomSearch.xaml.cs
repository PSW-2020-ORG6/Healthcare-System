using GraphicEditor.ViewModel;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for RoomSearch.xaml
    /// </summary>
    public partial class RoomSearch : Window
    {
        public RoomSearch(MainWindowViewModel vm)
        {
            InitializeComponent();
            this.DataContext = new RoomSearchViewModel(vm);  
        }
    }
}
