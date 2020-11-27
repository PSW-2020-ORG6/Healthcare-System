using GraphicEditor.HelpClasses;
using System;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel
{
    public class CardiologyBuildingUserControlViewModel : BindableBase
    {
        private MapContentUserControlViewModel _parent;
        private List<string> _floors = new List<string>(Constants.FLOOR_MAP.Values);
        private string _selectedFloor = Constants.FLOOR_MAP[Constants.FIRST];
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

        public List<string> Floors
        {
            get
            {
                return _floors;
            }
        }

        public string SelectedFloor
        {
            get { return _selectedFloor; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _selectedFloor, value);
                    String cpy = String.Copy(_selectedFloor);
                    var paramArray = cpy.Split(' ');
                    var param = paramArray[0].ToLower();
                    ChooseFloor(param);
                }
            }
        }

        private void ChooseFloor(string destination)
        {
            switch (destination)
            {
                case Constants.BACK:
                    _parent.ContentViewModel = MapContentUserControlViewModel.HospitalMap;
                    break;
                case Constants.FIRST:
                    FloorViewModel = FirstFloor;
                    break;
                case Constants.SECOND:
                    FloorViewModel = SecondFloor;
                    break;
            }
        }
    }
}
