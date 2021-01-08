﻿using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using System.Windows.Controls;

namespace GraphicEditor
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        /* TODO add this without causing errors
        private MapContentUserControlViewModel _mapContent = new MapContentUserControlViewModel();*/
        public BuildingUserControl CardiologyBuilding;
        public HospitalMapUserControl HospitalMap;
        public LoginUserControl LoginPage;
        private UserControl currentViewModel;
        public MainWindow mainWindow;

        public MainWindowViewModel(MainWindow _mainWindow)
        {
            NavCommand = new MyICommand<string>(OnNav);
            LoginPage = new LoginUserControl(this);
            HospitalMap = new HospitalMapUserControl(this);

            mainWindow = _mainWindow;
            CurrentUserControl = LoginPage;
        }

        public UserControl CurrentUserControl
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case Constants.MAP:
                    CurrentUserControl = HospitalMap;
                    break;
                case Constants.LOGIN:
                    CurrentUserControl = LoginPage;
                    break;
                case Constants.BUILDING:
                    CurrentUserControl = CardiologyBuilding;
                    break;
            }
        }
    }
}
