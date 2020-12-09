using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using System.Windows;
using HealthClinicBackend.Backend.Model.Hospital;

namespace GraphicEditor.View.Windows
{
    /// <summary>
    /// Interaction logic for BuildingUpdate.xaml
    /// </summary>
    public partial class BuildingUpdate : Window
    {
        public BuildingUpdate(Building building, DialogAnswerListener<Building> dialogAnswerListener)
        {
            this.DataContext = new BuildingUpdateViewModel(this, building, dialogAnswerListener);
            InitializeComponent();
        }
    }
}
