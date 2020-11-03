using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;

namespace GraphicEditor
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BuildingMapUserControlViewModel _buildingMap = new BuildingMapUserControlViewModel();
        private HospitalMapUserControlViewModel _hospitalMap = new HospitalMapUserControlViewModel();
        private LoginUserControlViewModel _loginPage = new LoginUserControlViewModel();
        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = _hospitalMap;
        }

        public BindableBase CurrentViewModel
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
                    CurrentViewModel = _hospitalMap;
                    break;
                case Constants.LOGIN:
                    CurrentViewModel = _loginPage;
                    break;
            }
        }
    }
}
