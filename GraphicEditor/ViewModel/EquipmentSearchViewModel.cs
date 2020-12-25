using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class EquipmentSearchViewModel : BindableBase
    {
        private RoomController roomController = new RoomController();
        private FloorController floorController = new FloorController();
        private BuildingController buildingController = new BuildingController();
        private EquipmentController equipmentController = new EquipmentController();
        private MainWindowViewModel parentViewModel;

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

        public EquipmentSearchViewModel(MainWindowViewModel vm)
        {
            SearchCommand = new MyICommand<string>(SearchEquipment);
            GoToCommand = new MyICommand(FindEquipment);
            parentViewModel = vm;
        }

        private void SearchEquipment(string equipmentName)
        {
            _resultOfSearch = equipmentController.GetByName(equipmentName);
            FoundEquipment = _resultOfSearch;
            _reportOfSearch = new List<string>();
            foreach (Equipment result in _resultOfSearch)
            {
                Floor floor = floorController.GetById(result.FloorSerialNumber);
                Building building = buildingController.GetById(floor.BuildingSerialNumber);
                Room room = roomController.GetById(result.RoomSerialNumber);
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
            HighlightRoom(equipment, floorViewModel);
        }

        private void HighlightRoom(Equipment equipment, CardiologyFirstFloorMapUserControlViewModel floorViewModel)
        {
            Button button = floorViewModel.connections[equipment.RoomSerialNumber];
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(150, 0, 255));

            CommonUtil.Run(() =>
            {
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }, TimeSpan.FromMilliseconds(5000));
        }
    }
}
