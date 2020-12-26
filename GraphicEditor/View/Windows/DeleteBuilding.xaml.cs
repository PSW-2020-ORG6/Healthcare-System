using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            List<Floor> allDeletingFloors = floorDatabaseSql.GetByBuildingSerialNumber((string)button.Content);
            foreach (Floor fl in allDeletingFloors)
            {
                floorDatabaseSql.Delete(fl.SerialNumber);
            }
            string buildingContent = (string)button.Content;
            string[] split = buildingContent.Split(" ");
            buildingDatabaseSql.Delete(split[2]);
            string content = (string)button.Content;
            string[] info = content.Split(" ");
            string column = info[0];
            string row = info[1];
            button.Style = (Style)resourceDictionary["NewBuildingButtonStyle"];
            button.Content = column + " " + row;
            var color = (Color)ColorConverter.ConvertFromString("DimGray");
            Brush brush = new SolidColorBrush(color);
            button.Background = brush;
            this.Close();
        }

        private void Cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
