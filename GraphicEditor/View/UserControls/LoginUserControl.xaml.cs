using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl(MainWindowViewModel vm)
        {
            InitializeComponent();
            this.DataContext = new LoginUserControlViewModel(vm);
        }
    }
}
