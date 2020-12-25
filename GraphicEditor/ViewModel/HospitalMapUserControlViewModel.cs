using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class HospitalMapUserControlViewModel : BindableBase
    {
        public ResourceDictionary ResourceDictionary = new ResourceDictionary();
        private MainWindowViewModel _parent;
        private BuildingController buildingController = new BuildingController();

        public MyICommand<string> NavCommand { get; private set; }

        public MyICommand<object> AddCommand { get; private set; }

        public Grid HospitalMapGrid { get; set; }

        public HospitalMapUserControlViewModel( MainWindowViewModel parent, Grid hospitalMapGrid)
        {
            _parent = parent;
            HospitalMapGrid = hospitalMapGrid;
            NavCommand = new MyICommand<string>(ChooseHospital);
            AddCommand = new MyICommand<object>(AddBuilding);

            InitialGridRender();
        }

        /*TODO add this without causing errors
        _viewmodel.hospitalmap.hospitalmapgrid
        mapcontentusercontrolviewmodel.hospitalmap.hospitalmapgrid = hospitalmapgrid;
        this.datacontext = mapcontentusercontrolviewmodel.hospitalmap;
        mapcontentusercontrolviewmodel.hospitalmap.initialgridrender();
        */

        public void InitialGridRender()
        {
            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            foreach (Building building in buildingController.GetAll())
            {
                Button but = new Button();
                but.Style = (Style) ResourceDictionary[building.Style];
                but.Name = building.Name;
                var color = (Color) ColorConverter.ConvertFromString(building.Color);
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
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent || MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                Button but = (Button) button;
                if (but.Content.Equals("Empty field"))
                {
                    (new AddBuilding(but)).ShowDialog();
                }
            }
            else
            {
                new Warning().ShowDialog();
            }
        }


        private void ChooseHospital(string destination)
        {
            switch (destination)
            {
                case Constants.EMERGENCY:
                    break;
                case Constants.CARDIOLOGY:
                    _parent.CurrentUserControl = _parent.CardiologyBuilding;
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