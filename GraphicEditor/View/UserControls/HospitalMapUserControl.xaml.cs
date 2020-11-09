using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for HospitalMapUserControl.xaml
    /// </summary>
    public partial class HospitalMapUserControl : UserControl
    {
        public HospitalMapUserControl()
        {
            this.DataContext = MapContentUserControlViewModel.HospitalMap;
            InitializeComponent();
        }
    }
}
