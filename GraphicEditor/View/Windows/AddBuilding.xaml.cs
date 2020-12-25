using GraphicEditor.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.Windows
{
    public partial class AddBuilding : Window
    {
        public AddBuilding(Button but)
        {
            this.DataContext = new AddBuildingViewModel(this, but);
            InitializeComponent();
        }
    }
}
