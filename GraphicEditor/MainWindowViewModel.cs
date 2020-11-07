using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;

namespace GraphicEditor
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private MapContentUserControlViewModel _mapContent = new MapContentUserControlViewModel();
        private LoginUserControlViewModel _loginPage = new LoginUserControlViewModel();
        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = _mapContent;
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
                    CurrentViewModel = _mapContent;
                    break;
                case Constants.LOGIN:
                    CurrentViewModel = _loginPage;
                    break;
            }
        }
    }
}
