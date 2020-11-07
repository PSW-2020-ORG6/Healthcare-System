using GraphicEditor.HelpClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.ViewModel
{
    public class CardiologyBuildingUserControlViewModel : BindableBase
    {
        private MapContentUserControlViewModel _parent;
        public MyICommand<string> NavCommand { get; private set; }
        public static CardiologyFirstFloorMapUserControlViewModel FirstFloor;
        public static CardiologySecondFloorMapUserControlViewModel SecondFloor;
        public BindableBase _floorViewModel;

        public CardiologyBuildingUserControlViewModel(MapContentUserControlViewModel parent)
        {
            _parent = parent;
            NavCommand = new MyICommand<string>(ChooseFloor);
            FirstFloor = new CardiologyFirstFloorMapUserControlViewModel();
            SecondFloor = new CardiologySecondFloorMapUserControlViewModel();
            _floorViewModel = FirstFloor;
        }

        public BindableBase FloorViewModel
        {
            get { return _floorViewModel; }
            set
            {
                SetProperty(ref _floorViewModel, value);
            }
        }

        private void ChooseFloor(string destination)
        {
            switch (destination)
            {
                case Constants.BACK:
                    _parent.ContentViewModel = MapContentUserControlViewModel.HospitalMap;
                    break;
                case Constants.BASEMENT:

                    break;
                case Constants.GROUND:

                    break;
                case Constants.FIRST:

                    break;
                case Constants.SECOND:

                    break;
                case Constants.THIRD:

                    break;
                case Constants.FOURTH:

                    break;
            }
        }
    }
}
