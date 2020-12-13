using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for CardiologyFirstFloorMapUserControl.xaml
    /// </summary>
    public partial class CardiologyFirstFloorMapUserControl : UserControl
    {
        public static Grid FloorGrid;

        public CardiologyFirstFloorMapUserControl()
        {
            this.DataContext = CardiologyBuildingUserControlViewModel.FirstFloor;
            InitializeComponent();
            FloorGrid = Grid;
        }
    }
}
