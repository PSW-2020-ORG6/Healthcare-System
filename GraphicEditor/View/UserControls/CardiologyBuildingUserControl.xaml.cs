using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for CardiologyBuildingUserControl.xaml
    /// </summary>
    public partial class CardiologyBuildingUserControl : UserControl
    {
        public CardiologyBuildingUserControl()
        {
            this.DataContext = MapContentUserControlViewModel.CardiologyBuilding;
            InitializeComponent();
        }
    }
}
