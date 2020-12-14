using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace GraphicEditor.ViewModel
{
    public class RoomSearchViewModel : BindableBase
    {
        private RoomDatabaseSql roomRepository = new RoomDatabaseSql();
        private FloorDatabaseSql floorRepository = new FloorDatabaseSql();
        private BuildingDatabaseSql buildingRepository = new BuildingDatabaseSql();

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

        public List<Room> FoundRooms { get; set; }

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
            _resultOfSearch = roomRepository.GetByName(roomName);
            FoundRooms = _resultOfSearch;
            _reportOfSearch = new List<string>();
            foreach (Room result in _resultOfSearch)
            {
                Floor floor = floorRepository.GetBySerialNumber(result.FloorSerialNumber);
                Building building = buildingRepository.GetBySerialNumber(floor.BuildingSerialNumber);
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
            Button button = floorViewModel.connections[room.SerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(150,0,255));
            
            CommonUtil.Run(() =>
            {
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }, TimeSpan.FromMilliseconds(5000));
        }   
    }
}
