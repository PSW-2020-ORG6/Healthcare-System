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
        public ResourceDictionary ResourceDictionary = new ResourceDictionary();
        private MainWindowViewModel _parent;
        private BuildingController buildingController = new BuildingController();

        public static Dictionary<string, Button> buildingButtons = new Dictionary<string, Button>();

        public MyICommand<string> NavCommand { get; private set; }

        public MyICommand<Button> NavRealCommand { get; private set; }

        public MyICommand<Button> AddCommand { get; private set; }

        public MyICommand<Button> DeleteCommand { get; private set; }

        public Grid HospitalMapGrid { get; set; }

        public HospitalMapUserControlViewModel( MainWindowViewModel parent, Grid hospitalMapGrid)
        {
            _parent = parent;
            HospitalMapGrid = hospitalMapGrid;
            NavCommand = new MyICommand<string>(ChooseHospital);
            AddCommand = new MyICommand<Button>(AddBuilding);
            DeleteCommand = new MyICommand<Button>(DeleteBuilding);
            NavRealCommand = new MyICommand<Button>(EnterBuilding);

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

            ResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            foreach (Building building in buildingController.GetAll())
            {
                Button but = new Button();
                but.Style = (Style)ResourceDictionary[building.Style];
                but.Content = building.Name;
                but.Tag = building.Column.ToString() + " " + building.Row.ToString() + " " + building.SerialNumber;
                //but.Name = building.Name;
                //but.Content = building.Column.ToString() + " " + building.Row.ToString() + " " + building.SerialNumber;
                var color = (Color)ColorConverter.ConvertFromString(building.Color);
                Brush brush = new SolidColorBrush(color);
                but.Background = brush;
                Grid.SetColumn(but, building.Column);
                Grid.SetRow(but, building.Row);
                coordinates.Remove((building.Column, building.Row));

                HospitalMapGrid.Children.Add(but);
                HospitalMapGrid.UpdateLayout();
                buildingButtons[building.SerialNumber] = but;
            }

            foreach ((int i , int j)  in coordinates)
            {
                Button but = new Button();
                but.Style = (Style)ResourceDictionary["NewBuildingButtonStyle"];
                but.Tag = i.ToString() + " " + j.ToString();
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

        private void DeleteBuilding(Button but)
        {
            if (MainWindow.TypeOfUser == TypeOfUser.Superintendent || MainWindow.TypeOfUser == TypeOfUser.NoUser)
            {
                new DeleteBuilding(but).ShowDialog();
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

        private void EnterBuilding(Button button)
        {
            string content = (string)button.Tag;
            string[] info = content.Split(" ");
            Building enteringBuilding = buildingController.GetById(info[2]);

            _parent.CurrentUserControl = new BuildingUserControl(_parent, enteringBuilding);
        }
    }
}
