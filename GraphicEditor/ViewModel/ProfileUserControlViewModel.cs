using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using HealthClinicBackend.Backend.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.ViewModel
{
    public class ProfileUserControlViewModel : BindableBase
    {
        private string name;
        private string lastName;
        private string profileType;
        private string userName;
        private string password;
        private MainWindowViewModel parent;
        public string Name 
        { 
            get => name; 
            set
            {
                SetProperty(ref name, value);
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                SetProperty(ref lastName, value);
            }
        }
        public string ProfileType
        {
            get => profileType;
            set
            {
                SetProperty(ref profileType, value);
            }
        }
        public string UserName
        {
            get => userName;
            set
            {
                SetProperty(ref userName, value);
            }
        }
        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
            }
        }

        public MyICommand LogOutCommand { get; set; }

        public ProfileUserControlViewModel(MainWindowViewModel _parent) : base()
        {
            parent = _parent;
            if (MainWindow.UserProfile != null)
            {
                name = MainWindow.UserProfile.Name;
                lastName = MainWindow.UserProfile.Surname;
                profileType = MainWindow.TypeOfUser.ToString();
                userName = MainWindow.UserProfile.Email;
                password = MainWindow.UserProfile.Password;
            }
            else
            {
                name = "";
                lastName = "";
                profileType = MainWindow.TypeOfUser.ToString();
                userName = "";
                password = "";
            }

            LogOutCommand = new MyICommand(LogOut);
        }

        private void LogOut()
        {
            MainWindow.UserProfile = null;
            MainWindow.TypeOfUser = HealthClinicBackend.Backend.Model.Util.TypeOfUser.NoUser;
            parent.LoginPage = new LoginUserControl(parent);
            parent.CurrentUserControl = parent.LoginPage;
            parent.ProfilePage = new ProfileUserControl(parent);
        }
    }
}
