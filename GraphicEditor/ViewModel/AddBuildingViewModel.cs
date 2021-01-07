﻿using GraphicEditor.HelpClasses;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.ViewModel
{
    class AddBuildingViewModel : BindableBase
    {
        private BuildingDatabaseSql buildingDatabaseSql = new BuildingDatabaseSql(); // [Lemara98] This needs to be replaced with controller
        private FloorDatabaseSql floorDatabaseSql = new FloorDatabaseSql(); // [Lemara98] This needs to be replaced with controller
        public MyICommand<object> AddCommand { get; private set; }

        public Window Window { get; set; }

        ResourceDictionary myResourceDictionary = new ResourceDictionary();

        public int Shapes { get; set; }

        public string NameText { get; set; }

        public Color MyButtonColor { get; set; }

        public Button Button { get; set; }

        public int NumberOfFloors { get; set; }
        
        public AddBuildingViewModel(Window window, Button but)
        {
            Window = window;
            Button = but;
            AddCommand = new MyICommand<object>(AddBuilding);
            myResourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
        }

        private void AddBuilding(object obj)
        {
            switch (Shapes)
            {
                case 0:
                    SettingButtonLook("TriangleBuildingButtonStyle");
                    break;
                case 1:
                    SettingButtonLook("UBuildingButtonStyle");
                    break;
                case 2:
                    SettingButtonLook("OctagonBuildingButtonStyle");
                    break;
                case 3:
                    SettingButtonLook("DermatologyBuildingButtonStyle");
                    break;
                case 4:
                    SettingButtonLook("RectangleBuildingButtonStyle");
                    break;
                case 5:
                    SettingButtonLook("DefaultRectangleBuildingButtonStyle");
                    break;
            }
            Window.Close();
        }

        private void SettingButtonLook(string buildingButtonStyle)
        {
            Button.Style = (Style)myResourceDictionary[buildingButtonStyle];
            Button.Background = new SolidColorBrush(MyButtonColor); 
            Button.Name = NameText;

            string content = (string)Button.Content;
            string[] split = content.Split(" ");

            // [Lemara98] This needs to be corrected because I didn't find appropriate controller for buildings !!!
            Building newBuilding = new Building()
            {
                Name = NameText,
                Color = MyButtonColor.ToString(),
                Column = Int32.Parse(split[0]),
                Row = Int32.Parse(split[1]),
                Style = buildingButtonStyle
            };

            buildingDatabaseSql.Save(newBuilding);

            string buildingSerialNumber = newBuilding.SerialNumber;
            Button.Content = Button.Content + " " + buildingSerialNumber;

            for (int i = 0; i <= NumberOfFloors; i++)
            {
                Floor newFloor = new Floor() 
                {   
                    BuildingSerialNumber = buildingSerialNumber,
                    Name = Constants.FLOOR_NAMES[i]
                };

                floorDatabaseSql.Save(newFloor);
            }
        }
    }
}
