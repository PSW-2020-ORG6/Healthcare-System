using GraphicEditor.HelpClasses;
using health_clinic_class_diagram.Backend.Model.Hospital;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphicEditor.View.Windows;
using System.Threading.Tasks;

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
            BuildingUpdateCommand= new MyICommand<Building>(editBuilding);
            FirstFloor = new CardiologyFirstFloorMapUserControlViewModel();
            SecondFloor = new CardiologySecondFloorMapUserControlViewModel();
            _floorViewModel = FirstFloor;

            List<Floor> _buildingFloors = new List<Floor>();

            _building = new Building("123", "Cardiology", _buildingFloors, "Color Blue", "Style");
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
            Building b = new Building(Building.Id, Building.Name, Building.Floors, Building.Color, Building.Shape);
            BuildingUpdate r = new BuildingUpdate(b, this);
            r.ShowDialog();
            
        }

        public void onConfirmUpdate(Building building)
        {
            Building.Id = building.Id;
            Building.Name = building.Name;
            Building.Floors = building.Floors;
            Building.Color = building.Color;
            Building.Shape = building.Shape;
            OnPropertyChanged("Building");
        }

        public void onCancelUpdate()
        {
            
        }
    }
}
