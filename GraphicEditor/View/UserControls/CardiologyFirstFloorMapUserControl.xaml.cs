using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    public partial class CardiologyFirstFloorMapUserControl : UserControl
    {
        public CardiologyFirstFloorMapUserControlViewModel Viewmodel;

        public CardiologyFirstFloorMapUserControl(MainWindowViewModel mapParent, CardiologyBuildingUserControlViewModel buildingParent, Floor floor)
        {
            InitializeComponent();
            Viewmodel = new CardiologyFirstFloorMapUserControlViewModel(mapParent, buildingParent, this.Grid, floor);
            this.DataContext = Viewmodel;
        }
    }
}
