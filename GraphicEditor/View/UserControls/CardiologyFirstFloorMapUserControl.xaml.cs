using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for CardiologyFirstFloorMapUserControl.xaml
    /// </summary>
    public partial class CardiologyFirstFloorMapUserControl : UserControl
    {

        public CardiologyFirstFloorMapUserControl(MainWindowViewModel mapParent, CardiologyBuildingUserControlViewModel buildingParent)
        {
            InitializeComponent();
            this.DataContext = new CardiologyFirstFloorMapUserControlViewModel(mapParent, buildingParent, this.Grid);
        }
    }
}
