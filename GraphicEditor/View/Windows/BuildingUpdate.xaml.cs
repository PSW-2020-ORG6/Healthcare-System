using GraphicEditor.HelpClasses;
using GraphicEditor.ViewModel;
using health_clinic_class_diagram.Backend.Model.Hospital;
using System.Windows;

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
