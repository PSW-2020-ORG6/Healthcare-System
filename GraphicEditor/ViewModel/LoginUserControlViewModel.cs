using GraphicEditor.HelpClasses;
using System;
using System.Security;
using System.Windows.Controls;
using health_clinic_class_diagram;
using health_clinic_class_diagram.Backend.Controller;
using health_clinic_class_diagram.Backend.Model;
using health_clinic_class_diagram.Backend.Model.Util;

namespace GraphicEditor.ViewModel
{
    public class LoginUserControlViewModel : BindableBase
    {
        public MyICommand<PasswordBox> PasCommand { get; private set; } 
        private string _userName = "asd";
        private string _pass = "asdasdad";
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
                SetProperty(ref _pass,value);
            }
        }
        public LoginUserControlViewModel()
        {
            PasCommand = new MyICommand<PasswordBox>(checkLogin);
            hospitalLogInController = new HospitalLogInController();
        }

        private void checkLogin(PasswordBox pass)
        {
            //repository is not implemented yet
            //Console.WriteLine(hospitalLogInController.GetUserType(UserName,pass.Password));
        }
    }
}
