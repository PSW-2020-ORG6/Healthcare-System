using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.ViewModel
{
    public class HospitalMapUserControlViewModel : BindableBase
    {
        private MapContentUserControlViewModel _parent;
        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<object> AddCommand { get; private set; }

        ResourceDictionary myResourceDictionary = new ResourceDictionary();

        public HospitalMapUserControlViewModel(MapContentUserControlViewModel parent)
        {
            _parent = parent;
            NavCommand = new MyICommand<string>(ChooseHospital);
            AddCommand = new MyICommand<object>(AddBuilding);
        }

        private void AddBuilding(object button)
        {
            Button but = (Button)button;
            System.Console.WriteLine(but.Content);
            if( but.Content.Equals("Empty field") )
            {
                AddBuildingViewModel.GetInstance().Button = but;
                (new AddBuilding()).ShowDialog();
            }
        }


        private void ChooseHospital(string destination)
        {
            switch (destination)
            {
                case Constants.EMERGENCY:

                    break;
                case Constants.CARDIOLOGY:
                    _parent.ContentViewModel = MapContentUserControlViewModel.CardiologyBuilding;
                    break;
                case Constants.ORTHOPEDICS:

                    break;
                case Constants.PEDIATRICS:

                    break;
                case Constants.DERMATOLOGY:

                    break;
                case Constants.ONCOLOGY:

                    break;
            }
        }
    }
}
