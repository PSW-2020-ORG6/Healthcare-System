using GraphicEditor.HelpClasses;
using GraphicEditor.View.Windows;
using GraphicEditor.Repositories;
using health_clinic_class_diagram.Backend.Model.Hospital;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class HospitalMapUserControlViewModel : BindableBase
    {
        private MapContentUserControlViewModel _parent;
        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<object> AddCommand { get; private set; }

        ResourceDictionary myResourceDictionary = new ResourceDictionary();

        ResourceDictionary myResourceDictionary = new ResourceDictionary();

        public Grid HospitalMapGrid { get; set; }

        BuildingRepository buildingRepository = new BuildingRepository();

        public HospitalMapUserControlViewModel(MapContentUserControlViewModel parent)
        {
            _parent = parent;
            NavCommand = new MyICommand<string>(ChooseHospital);
            AddCommand = new MyICommand<object>(AddBuilding);
        }

        /// <summary>
        /// Method for dynamic loading of buildings
        /// </summary>
        public void InitialGridRender()
        {
            foreach (Building building in buildingRepository.GetAllBuildings())
            {
                Button but = new Button();
                but.Style = (Style)myResourceDictionary[building.Style];
                but.Name = "Building" + building.SerialNumber;
                var color = (Color)ColorConverter.ConvertFromString(building.Color);
                Brush brush = new SolidColorBrush(color);
                but.Background = brush;
                Grid.SetColumn(but, building.Column);
                Grid.SetRow(but, building.Row);

                HospitalMapGrid.Children.Add(but);
                HospitalMapGrid.UpdateLayout();
            }
        }

        private void AddBuilding(object button)
        {
            Button but = (Button)button;
            if( but.Content.Equals("Empty field") )
            {
                (new AddBuilding(but)).ShowDialog();
            }
        }


        private void ChooseHospital(string destination)
        {
            switch (destination)
            {
                case Constants.EMERGENCY:
                    break;
                case Constants.CARDIOLOGY:
                    _parent.ContentViewModel = MapContentUserControlViewModel.CardiologyBuilding;
                    break;
                case Constants.ORTHOPEDICS:

                    break;
                case Constants.PEDIATRICS:

                    break;
                case Constants.DERMATOLOGY:

                    break;
                case Constants.ONCOLOGY:

                    break;
            }
        }
    }
}
