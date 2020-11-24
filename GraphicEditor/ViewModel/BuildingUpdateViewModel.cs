using GraphicEditor.HelpClasses;
using health_clinic_class_diagram.Backend.Model.Hospital;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphicEditor.ViewModel
{
    public class BuildingUpdateViewModel : BindableBase
    {
        private Window _window;
        private Building _building;
        private Building _buildingOriginal;

        public MyICommand NavCommandUpdate { get; private set; }

        public MyICommand NavCommandExit { get; private set; }

        public Building BuildingInfo
        {
            get => _building;
            set
            {
                if (value != null)
                    SetProperty(ref _building, value);
            }
        }

        public BuildingUpdateViewModel(Window window, Building _buildingInfo)
        {
            _window = window;
            _building = _buildingInfo;
            _buildingOriginal = new Building(_building.Id, _building.Name, _building.Floors, _building.Color, _building.Shape);

            NavCommandExit = new MyICommand(exitInfo);
            NavCommandUpdate = new MyICommand(updateBuildingInfo);
        }

        void updateBuildingInfo()
        {
            _window.Close();
        }

        void exitInfo()
        {
            BuildingInfo.Id = _buildingOriginal.Id;
            BuildingInfo.Name = _buildingOriginal.Name;
            BuildingInfo.Floors = _buildingOriginal.Floors;
            BuildingInfo.Color = _buildingOriginal.Color;
            BuildingInfo.Shape = _buildingOriginal.Shape;
            OnPropertyChanged("BedInfo");
            _window.Close();
        }
    }
}
