using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    public partial class CardiologyFirstFloorMapUserControl : UserControl
    {
        public CardiologyFirstFloorMapUserControlViewModel Viewmodel;

        public CardiologyFirstFloorMapUserControl(MainWindowViewModel mapParent, 
            CardiologyBuildingUserControlViewModel buildingParent)
        {
            InitializeComponent();
            Viewmodel = new CardiologyFirstFloorMapUserControlViewModel(mapParent, buildingParent, this.Grid);
            this.DataContext = Viewmodel;
        }
    }
}
