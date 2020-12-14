using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System.Collections.Generic;
namespace GraphicEditor.ViewModel
{
    public class EquipmentSearchViewModel : BindableBase
    {
        private RoomDatabaseSql roomRepository = new RoomDatabaseSql();
        private FloorDatabaseSql floorRepository = new FloorDatabaseSql();
        private BuildingDatabaseSql buildingRepository = new BuildingDatabaseSql();
        private EquipmentDatabaseSql equipmentDatabaseSql = new EquipmentDatabaseSql();

        private List<Equipment> _resultOfSearch;
        public List<Equipment> ResultOfSearch
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
        private Equipment _selectedEquipment;
        public Equipment SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                SetProperty(ref _selectedEquipment, value);
            }
        }

        public MyICommand<string> SearchCommand { get; private set; }

        public MyICommand<Equipment> GoToCommand { get; private set; }

        public EquipmentSearchViewModel()
        {
            SearchCommand = new MyICommand<string>(SearchEquipment);
            GoToCommand = new MyICommand<Equipment>(FindEquipment);
        }

        private void SearchEquipment(string equipmentName)
        {
            _resultOfSearch = equipmentDatabaseSql.GetByName(equipmentName);
            _reportOfSearch = new List<string>();
            foreach (Equipment result in _resultOfSearch)
            {
                Floor floor = floorRepository.GetBySerialNumber(result.FloorSerialNumber);
                Building building = buildingRepository.GetBySerialNumber(floor.BuildingSerialNumber);
                Room room = roomRepository.GetBySerialNumber(result.RoomSerialNumber);
                string fullLocation = building.Name + ", " + floor.Name + ", " + room.Name + ", " 
                                        + result.Name + " in quantity: " + result.Quantity;
                _reportOfSearch.Add(fullLocation);
            }
            OnPropertyChanged("ReportOfSearch");

        }

        private void FindEquipment(Equipment equipment)
        {

        }
    }
}
