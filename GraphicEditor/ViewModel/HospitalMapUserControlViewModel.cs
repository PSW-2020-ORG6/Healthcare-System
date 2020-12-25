using GraphicEditor.HelpClasses;
using GraphicEditor.View.UserControls;
using GraphicEditor.View.Windows;
using HealthClinicBackend.Backend.Controller.SuperintendentControllers;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    public class HospitalMapUserControlViewModel : BindableBase
    {
        private MainWindowViewModel _parent;
        public MyICommand<string> NavCommand { get; private set; }

        public MyICommand<Button> AddCommand { get; private set; }

        public ResourceDictionary ResourceDictionary = new ResourceDictionary();

        public Grid HospitalMapGrid { get; set; }

        BuildingDatabaseSql buildingRepository = new BuildingDatabaseSql();

        public HospitalMapUserControlViewModel( MainWindowViewModel parent, Grid hospitalMapGrid)
        {
            _parent = parent;
            HospitalMapGrid = hospitalMapGrid;
            NavCommand = new MyICommand<string>(ChooseHospital);
            AddCommand = new MyICommand<Button>(AddBuilding);

            LoadBuildingsFromDatabase();
        }

        public void LoadBuildingsFromDatabase()
        {
            List<(int, int)> coordinates = new List<(int, int)>();

            for (int i = 1; i < HospitalMapGrid.ColumnDefinitions.Count; i += 2)
                for (int j = 1; j < HospitalMapGrid.RowDefinitions.Count; j += 2)
                {
                    if ((i == 7 && j == 3) || (i == 1 && j == 7)) continue;
                    coordinates.Add((i, j));
                }
            coordinates.Remove((3, 1)); // Delete later, this position is taken by hardcoded Cardiology building!

            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            foreach (Building building in buildingRepository.GetAll())
            {
                Button but = new Button();
                but.Style = (Style) ResourceDictionary[building.Style];
                but.Name = building.Name;
                var color = (Color) ColorConverter.ConvertFromString(building.Color);
                Brush brush = new SolidColorBrush(color);
                but.Background = brush;
                Grid.SetColumn(but, building.Column);
                Grid.SetRow(but, building.Row);
                coordinates.Remove((building.Column, building.Row));

                HospitalMapGrid.Children.Add(but);
                HospitalMapGrid.UpdateLayout();
            }

            foreach ((int i , int j)  in coordinates)
            {
                Button but = new Button();
                but.Style = (Style)ResourceDictionary["NewBuildingButtonStyle"];
                Grid.SetColumn(but, i);
                Grid.SetRow(but, j);

                HospitalMapGrid.Children.Add(but);
                HospitalMapGrid.UpdateLayout();
            }

        }

        private void AddBuilding(Button but)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent || MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                new AddBuilding(but).ShowDialog();
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