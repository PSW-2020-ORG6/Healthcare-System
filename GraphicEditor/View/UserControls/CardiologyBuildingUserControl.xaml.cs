﻿using GraphicEditor.View.Windows;
using GraphicEditor.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View.UserControls
{
    /// <summary>
    /// Interaction logic for CardiologyBuildingUserControl.xaml
    /// </summary>
    public partial class CardiologyBuildingUserControl : UserControl
    {
        public CardiologyBuildingUserControl()
        {
            this.DataContext = MapContentUserControlViewModel.CardiologyBuilding;
            InitializeComponent();

            MapContentUserControlViewModel.CardiologyBuilding.grid = CardiologyFirstFloorMapUserControl.FloorGrid;
          //  MapContentUserControlViewModel.CardiologyBuilding.FirstFloor.InitialGridRender();
        }

        private void ShowRoomSearch(object sender, RoutedEventArgs e)
        {
            RoomSearch roomSearch = new RoomSearch();
            roomSearch.Show();
        }

        private void ShowEquipmentSearch(object sender, RoutedEventArgs e)
        {
            EquipmentSearch equipmentSearch = new EquipmentSearch();
            equipmentSearch.Show();
        }

        private void ShowMedicineSearch(object sender, RoutedEventArgs e)
        {
            MedicineSearch medicineSearch = new MedicineSearch();
            medicineSearch.Show();
        }
    }
}
