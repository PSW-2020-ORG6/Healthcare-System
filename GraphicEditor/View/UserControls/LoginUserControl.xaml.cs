using GraphicEditor.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for LoginPageUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl(MainWindowViewModel vm)
        {
            InitializeComponent();
            this.DataContext = new LoginUserControlViewModel(vm);
        }
    }
}
