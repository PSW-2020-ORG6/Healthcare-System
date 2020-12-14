using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System.Collections.Generic;

namespace GraphicEditor.ViewModel
{
    public class MedicineSearchViewModel : BindableBase
    {
        private RoomDatabaseSql roomRepository = new RoomDatabaseSql();
        private FloorDatabaseSql floorRepository = new FloorDatabaseSql();
        private BuildingDatabaseSql buildingRepository = new BuildingDatabaseSql();
        private MedicineDatabaseSql medicineRepository = new MedicineDatabaseSql();

        private List<Medicine> _resultOfSearch;
        public List<Medicine> ResultOfSearch
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
        private Medicine _selectedMedicine;
        public Medicine SelectedMedicine
        {
            get => _selectedMedicine;
            set
            {
                SetProperty(ref _selectedMedicine, value);
            }
        }

        public MyICommand<string> SearchCommand { get; private set; }

        public MyICommand<Medicine> GoToCommand { get; private set; }

        public MedicineSearchViewModel()
        {
            SearchCommand = new MyICommand<string>(SearchMedicine);
            GoToCommand = new MyICommand<Medicine>(FindMedicine);
        }

        private void SearchMedicine(string medicineName)
        {
            _resultOfSearch = medicineRepository.GetByName(medicineName);
            _reportOfSearch = new List<string>();
            foreach (Medicine result in _resultOfSearch)
            {
                Room room = roomRepository.GetBySerialNumber(result.RoomSerialNumber);
                Floor floor = floorRepository.GetBySerialNumber(room.FloorSerialNumber);
                Building building = buildingRepository.GetBySerialNumber(floor.BuildingSerialNumber);
                string fullLocation = building.Name + ", " + floor.Name + ", " + room.Name + ", "
                                    + result.GenericName + " in quantity: " + result.Quantity;
                _reportOfSearch.Add(fullLocation);
            }
            OnPropertyChanged("ReportOfSearch");

        }

        private void FindMedicine(Medicine medicine)
        {

        }
    }
}
