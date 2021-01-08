using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for DeleteBuilding.xaml
    /// </summary>
    public partial class DeleteBuilding : Window
    {
        private Button button;
        private BuildingDatabaseSql buildingDatabaseSql = new BuildingDatabaseSql(); // [Lemara98] Correct this to controllers
        private FloorDatabaseSql floorDatabaseSql = new FloorDatabaseSql();
        private ResourceDictionary resourceDictionary = new ResourceDictionary();
        public DeleteBuilding(Button deletingButton)
        {
            InitializeComponent();
            button = deletingButton;
        }

        private void Delete_click(object sender, RoutedEventArgs e) // [Lemara98] Corrections needed
        {
            resourceDictionary.Source = new Uri("/GraphicEditor;component/Resources/Styles/ButtonStyles.xaml", UriKind.RelativeOrAbsolute);
            string buildingContent = (string)button.Tag;
            string[] split = buildingContent.Split(" ");
            buildingDatabaseSql.Delete(split[2]);
            string column = split[0];
            string row = split[1];
            string buildingSerialNumber = split[2];
            List<Floor> allDeletingFloors = floorDatabaseSql.GetByBuildingSerialNumber(buildingSerialNumber);
            foreach (Floor fl in allDeletingFloors)
            {
                floorDatabaseSql.Delete(fl.SerialNumber);
            }

            button.Style = (Style)resourceDictionary["NewBuildingButtonStyle"];
            button.Tag = column + " " + row;
            var color = (Color)ColorConverter.ConvertFromString("DimGray");
            Brush brush = new SolidColorBrush(color);
            button.Background = brush;

            HospitalMapUserControlViewModel.buildingButtons.Remove(buildingSerialNumber);

            this.Close();
        }

        private void Cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
