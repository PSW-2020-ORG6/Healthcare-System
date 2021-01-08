using GraphicEditor.ViewModel;
using HealthClinicBackend.Backend.Model.Hospital;
using System.Windows;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for UpdateBuilding.xaml
    /// </summary>
    public partial class UpdateBuilding : Window
    {
        public UpdateBuilding(Building building)
        {
            this.DataContext = new UpdateBuildingViewModel(building);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
