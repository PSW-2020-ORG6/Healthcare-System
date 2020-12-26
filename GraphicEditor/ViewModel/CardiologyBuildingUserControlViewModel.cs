using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GraphicEditor.ViewModel
{
    public class CardiologyBuildingUserControlViewModel : BindableBase, DialogAnswerListener<Building>
    {
        private CardiologyBuildingUserControl _buildingParent;
        private MainWindowViewModel _mapParent;
        private List<Floor> _floors = new List<Floor>();
        private int _selectedFloorIndex;
        private Floor _selectedFloor;
        private Building _building;
        private string _floorName;
        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<Building> BuildingUpdateCommand { get; private set; }
        public CardiologyFirstFloorMapUserControl FirstFloor;
        /* TODO add this without causing errors
        public CardiologySecondFloorMapUserControl SecondFloor;*/
        public CardiologyFirstFloorMapUserControl _floorViewModel;
        public Grid grid;
        private FloorDatabaseSql floorDatabaseSql = new FloorDatabaseSql();

        public CardiologyBuildingUserControlViewModel(CardiologyBuildingUserControl buildingParent, MainWindowViewModel mapParent, Building building)
        {
            _mapParent = mapParent;
            _buildingParent = buildingParent;
            NavCommand = new MyICommand<string>(ChooseFloor);
            BuildingUpdateCommand = new MyICommand<Building>(editBuilding);
            
            /* TODO add this without causing errors
           SecondFloor = new CardiologySecondFloorMapUserControlViewModel();*/
            _floors = floorDatabaseSql.GetByBuildingSerialNumber(building.SerialNumber);
            
            _building = building;

           List<Floor> _buildingFloors = new List<Floor>();
            foreach (Floor fl in floorDatabaseSql.GetByBuildingSerialNumber(_building.SerialNumber))
            {
                _buildingFloors.Add(fl);
            }
           //_building = new Building("Cardiology", "Color Blue");
            _selectedFloor = _buildingFloors[0];
            _selectedFloorIndex = 0;
            _floorName = _selectedFloor.Name;
            _floorViewModel = new CardiologyFirstFloorMapUserControl(_mapParent, this, _selectedFloor);
        }

       public CardiologyFirstFloorMapUserControl FloorViewModel
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
               List<string> floorNames = new List<string>();
               foreach (Floor f in _floors)
                {
                    floorNames.Add(f.Name);
                }
               return floorNames;
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

       public int SelectedFloorIndex
       {
           get { return _selectedFloorIndex; }
           set
           {
               if (value != null)
               {
                   SetProperty(ref _selectedFloorIndex, value);
                   String cpy = new String(_floors[_selectedFloorIndex].Name);
                   var paramArray = cpy.Split(' ');
                   var param = paramArray[0].ToLower();
                    _selectedFloor = _floors[_selectedFloorIndex];
                    FloorName = _selectedFloor.Name;
                   ChooseFloor(param);
               }
           }
       }

        public string FloorName
        {
            get { return _floorName; }
            set
            {
                SetProperty(ref _floorName, value);
            }
        }

       private void ChooseFloor(string destination)
       {
           switch (destination)
           {
               case Constants.BACK:
                   _mapParent.CurrentUserControl = _mapParent.HospitalMap;
                   break;
               default:
                   FloorViewModel = new CardiologyFirstFloorMapUserControl(_mapParent, this, _selectedFloor);
                    break;
               /* TODO add this without causing errors
               case Constants.SECOND:
                   FloorViewModel = SecondFloor;
                   break;*/
        }
    }

        private void editBuilding(Building _building)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent || MainWindow.TypeOfUser == TypeOfUser.NoUser)
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
