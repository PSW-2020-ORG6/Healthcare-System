using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel
{
    public class RoomSearchViewModel : BindableBase
    {
        private RoomDatabaseSql roomRepository = new RoomDatabaseSql();
        private FloorDatabaseSql floorRepository = new FloorDatabaseSql();
        private BuildingDatabaseSql buildingRepository = new BuildingDatabaseSql();

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
        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                SetProperty(ref _selectedRoom, value);
            }
        }

        public MyICommand<string> SearchCommand { get; private set; }

        public MyICommand<Room> GoToCommand { get; private set; }

        public RoomSearchViewModel()
        {
            SearchCommand = new MyICommand<string>(SearchRooms);
            GoToCommand = new MyICommand<Room>(FindRoom);
        }

        private void SearchRooms(string room)
        {
            _resultOfSearch = roomRepository.GetByName(room);
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

        private void FindRoom(Room room)
        {

        }
    }
}
