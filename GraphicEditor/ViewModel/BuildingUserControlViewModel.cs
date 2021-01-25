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
    public class BuildingUserControlViewModel : BindableBase, DialogAnswerListener<Building>
    {
        private BuildingUserControl _buildingParent;
        private MainWindowViewModel _mapParent;
        private List<Floor> _floors = new List<Floor>();
        private int _selectedFloorIndex;
        private Floor _selectedFloor;
        private Building _building;
        private string _floorName;
        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<Building> BuildingUpdateCommand { get; private set; }

        public MyICommand<Floor> AddRoomCommand { get; private set; }

        public MyICommand<Floor> RenovateRoomCommand { get; private set; }

        public FloorUserControl FirstFloor;
        public FloorUserControl _floorViewModel;
        public Grid grid;
        private BuildingController buildingController = new BuildingController();
        private FloorDatabaseSql floorDatabaseSql = new FloorDatabaseSql();
        private RoomController roomController = new RoomController();

        public BuildingUserControlViewModel(BuildingUserControl buildingParent, MainWindowViewModel mapParent, Building building)
        {
            _mapParent = mapParent;
            _buildingParent = buildingParent;
            NavCommand = new MyICommand<string>(ChooseFloor);
            BuildingUpdateCommand = new MyICommand<Building>(editBuilding);
            AddRoomCommand = new MyICommand<Floor>(addRoom);
            RenovateRoomCommand = new MyICommand<Floor>(RenovateRoom);

            /* TODO add this without causing errors
           SecondFloor = new CardiologySecondFloorMapUserControlViewModel();*/
            _floors = floorDatabaseSql.GetByBuildingSerialNumber(building.SerialNumber);
            _floors = _floors.OrderBy(f => Constants.FLOOR_NAMES.FindIndex(m => m.Equals(f.Name))).ToList();
            _building = building;

            _selectedFloor = _floors[0];
            _selectedFloorIndex = 0;
            _floorName = _selectedFloor.Name;
            _floorViewModel = new FloorUserControl(_mapParent, this, _selectedFloor);
        }

        public FloorUserControl FloorViewModel
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
                    FloorViewModel = new FloorUserControl(_mapParent, this, _selectedFloor);
                    break;
            }
        }

        private void addRoom(Floor floor)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent)
            {
                if (FloorViewModel.selectedGridCells.Visibility != Visibility.Visible)
                {
                    new WarningNoSelectedCells().ShowDialog();
                    return;
                }

                bool overlapping = false;
                foreach (Room room in roomController.GetByFloorSerialNumber(_selectedFloor.SerialNumber))
                {
                    if (IsOverlapping(room))
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

        private void RenovateRoom(Floor floor)
        {
            if (MainWindow.TypeOfUser != TypeOfUser.Superintendent)
            {
                new Warning().ShowDialog();
                return;
            }

            if (FloorViewModel.selectedGridCells.Visibility != Visibility.Visible)
            {
                new WarningNoSelectedCells().ShowDialog();
                return;
            }

            List<Room> selectedRooms = new List<Room>();
            foreach (Room room in roomController.GetByFloorSerialNumber(_selectedFloor.SerialNumber))
            {
                if (IsOverlapping(room))
                {
                    selectedRooms.Add(room);
                }
            }

            if (selectedRooms.Count == 0)
            {
                new WarningNoRoomSelected().ShowDialog();
                return;
            }

            foreach(Room room in selectedRooms)
            {
                if (room.RoomRenovationSerialNumber != null) new WarningRenovationAlreadyScheduled().ShowDialog();
            }

            if(IsAllInTouch(selectedRooms))
            {
                if (selectedRooms.Count == 1) new BasicRoomRenovation(_selectedFloor, selectedRooms[0]).ShowDialog();
                else new ComplexRoomRenovation(_selectedFloor, selectedRooms).ShowDialog();
            }
            else
            {
                new WarningRoomsNotTouching().ShowDialog();
                return;
            }
            
        }

        private bool IsAllInTouch(List<Room> selectedRooms)
        {
            if (selectedRooms.Count == 0) return false;

            // Joined room Position

            Room firstRoom = selectedRooms[0];
            Position position = firstRoom.Position;
            (int, int) topLeftRoom1 = (position.Column, position.Row);
            (int, int) bottomRightRoom1 = (position.Column + position.ColumnSpan - 1, position.Row + position.RowSpan - 1);

            List<Room> newList = new List<Room>(selectedRooms);
            newList.Remove(firstRoom);
            
            return recursiveAllInTouchFunction(topLeftRoom1, bottomRightRoom1, newList);
        }

        private bool recursiveAllInTouchFunction((int, int) topLeftRoom1, (int, int) bottomRightRoom1, List<Room> selectedRooms)
        {
            if (selectedRooms.Count == 0) return true;

            foreach (Room roomFromList2 in selectedRooms)
            {
                Position position = roomFromList2.Position;
                (int, int) topLeftRoom2 = (position.Column, position.Row);
                (int, int) bottomRightRoom2 = (position.Column + position.ColumnSpan - 1, position.Row + position.RowSpan - 1);
                bool contact = isBorderHavingContact(topLeftRoom1, bottomRightRoom1, topLeftRoom2, bottomRightRoom2);
                if (contact)
                {
                    topLeftRoom1 = (Math.Min(topLeftRoom1.Item1, topLeftRoom2.Item1), Math.Min(topLeftRoom1.Item2, topLeftRoom2.Item2));
                    bottomRightRoom1 = (Math.Max(bottomRightRoom1.Item1, bottomRightRoom2.Item1), Math.Max(bottomRightRoom1.Item2, bottomRightRoom2.Item2));
                    List<Room> newList = new List<Room>(selectedRooms);
                    newList.Remove(roomFromList2);

                    return recursiveAllInTouchFunction(topLeftRoom1, bottomRightRoom1, newList);
                }
            }
            return false;
        }

        private bool isBorderHavingContact((int, int) topLeftRoom1, (int, int) bottomRightRoom1, (int, int) topLeftRoom2, (int, int) bottomRightRoom2)
        {
            List<(int, int)> roomCorners1 = new List<(int, int)>();

            for (int i = topLeftRoom1.Item1; i <= bottomRightRoom1.Item1; ++i)
                for (int j = topLeftRoom1.Item2; j <= bottomRightRoom1.Item2; ++j)
                    roomCorners1.Add((i, j));

            List<(int, int)> roomCorners2 = new List<(int, int)>();

            for (int i = topLeftRoom2.Item1; i <= bottomRightRoom2.Item1; ++i)
                for (int j = topLeftRoom2.Item2; j <= bottomRightRoom2.Item2; ++j)
                    roomCorners2.Add((i, j));

            (int, int) diff;
            foreach ((int, int) corner1 in roomCorners1)
            {
                foreach ((int, int) corner2 in roomCorners2)
                {
                    diff = (Math.Abs(corner1.Item1 - corner2.Item1), Math.Abs(corner1.Item2 - corner2.Item2));
                    if (diff == (0, 1) || diff == (1, 0)) return true;
                }
            }
            return false;
        }

        private bool IsOverlapping(Room room)
        {
            Border space = FloorViewModel.selectedGridCells;
            (int, int) topLeftCornerSpace = (Grid.GetColumn(space), Grid.GetRow(space));
            (int, int) bottomRightCornerSpace = (Grid.GetColumn(space) + Grid.GetColumnSpan(space) - 1, Grid.GetRow(space) + Grid.GetRowSpan(space) - 1);
            Position position = room.Position;
            (int, int) topLeftCornerRoom = (position.Column, position.Row);
            (int, int) bottomRightCornerRoom = (position.Column + position.ColumnSpan - 1, position.Row + position.RowSpan - 1);

            bool inside = false;
            List<(int, int)> roomCorners = new List<(int, int)>();

            for (int i = topLeftCornerRoom.Item1; i <= bottomRightCornerRoom.Item1; ++i)
                for (int j = topLeftCornerRoom.Item2; j <= bottomRightCornerRoom.Item2; ++j)
                    roomCorners.Add((i, j));

            foreach((int, int) corner in roomCorners)
            {
                if (corner.Item1 >= topLeftCornerSpace.Item1 &&
                   corner.Item2 >= topLeftCornerSpace.Item2 &&
                   corner.Item1 <= bottomRightCornerSpace.Item1 &&
                   corner.Item2 <= bottomRightCornerSpace.Item2)
                {
                    inside = true;
                    break;
                }
            }

            return inside;
        }

        private void editBuilding(Building _building)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent)
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
            OnPropertyChanged("Building");
        }
    }
}
