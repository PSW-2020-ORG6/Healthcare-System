using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

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

        public List<Equipment> FoundEquipment { get; set; }

        private int _selectedEquipmentIndex;
        public int SelectedEquipmentIndex
        {
            get => _selectedEquipmentIndex;
            set
            {
                SetProperty(ref _selectedEquipmentIndex, value);
            }
        }

        public MyICommand<string> SearchCommand { get; private set; }

        public MyICommand GoToCommand { get; private set; }

        private MainWindowViewModel parentViewModel;

        public EquipmentSearchViewModel(MainWindowViewModel vm)
        {
            SearchCommand = new MyICommand<string>(SearchEquipment);
            GoToCommand = new MyICommand(FindEquipment);
            parentViewModel = vm;
        }

        private void SearchEquipment(string equipmentName)
        {
            _resultOfSearch = equipmentDatabaseSql.GetByName(equipmentName);
            FoundEquipment = _resultOfSearch;
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

        private void FindEquipment()
        {
            Equipment equipment = FoundEquipment[SelectedEquipmentIndex];
            parentViewModel.CurrentUserControl = parentViewModel.CardiologyBuilding;
            CardiologyFirstFloorMapUserControlViewModel floorViewModel = parentViewModel.CardiologyBuilding.myViewModel.FirstFloor.Viewmodel;
            Button button = floorViewModel.connections[equipment.RoomSerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(150, 0, 255));

            CommonUtil.Run(() =>
            {
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }, TimeSpan.FromMilliseconds(5000));
        }
    }
}
