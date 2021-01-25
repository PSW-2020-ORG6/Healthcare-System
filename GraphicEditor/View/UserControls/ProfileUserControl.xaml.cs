using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for ProfileUserControl.xaml
    /// </summary>
    public partial class ProfileUserControl : UserControl
    {
        public ProfileUserControl(MainWindowViewModel mainWindowViewModel)
        {
            this.DataContext = new ProfileUserControlViewModel(mainWindowViewModel);
            InitializeComponent();
        }
    }
}
