using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
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
            if (room != null)
            {
                Floor floor = floorController.GetBySerialNumber(room.FloorSerialNumber);
                Building building = buildingController.GetBySerialNumber(floor.BuildingSerialNumber);
                BuildingUserControl buildingUserControl = new BuildingUserControl(parentViewModel, building);
                FloorUserControl floorUserControl = new FloorUserControl(parentViewModel, buildingUserControl.myViewModel, floor);
                buildingUserControl.myViewModel.FloorViewModel = floorUserControl;
                parentViewModel.CurrentUserControl = buildingUserControl;
                HighlightRoom(room, floorUserControl.Viewmodel);
            }
        }

        private void HighlightRoom(Room room, FloorUserControlViewModel floorViewModel)
        {
            if (floorViewModel.connections.Count == 0) return;
            RoomButton roomButton = floorViewModel.connections[room.SerialNumber];
            roomButton.Background = new SolidColorBrush(Color.FromRgb(42, 157, 244));
            parentViewModel.mainWindow.Focus();
            CommonUtil.Run(() =>
            {
                roomButton.Background = new SolidColorBrush(Color.FromRgb(35, 119, 147));
            }, TimeSpan.FromMilliseconds(5000));
        }
    }
}
