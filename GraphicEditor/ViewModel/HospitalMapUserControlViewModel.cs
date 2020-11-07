using GraphicEditor.HelpClasses;

namespace GraphicEditor.ViewModel
{


    public class HospitalMapUserControlViewModel : BindableBase
    {
        private MapContentUserControlViewModel _parent;
        public MyICommand<string> NavCommand { get; private set; }

        public HospitalMapUserControlViewModel(MapContentUserControlViewModel parent)
        {
            _parent = parent;
            NavCommand = new MyICommand<string>(ChooseHospital);
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
