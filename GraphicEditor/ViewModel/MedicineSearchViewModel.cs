using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class MedicineSearchViewModel : BindableBase
    {
        private RoomDatabaseSql roomRepository = new RoomDatabaseSql();
        private FloorDatabaseSql floorRepository = new FloorDatabaseSql();
        private BuildingDatabaseSql buildingRepository = new BuildingDatabaseSql();
        private MedicineDatabaseSql medicineRepository = new MedicineDatabaseSql();

        private MainWindowViewModel parentViewModel;

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

        public List<Medicine> FoundMedicines { get; set; }

        private int _selectedMedicineIndex;
        public int SelectedMedicineIndex
        {
            get => _selectedMedicineIndex;
            set
            {
                SetProperty(ref _selectedMedicineIndex, value);
            }
        }

        public MyICommand<string> SearchCommand { get; private set; }

        public MyICommand GoToCommand { get; private set; }

        public MedicineSearchViewModel(MainWindowViewModel vm)
        {
            SearchCommand = new MyICommand<string>(SearchMedicine);
            GoToCommand = new MyICommand(FindMedicine);
            parentViewModel = vm;
        }

        private void SearchMedicine(string medicineName)
        {
            _resultOfSearch = medicineRepository.GetByName(medicineName);
            FoundMedicines = _resultOfSearch;
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

        private void FindMedicine()
        {

            Medicine localMedicine = FoundMedicines[SelectedMedicineIndex];
            parentViewModel.CurrentUserControl = parentViewModel.CardiologyBuilding;
            CardiologyFirstFloorMapUserControlViewModel floorViewModel = parentViewModel.CardiologyBuilding.myViewModel.FirstFloor.Viewmodel;
            Button button = floorViewModel.connections[localMedicine.RoomSerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(150, 0, 255));

            CommonUtil.Run(() =>
            {
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }, TimeSpan.FromMilliseconds(5000));
        }
    }
}
