using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using health_clinic_class_diagram.Backend.Model.Hospital;
using health_clinic_class_diagram.Backend.Model.Util;
using System;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel
{
    public class CardiologyBuildingUserControlViewModel : BindableBase, DialogAnswerListener<Building>
    {
        private MapContentUserControlViewModel _parent;
        private List<string> _floors = new List<string>(Constants.FLOOR_MAP.Values);
        private string _selectedFloor = Constants.FLOOR_MAP[Constants.FIRST];
        private Building _building;
        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<Building> BuildingUpdateCommand { get; private set; }

        public static CardiologyFirstFloorMapUserControlViewModel FirstFloor;
        public static CardiologySecondFloorMapUserControlViewModel SecondFloor;
        public BindableBase _floorViewModel;

        public CardiologyBuildingUserControlViewModel(MapContentUserControlViewModel parent)
        {
            _parent = parent;
            NavCommand = new MyICommand<string>(ChooseFloor);
            BuildingUpdateCommand = new MyICommand<Building>(editBuilding);
            FirstFloor = new CardiologyFirstFloorMapUserControlViewModel();
            SecondFloor = new CardiologySecondFloorMapUserControlViewModel();
            _floorViewModel = FirstFloor;

            List<Floor> _buildingFloors = new List<Floor>();

            _building = new Building("Cardiology", "Color Blue");
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

        public Building Building
        {
            get
            {
                return _building;
            }
            set
            {
                SetProperty(ref _building, value);
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

        private void editBuilding(Building _building)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.SUPERINTENDENT || MainWindow.TypeOfUser == TypeOfUser.NO_USER)
            {
                Building b = new Building(Building.Name, Building.Color);
                BuildingUpdate r = new BuildingUpdate(b, this);
                r.ShowDialog();
            }
            else
            {
                new Warning().ShowDialog();
            }
        }

        public void onConfirmUpdate(Building building)
        {
            Building.Name = building.Name;
            Building.Color = building.Color;
            OnPropertyChanged("Building");
        }
    }
}
