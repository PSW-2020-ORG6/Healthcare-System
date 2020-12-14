using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.ViewModel
{
    public class LoginUserControlViewModel : BindableBase
    {
        public MyICommand<PasswordBox> PasCommand { get; private set; }
        private string _userName = "asd";
        private string _pass = "asdasdad";
        private MainWindowViewModel _parent;
        private HospitalLogInController hospitalLogInController;
        public string UserName
        {
            get => _userName;
            set
            {
                SetProperty(ref _userName, value);
            }
        }

        public string Password
        {
            get => _pass;
            set
            {
                SetProperty(ref _pass, value);
            }
        }
        public LoginUserControlViewModel(MainWindowViewModel vm)
        {
            _parent = vm;
            PasCommand = new MyICommand<PasswordBox>(checkLogin);
            hospitalLogInController = new HospitalLogInController();
        }

        private void checkLogin(PasswordBox pass)
        {
            MainWindow.TypeOfUser = hospitalLogInController.GetUserType(UserName, pass.Password);
        }
    }
}
