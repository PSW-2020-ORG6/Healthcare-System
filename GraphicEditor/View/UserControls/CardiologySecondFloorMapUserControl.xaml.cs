using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for CardiologySecondFloorMapUserControl.xaml
    /// </summary>
    public partial class CardiologySecondFloorMapUserControl : UserControl
    {
        public CardiologySecondFloorMapUserControl()
        {
            this.DataContext = CardiologyBuildingUserControlViewModel.SecondFloor;
            InitializeComponent();
        }
    }
}
