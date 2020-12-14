﻿using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GraphicEditor.ViewModel
{
    public class CardiologyBuildingUserControlViewModel : BindableBase, DialogAnswerListener<Building>
    {
        private CardiologyBuildingUserControl _buildingParent;
        private MainWindowViewModel _mapParent;
        private List<string> _floors = new List<string>(Constants.FLOOR_MAP.Values);
        private string _selectedFloor = Constants.FLOOR_MAP[Constants.FIRST];
        private Building _building;
        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<Building> BuildingUpdateCommand { get; private set; }
        public static CardiologyFirstFloorMapUserControl FirstFloor;
        public static CardiologySecondFloorMapUserControl SecondFloor;
        public CardiologyFirstFloorMapUserControl _floorViewModel;
        public Grid grid;

        public CardiologyBuildingUserControlViewModel(CardiologyBuildingUserControl buildingParent ,MainWindowViewModel mapParent)
        {
            _mapParent = mapParent;
            _buildingParent = buildingParent;
            NavCommand = new MyICommand<string>(ChooseFloor);
            BuildingUpdateCommand = new MyICommand<Building>(editBuilding);
            FirstFloor = new CardiologyFirstFloorMapUserControl(mapParent, this);
            //SecondFloor = new CardiologySecondFloorMapUserControlViewModel();
            _floorViewModel = FirstFloor;

            List<Floor> _buildingFloors = new List<Floor>();

            _building = new Building("Cardiology", "Color Blue");
        }

        public CardiologyFirstFloorMapUserControl FloorViewModel
        {
            get { return _floorViewModel; }
            set
            {
                SetProperty(ref _floorViewModel, value);
            }
        }

        public List<string> Floors
        {
            get
            {
                return _floors;
            }
        }

        public Building Building
        {
            get
            {
                return _building;
            }
            set
            {
                SetProperty(ref _building, value);
            }
        }

        public string SelectedFloor
        {
            get { return _selectedFloor; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _selectedFloor, value);
                    String cpy = String.Copy(_selectedFloor);
                    var paramArray = cpy.Split(' ');
                    var param = paramArray[0].ToLower();
                    ChooseFloor(param);
                }
            }
        }

        private void ChooseFloor(string destination)
        {
            switch (destination)
            {
                case Constants.BACK:
                    _mapParent.CurrentUserControl = _mapParent.HospitalMap;
                    break;
                case Constants.FIRST:
                    FloorViewModel = FirstFloor;
                    break;
                //case Constants.SECOND:
                //    FloorViewModel = SecondFloor;
                //    break;
            }
        }

        private void editBuilding(Building _building)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent || MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                Building b = new Building(Building.Name, Building.Color);
                BuildingUpdate r = new BuildingUpdate(b, this);
                r.ShowDialog();
            }
            else
            {
                new Warning().ShowDialog();
            }
        }

        public void onConfirmUpdate(Building building)
        {
            Building.Name = building.Name;
            Building.Color = building.Color;
            OnPropertyChanged("Building");
        }
    }
}
