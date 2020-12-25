using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class RoomSearchViewModel : BindableBase
    {
        private RoomController roomController = new RoomController();
        private FloorController floorController = new FloorController();
        private BuildingController buildingController = new BuildingController();
        private MainWindowViewModel parentViewModel;
        private List<Room> _resultOfSearch;

        public List<Room> ResultOfSearch
        {
            get => _resultOfSearch;
            set
            {
                SetProperty(ref _resultOfSearch, value);
            }
        }

        private List<string> _reportOfSearch = new List<string>();
        public List<string> ReportOfSearch
        {
            get => _reportOfSearch;
            set
            {
                SetProperty(ref _reportOfSearch, value);
            }
        }

        private string _queryForSearch;
        public string QueryForSearch
        {
            get => _queryForSearch;
            set
            {
                SetProperty(ref _queryForSearch, value);
            }
        }
        private int _selectedRoomIndex;
        public int SelectedRoomIndex
        {
            get => _selectedRoomIndex;
            set
            {
                SetProperty(ref _selectedRoomIndex, value);
            }
        }

        public List<Room> FoundRooms { get; set; }

        public MyICommand<string> SearchCommand { get; private set; }

        public MyICommand GoToCommand { get; private set; }

        public RoomSearchViewModel(MainWindowViewModel vm)
        {
            SearchCommand = new MyICommand<string>(SearchRooms);
            GoToCommand = new MyICommand(FindRoom);
            parentViewModel = vm;
        }

        private void SearchRooms(string roomName)
        {
            FoundRooms = new List<Room>();
            _resultOfSearch = roomController.GetByName(roomName);
            FoundRooms = _resultOfSearch;
            _reportOfSearch = new List<string>();
            foreach (Room result in _resultOfSearch)
            {
                Floor floor = floorController.GetById(result.FloorSerialNumber);
                Building building = buildingController.GetById(floor.BuildingSerialNumber);
                string fullLocation = building.Name + ", " + floor.Name + ", " + result.Name;
                _reportOfSearch.Add(fullLocation);

            }
            OnPropertyChanged("ReportOfSearch");

        }

        private void FindRoom()
        {
            Room room = FoundRooms[SelectedRoomIndex];
            parentViewModel.CurrentUserControl = parentViewModel.CardiologyBuilding;
            CardiologyFirstFloorMapUserControlViewModel floorViewModel = parentViewModel.CardiologyBuilding.myViewModel.FirstFloor.Viewmodel;
            HighlightRoom(room, floorViewModel);
        }

        private void HighlightRoom(Room room, CardiologyFirstFloorMapUserControlViewModel floorViewModel)
        {
            Button button = floorViewModel.connections[room.SerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(150, 0, 255));

            CommonUtil.Run(() =>
            {
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }, TimeSpan.FromMilliseconds(5000));
        }
    }
}
