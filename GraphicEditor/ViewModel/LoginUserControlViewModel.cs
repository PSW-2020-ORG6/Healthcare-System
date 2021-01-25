using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller;
using HealthClinicBackend.Backend.Model.Util;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

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
            if (MainWindow.TypeOfUser != TypeOfUser.NoUser)
            {
                MainWindow.UserProfile = hospitalLogInController.GetUserProfile(UserName, pass.Password);
                MessageBox.Show("You have succesfully logged in. To logout go to Profile page", "LOGIN SUCCESSFUL");
                _parent.CurrentUserControl = _parent.HospitalMap;
                _parent.ProfilePage = new View.UserControls.ProfileUserControl(_parent);
                UserName = "";
                Password = "";
            }
            else if (MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                MessageBox.Show("Enter Email and Password again", "LOGIN FAILED");
            }
        }
    }
}
