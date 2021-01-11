using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class MedicineSearchViewModel : BindableBase
    {
        private RoomController roomController = new RoomController();
        private FloorController floorController = new FloorController();
        private BuildingController buildingController = new BuildingController();
        private SuperintendentMedicineController medicineController = new SuperintendentMedicineController();

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
            _resultOfSearch = medicineController.GetByName(medicineName);
            FoundMedicines = _resultOfSearch;
            _reportOfSearch = new List<string>();
            foreach (Medicine result in _resultOfSearch)
            {
                Room room = roomController.GetById(result.RoomSerialNumber);
                Floor floor = floorController.GetById(room.FloorSerialNumber);
                Building building = buildingController.GetById(floor.BuildingSerialNumber);
                string fullLocation = building.Name + ", " + floor.Name + ", " + room.Name + ", "
                                    + result.GenericName + " in quantity: " + result.Quantity;
                _reportOfSearch.Add(fullLocation);
            }
            OnPropertyChanged("ReportOfSearch");
        }

        private void FindMedicine()
        {
            //Medicine localMedicine = FoundMedicines[SelectedMedicineIndex];
            //parentViewModel.CurrentUserControl = parentViewModel.CardiologyBuilding;
            //CardiologyFirstFloorMapUserControlViewModel floorViewModel = parentViewModel.CardiologyBuilding.myViewModel.FirstFloor.Viewmodel;
            //HighlightRoom(localMedicine, floorViewModel);

            Medicine localMedicine = FoundMedicines[SelectedMedicineIndex];
            if (localMedicine != null)
            {
                Room room = roomController.GetBySerialNumber(localMedicine.RoomSerialNumber);
                Floor floor = floorController.GetBySerialNumber(room.FloorSerialNumber);
                Building building = buildingController.GetBySerialNumber(floor.BuildingSerialNumber);
                BuildingUserControl buildingUserControl = new BuildingUserControl(parentViewModel, building);
                FloorUserControl floorUserControl = new FloorUserControl(parentViewModel, buildingUserControl.myViewModel, floor);
                buildingUserControl.myViewModel.FloorViewModel = floorUserControl;
                parentViewModel.CurrentUserControl = buildingUserControl;
                HighlightRoom(localMedicine, floorUserControl.Viewmodel);
            }
        }

        private void HighlightRoom(Medicine localMedicine, FloorUserControlViewModel floorViewModel)
        {
            if (floorViewModel.connections.Count == 0) return;
            RoomButton roomButton = floorViewModel.connections[localMedicine.RoomSerialNumber];
            roomButton.Background = new SolidColorBrush(Color.FromRgb(42, 157, 244));
            parentViewModel.mainWindow.Focus();

            CommonUtil.Run(() =>
            {
                roomButton.Background = new SolidColorBrush(Color.FromRgb(35, 119, 147));
            }, TimeSpan.FromMilliseconds(5000));
        }
    }
}
