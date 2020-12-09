using GraphicEditor.HelpClasses;
using System.Windows;
using HealthClinicBackend.Backend.Model.Hospital;

namespace GraphicEditor.ViewModel
{
    public class BuildingUpdateViewModel : BindableBase
    {
        private Window _window;
        private Building _building;
        private Building _buildingOriginal;
        private DialogAnswerListener<Building> _dialogAnswerListener;

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

        public BuildingUpdateViewModel(Window window, Building _buildingInfo, DialogAnswerListener<Building> dialogAnswerListener)
        {
            _window = window;
            _building = _buildingInfo;
            _buildingOriginal = new Building(_building.Name, _building.Color);
            _dialogAnswerListener = dialogAnswerListener;

            NavCommandExit = new MyICommand(exitInfo);
            NavCommandUpdate = new MyICommand(updateBuildingInfo);
        }

        void updateBuildingInfo()
        {
            _dialogAnswerListener.onConfirmUpdate(BuildingInfo);
            _window.Close();
        }

        void exitInfo()
        {
            _window.Close();
        }
    }
}
