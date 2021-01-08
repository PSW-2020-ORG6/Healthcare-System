using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class UpdateBuildingViewModel : BindableBase
    {
        public MyICommand AddFloorCommand { get; set; }
        public MyICommand DeleteFloorCommand { get; set; }
        public MyICommand ConfirmUpdatesCommand { get; set; }
        public MyICommand CancelUpdatesCommand { get; set; }

        private Building building;
        private Building oldBuilding;
        private SolidColorBrush buildingColor;
        private List<Floor> newFloorList = new List<Floor>();
        private int numberOfFloors;

        private BuildingController buildingController = new BuildingController();
        private FloorController floorController = new FloorController();

        public Building BuildingInfo
        {
            get => building;
            set
            {
                SetProperty(ref building, value);
            }
        }

        public SolidColorBrush BuildingColor
        {
            get => buildingColor;
            set
            {
                SetProperty(ref buildingColor, value);
            }
        }

        public int FloorNumbers
        {
            get => numberOfFloors;
            set
            {
                SetProperty(ref numberOfFloors, value);
            }
        }

        public UpdateBuildingViewModel(Building _building)
        {
            AddFloorCommand = new MyICommand(AddFloor);
            DeleteFloorCommand = new MyICommand(DeleteFloor);
            ConfirmUpdatesCommand = new MyICommand(ConfirmUpdates);
            CancelUpdatesCommand = new MyICommand(CancelUpdates);
            oldBuilding = _building;
            buildingColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_building.Color));
            building = new Building(_building);

            oldBuilding.Floors = new List<Floor>(floorController.GetByBuildingSerialNumber(oldBuilding.SerialNumber));
            numberOfFloors = oldBuilding.Floors.Count;
            building.Floors = floorController.GetByBuildingSerialNumber(building.SerialNumber);
        }

        private void AddFloor()
        {
            if (FloorNumbers < 7) ++FloorNumbers;
        }

        private void DeleteFloor()
        {
            if (FloorNumbers != 1) --FloorNumbers;
        }

        private void ConfirmUpdates()
        {
            UpdateBuilding();
            buildingController.EditBuilding(building);
        }

        private void CancelUpdates()
        {
            building = oldBuilding;
        }

        private void UpdateBuilding()
        {
            building.Color = BuildingColor.Color.ToString();

            if (FloorNumbers > oldBuilding.Floors.Count)
            {
                for (int i = oldBuilding.Floors.Count; i < FloorNumbers; ++i)
                {
                    floorController.NewFloor(new Floor(building, i));
                }
            }
            else if (FloorNumbers < oldBuilding.Floors.Count)
            {
                for (int i = oldBuilding.Floors.Count - 1; i > FloorNumbers - 1; --i)
                {
                    floorController.DeleteFloor(oldBuilding.Floors[i]);
                }
            }

            oldBuilding.Name = building.Name;
            oldBuilding.Color = building.Color;
            oldBuilding.Floors = building.Floors;

            Button buildingButton = HospitalMapUserControlViewModel.buildingButtons[oldBuilding.SerialNumber];
            buildingButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(oldBuilding.Color));
            buildingButton.Content = oldBuilding.Name;
        }
    }
}
