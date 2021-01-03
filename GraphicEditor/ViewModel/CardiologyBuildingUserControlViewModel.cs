using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

        public MyICommand<Floor> AddFloorCommand { get; private set; }
        public CardiologyFirstFloorMapUserControl FirstFloor;
        /* TODO add this without causing errors
        public CardiologySecondFloorMapUserControl SecondFloor;*/
        public CardiologyFirstFloorMapUserControl _floorViewModel;
        public Grid grid;
        private BuildingController buildingController = new BuildingController();
        private FloorDatabaseSql floorDatabaseSql = new FloorDatabaseSql();
        private RoomController roomController = new RoomController();

        // [Lemara98] Selector Class
        private Selector selector;

        public CardiologyBuildingUserControlViewModel(CardiologyBuildingUserControl buildingParent, MainWindowViewModel mapParent, Building building)
        {
            _mapParent = mapParent;
            _buildingParent = buildingParent;
            NavCommand = new MyICommand<string>(ChooseFloor);
            BuildingUpdateCommand = new MyICommand<Building>(editBuilding);
            AddFloorCommand = new MyICommand<Floor>(addRoom);
            
            /* TODO add this without causing errors
           SecondFloor = new CardiologySecondFloorMapUserControlViewModel();*/
            _floors = floorDatabaseSql.GetByBuildingSerialNumber(building.SerialNumber);
            _floors = _floors.OrderBy(f => Constants.FLOOR_NAMES.FindIndex(m => m.Equals(f.Name))).ToList();
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
                if (value > 0)
                {
                    SetProperty(ref _selectedFloorIndex, value);
                } 
                else
                {
                    SetProperty(ref _selectedFloorIndex, 0);
                }
                
                String cpy = new String(_floors[_selectedFloorIndex].Name);
                var paramArray = cpy.Split(' ');
                var param = paramArray[0].ToLower();
                _selectedFloor = _floors[_selectedFloorIndex];
                FloorName = _selectedFloor.Name;
                ChooseFloor(param);
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
            }
        }


        private void addRoom(Floor floor)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent || MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                if (FloorViewModel.selectedGridCells.Visibility != Visibility.Visible)
                {
                    new WarningNoSelectedCells().ShowDialog();
                    return;
                }

                bool overlapping = false;
                foreach (Room room in roomController.GetByFloorSerialNumber(_selectedFloor.SerialNumber))
                {
                    if (isOverlapping(room))
                    {
                        overlapping = true;
                        break;
                    }
                }

                if (overlapping)
                {
                    new WarningRoomOverlapping().ShowDialog();
                    return;
                }

                new AddRoom(_selectedFloor, FloorViewModel.selectedGridCells, FloorViewModel).ShowDialog();
            }
            else
            {
                new Warning().ShowDialog();
            }
        }

        private bool isOverlapping(Room room)
        {
            Border space = FloorViewModel.selectedGridCells;
            (int, int) topLeftCornerSpace = (Grid.GetColumn(space), Grid.GetRow(space));
            (int, int) topRightCornerSpace = (Grid.GetColumn(space) + Grid.GetColumnSpan(space) - 1, Grid.GetRow(space));
            (int, int) bottomLeftCornerSpace = (Grid.GetColumn(space), Grid.GetRow(space) + Grid.GetRowSpan(space) - 1);
            (int, int) bottomRightCornerSpace = (Grid.GetColumn(space) + Grid.GetColumnSpan(space) - 1, Grid.GetRow(space) + Grid.GetRowSpan(space) - 1);

            (int, int) topLeftCornerRoom = (room.Column, room.Row - 1);
            (int, int) topRightCornerRoom = (room.Column + room.ColumnSpan - 1, room.Row);
            (int, int) bottomLeftCornerRoom = (room.Column, room.Row + room.RowSpan - 1);
            (int, int) bottomRightCornerRoom = (room.Column + room.ColumnSpan - 1, room.Row + room.RowSpan - 1);

            // TopLeftCorner

            bool tl = topLeftCornerSpace.Item1 >= topLeftCornerRoom.Item1 && topLeftCornerSpace.Item1 <= topRightCornerRoom.Item1 &&
                       topLeftCornerSpace.Item2 >= topLeftCornerRoom.Item2 && topLeftCornerSpace.Item2 <= bottomLeftCornerRoom.Item2;

            // TopRightCorner

            bool tr = topRightCornerSpace.Item1 >= topLeftCornerRoom.Item1 && topRightCornerSpace.Item1 <= topRightCornerRoom.Item1 &&
                       topRightCornerSpace.Item2 >= topRightCornerRoom.Item2 && topRightCornerSpace.Item2 <= bottomRightCornerRoom.Item2;

            // BottomLeftCorner

            bool bl = bottomLeftCornerSpace.Item1 >= bottomLeftCornerRoom.Item1 && bottomLeftCornerSpace.Item1 <= bottomRightCornerRoom.Item1 &&
                       bottomLeftCornerSpace.Item2 >= topLeftCornerRoom.Item2 && bottomLeftCornerSpace.Item2 <= bottomLeftCornerRoom.Item2;

            // BottomRightCorner

            bool br = bottomRightCornerSpace.Item1 >= bottomLeftCornerRoom.Item1 && bottomRightCornerSpace.Item1 <= bottomRightCornerRoom.Item1 &&
                       bottomRightCornerSpace.Item2 >= topRightCornerRoom.Item2 && bottomRightCornerSpace.Item2 <= bottomRightCornerRoom.Item2;

            return tl || tr || bl || br;
        }

        private void editBuilding(Building _building)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent || MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                UpdateBuilding updateBuilding = new UpdateBuilding(_building);
                updateBuilding.ShowDialog();
                Building = buildingController.GetBySerialNumber(_building.SerialNumber);
                _floors = floorDatabaseSql.GetByBuildingSerialNumber(_building.SerialNumber);
                _floors = _floors.OrderBy(f => Constants.FLOOR_NAMES.FindIndex(m => m.Equals(f.Name))).ToList();
                OnPropertyChanged("Floors");
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

        private int sortFloorList(Floor x, Floor y)
        {
            int X = Constants.FLOOR_NAMES.FindIndex(n => n.Equals(x.Name));
            int Y = Constants.FLOOR_NAMES.FindIndex(n => n.Equals(y.Name));

            if (X <= Y) return X;
            else return Y;
        }
    }
}
