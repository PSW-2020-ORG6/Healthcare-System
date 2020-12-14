﻿using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using GraphicEditor.ViewModel;
using System.Windows.Controls;

namespace GraphicEditor
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        //private MapContentUserControlViewModel _mapContent = new MapContentUserControlViewModel();
        public CardiologyBuildingUserControl CardiologyBuilding;
        public CardiologyFirstFloorMapUserControl CardiologyFloor;
        public HospitalMapUserControl HospitalMap;
        public LoginUserControl LoginPage;
        private UserControl currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            

            LoginPage = new LoginUserControl(this);
            HospitalMap = new HospitalMapUserControl(this);
            CardiologyBuilding = new CardiologyBuildingUserControl(this);
            CurrentUserControl = HospitalMap;
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
